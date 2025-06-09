using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using tg.application.Common;
using tg.application.Features.User;
using tg.application.Features.User.SignUp;

namespace tg.api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(
            IMediator mediator
        )
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Result<UserSuccess, UserFailure>>> SignUpUser(
            SignUpUserRequest request,
            CancellationToken cancellationToken
        )
        {
            var result = await _mediator.Send(request, cancellationToken);
            if (result.Result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

    }
}