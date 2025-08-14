using tg.application.Features.Follower.GetFollower;
using tg.application.Repository;
using tg.domain.Entities;

namespace tg.application.Features.Following.GetFollower;

public sealed record class GetFollowerRequest(
    string UserId) : ICommand<GetFollowerResponse>;