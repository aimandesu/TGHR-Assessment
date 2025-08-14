using MediatR;
using tg.application.Common;
using tg.application.Features.User;
using tg.application.Repository;
using tg.application.Repository.IUserRepository;
using tg.domain.Entities;

namespace tg.application.Features.Following;

public sealed record StartFollowingCommand(Guid UserId, Guid FollowerId) : ICommand;

internal sealed class StartFollowingCommandHandler : ICommandHandler<StartFollowingCommand>
{
    private readonly IUserRepository  _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public StartFollowingCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> Handle(
        StartFollowingCommand command, 
        CancellationToken ct)
    {
        UserModel? user = await _userRepository.GetUserById(command.UserId.ToString());

        if (user == null)
        {
            return UserErrors.NotFound(command.UserId.ToString());
        }

        await _unitOfWork.Save(ct);

        return Result.Success();
    }

}

public static class UserErrors
{
    public static Error NotFound(string userId) => new Error("User", "User not found");
}


public sealed record Error(string Code, string Description)
{
    public static Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new("Error.NullValue", "Null value was provided");
    
    public static implicit operator Result(Error error) => Result.Failure(error);

    public Result ToResult() => Result.Failure(this);

}