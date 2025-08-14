using tg.application.Common;
using tg.application.Features.User;

namespace tg.application.Repository;

public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    Task<Result> Handle(TCommand command, CancellationToken ct); // we can also implement Response<UserSuccess, UserFailure>
}

public interface ICommandHandler<in TCommand, TResult> 
    where TCommand:  ICommand<TResult>
{
    Task<TResult> Handle(TCommand command, CancellationToken ct);
}