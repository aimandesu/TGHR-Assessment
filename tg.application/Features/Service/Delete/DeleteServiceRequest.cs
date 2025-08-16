using tg.application.Common;
using tg.application.Repository;

namespace tg.application.Features.Service.Delete;

public sealed record class DeleteServiceRequest(
    string Id) : ICommand<Result<DeleteServiceResponse>>;