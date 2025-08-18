using tg.application.Common;
using tg.application.Dtos;
using tg.application.Features.Package.Create;
using tg.domain.Entities;

namespace tg.application.Repository.IPackageRepository;

public interface IPackageRepository
{
    Task<PackageModel> AddPackage(CreatePackageRequest request, String userId);
    Task<Pagination<PackageModelDto>> GetAllPackages(
        string userId, 
        int page, 
        int pageSize,
        Guid serviceId);
}