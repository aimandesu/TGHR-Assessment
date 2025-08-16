using tg.application.Dtos;
using tg.domain.Entities;

namespace tg.application.Features.Follower.GetFollower;

public sealed record class GetFollowerResponse
{
    public List<FollowerModelDto> Followers { get; set; } = [];
}