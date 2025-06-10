using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using tg.application.Common;
using tg.application.Features.User;
using tg.application.Features.User.Search.Freelancer;
using tg.application.Features.User.SignUp;
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
        public async Task<ActionResult<Result<UserSuccess, UserFailure>>> SignUpUser(
            SignUpUserRequest request,
            CancellationToken cancellationToken
        )
        {
            var result = await _mediator.Send(request, cancellationToken);

            if (!result.Result.IsSuccess)
                return BadRequest(result);

            var token = _tokenRepository.CreateToken(request.Email, request.Username, result.Result.SuccessData.UserModel.Id);

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
            var response = await _mediator.Send(new GetFreelancerRequest(request.Email, request.Username), cancellationToken);
            return Ok(response);
        }

    }
}