using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tg.application.Features.Hobby.Create;
using tg.application.Features.Hobby.Get;

namespace tg.api.Controllers
{
    [Route("api/hobbies")]
    [ApiController]
    public class HobbyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HobbyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<ActionResult<List<GetHobbyResponse>>> GetHobbies(
            CancellationToken cancellationToken
        )
        {
            var response = await _mediator.Send(
                new GetHobbyRequest(),
                cancellationToken
            );

            return Ok(response);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<ActionResult<CreateHobbyResponse>> Create(
            CreateHobbyRequest request,
            CancellationToken cancellationToken
        )
        {
            var response = await _mediator.Send(
                request,
                cancellationToken
            );

            return Ok(response);
        }

    }
}