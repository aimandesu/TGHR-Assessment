using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using tg.application.Common;
using tg.application.Features.User;
using tg.application.Features.User.SignUp;
using tg.application.Repository.ITokenRepository;

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

            var token = _tokenRepository.CreateToken(request.Email, request.Username);

            HttpContext.Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(5)
            });

            return Ok(result);
        }

    }
}