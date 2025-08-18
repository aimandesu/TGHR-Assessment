using tg.application.Features.Service.Create;
using tg.application.Repository;

namespace tg.application.Features.Package.Create;

public sealed record class CreatePackageRequest(
    double Price,
    string PackageOffer,
    Guid ServiceId
    ) : ICommand<CreatePackageResponse>;