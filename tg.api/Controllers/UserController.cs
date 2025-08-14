using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tg.application.Common;
using tg.application.Features.User;
using tg.application.Features.User.Archive;
using tg.application.Features.User.Delete;
using tg.application.Features.User.Get;
using tg.application.Features.User.Login;
using tg.application.Features.User.Search;
using tg.application.Features.User.SignUp;
using tg.application.Features.User.Update;
using tg.application.Repository.ITokenRepository;
using tg.domain.Entities;

namespace tg.api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITokenRepository _tokenRepository;

        public UserController(
            IMediator mediator,
            ITokenRepository tokenRepository
        )
        {
            _mediator = mediator;
            _tokenRepository = tokenRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<SignUpUserResponse>> SignUpUser(
            SignUpUserRequest request,
            CancellationToken cancellationToken
        )
        {
            var result = await _mediator.Send(request, cancellationToken);

            if (!result.ResultResponse.IsSuccess)
                return BadRequest(result);

            var token = _tokenRepository.CreateToken(
                request.Email,
                request.Username,
                result.ResultResponse.SuccessData.UserModel.Id
            );

            HttpContext.Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(5)
            });

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginUserResponse>> LoginUser(
            LoginUserRequest request,
            CancellationToken cancellationToken
        )
        {
            var result = await _mediator.Send(request, cancellationToken);

            if (!result.ResultResponse.IsSuccess)
                return BadRequest(result);

            var token = _tokenRepository.CreateToken(
                result.ResultResponse.SuccessData.UserModel.Email,
                request.Username,
                result.ResultResponse.SuccessData.UserModel.Id
            );

            HttpContext.Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(5)
            });

            return Ok(result);
        }

        [HttpPost("freelancer/search")]
        public async Task<ActionResult<UserModel?>> SearchFreelancer(
            GetFreelancerRequest request,
            CancellationToken cancellationToken
        )
        {
            var response = await _mediator.Send(
                new GetFreelancerRequest(request.Email, request.Username),
                cancellationToken
            );

            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("freelancer/getall")]
        public async Task<ActionResult<List<GetAllFreelancerResponse>>> GetAllFreelancer(
            CancellationToken cancellationToken,
            [FromQuery] PaginationQueryObject paginationQueryObject
        )
        {
            var response = await _mediator.Send(
                new GetAllFreelancerRequest(
                    paginationQueryObject
                ),
                cancellationToken
            );

            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("delete")]
        public async Task<ActionResult<UserModel>> DeleteUser(
            DeleteUserRequest request,
            CancellationToken cancellationToken
        )
        {
            var response = await _mediator.Send(
               request,
               cancellationToken
            );

            return Ok(response);

        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("update")]
        public async Task<ActionResult<UpdateUserResponse>> UpdateUser(
            UpdateUserRequest request,
            CancellationToken cancellationToken
        )
        {
            var response = await _mediator.Send(
                request,
                cancellationToken
            );

            return Ok(response);

        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPatch("archive/{isArchived}")]
        public async Task<ActionResult<UserModel>> UpdateArchive(
        bool isArchived,
        CancellationToken cancellationToken
        )
        {
            var request = new ArchiveUnarchiveFreelancerRequest(isArchived);

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }


    }
}