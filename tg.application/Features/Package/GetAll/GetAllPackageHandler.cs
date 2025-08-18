using tg.application.Common;
using tg.application.Dtos;
using tg.application.Repository;
using tg.application.Repository.IPackageRepository;

namespace tg.application.Features.Package.GetAll;

public class GetAllPackageHandler : ICommandHandler<GetAllPackageRequest, Pagination<PackageModelDto>>
{
    private readonly IPackageRepository _packageRepository;

    public GetAllPackageHandler(
        IPackageRepository packageRepository)
    {
        _packageRepository = packageRepository;
    }
    
    public async Task<Pagination<PackageModelDto>> Handle(
        GetAllPackageRequest request, 
        CancellationToken cancellationToken)
    {
        var packages = await _packageRepository.GetAllPackages(
            userId: request.UserId,
            page: request.Page,
            pageSize: request.PageSize,
            request.ServiceId ?? Guid.Empty
        );

        return new Pagination<PackageModelDto>
        {
            Data = packages.Data,
            CurrentPage = packages.CurrentPage,
            PerPage = packages.PerPage,
            Total = packages.Total,
            LastPage = packages.LastPage,
        };

    }
}