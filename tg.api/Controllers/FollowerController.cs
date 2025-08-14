using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tg.application.Common;
using tg.application.Features.Follower.Follow;
using tg.application.Features.Follower.GetFollower;
using tg.application.Features.Following.GetFollower;
using tg.application.Repository;
using tg.domain.Entities;

namespace tg.api.Controllers;

[Route("api/follower")]
[ApiController]
public class FollowerController : ControllerBase
{
    private readonly ICommandHandler<CreateFollowRequest, Result<CreateFollowResponse>> _createFollowHandler;
    private readonly ICommandHandler<GetFollowerRequest, GetFollowerResponse> _getFollowerHandler;
    
    public FollowerController(
        ICommandHandler<CreateFollowRequest, Result<CreateFollowResponse>> 
            createFollowHandler,
        ICommandHandler<GetFollowerRequest, GetFollowerResponse> getFollowerHandler)
    {
        _createFollowHandler = createFollowHandler;
        _getFollowerHandler = getFollowerHandler;
    }
    
    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost("follow")]
    public async Task<IActionResult> FollowUser(
        [FromQuery] CreateFollowRequest request, 
        CancellationToken cancellationToken)
    {
        var result = await _createFollowHandler.Handle(request, cancellationToken);

        if (result.IsFailure)
        {
            return NotFound(result.Error.Description); // or BadRequest, depending on your error type
        }

        Console.WriteLine("test");
        return Ok(result.Value); // result.Value is CreateFollowResponse
    }

    [HttpGet("followers")]
    public async Task<IActionResult> GetFollower([FromQuery] GetFollowerRequest request, CancellationToken cancellationToken)
    {
        var result = await _getFollowerHandler.Handle(request, cancellationToken);

        return Ok(result);

    }
    
}