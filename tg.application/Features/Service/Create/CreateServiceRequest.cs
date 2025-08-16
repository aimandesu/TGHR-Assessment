using tg.application.Common;
using tg.application.Repository;

namespace tg.application.Features.Service.Create;

public sealed record class CreateServiceRequest(
    string Title, string Details) : ICommand<Result<CreateServiceResponse>>;