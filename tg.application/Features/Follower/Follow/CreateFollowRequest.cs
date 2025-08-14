using tg.application.Common;
using tg.application.Repository;

namespace tg.application.Features.Follower.Follow;

public sealed record class CreateFollowRequest(
    string UserId) : ICommand<Result<CreateFollowResponse>>;