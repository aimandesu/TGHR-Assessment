using tg.application.Common;
using tg.application.Dtos;
using tg.application.Repository;

namespace tg.application.Features.Package.GetAll;

public sealed record class GetAllPackageRequest(
    string UserId, 
    Guid? ServiceId,
    int Page = 1,
    int PageSize = 10
    ) : ICommand<Pagination<PackageModelDto>>;