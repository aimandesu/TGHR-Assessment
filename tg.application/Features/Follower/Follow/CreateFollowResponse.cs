using tg.application.Dtos;
using tg.domain.Entities;

namespace tg.application.Features.Follower.Follow;

public sealed record class CreateFollowResponse
{
    public UserModelDto? User { get; set; }
}