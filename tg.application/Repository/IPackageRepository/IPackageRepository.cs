using tg.application.Features.Package.Create;
using tg.domain.Entities;

namespace tg.application.Repository.IPackageRepository;

public interface IPackageRepository
{
    Task<PackageModel> AddPackage(CreatePackageRequest request, String userId);
}