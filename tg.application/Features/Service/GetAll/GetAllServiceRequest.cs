using tg.application.Common;
using tg.application.Dtos;
using tg.application.Repository;
using tg.domain.Entities;

namespace tg.application.Features.Service.GetAll;

public sealed record class GetAllServiceRequest(
    string UserId = "",
    int Page = 1,
    int PageSize = 10
    ) : ICommand<Pagination<ServiceModelDto>>;