using tg.application.Dtos;
using tg.application.Repository;
using tg.application.Repository.IPackageRepository;
using tg.application.Repository.IUserRepository;

namespace tg.application.Features.Package.Create;

public class CreatePackageHandler : ICommandHandler<CreatePackageRequest, CreatePackageResponse>
{
    
    private readonly IPackageRepository _packageRepository;
    private readonly IUserService  _userService;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePackageHandler(
        IPackageRepository packageRepository,
        IUserService  userService,
        IUnitOfWork unitOfWork
        )
    {
        _packageRepository = packageRepository;
        _userService = userService;
        _unitOfWork = unitOfWork;
    }
    
    
    public async Task<CreatePackageResponse> Handle(
        CreatePackageRequest request, 
        CancellationToken cancellationToken)
    {
        if (!_userService.IsAuthenticated)
            throw new UnauthorizedAccessException("User is not authenticated");
        
        var package = await _packageRepository.AddPackage(request, _userService.UserId ?? "");
        
        await _unitOfWork.Save(cancellationToken);

        return new CreatePackageResponse
        {
            PackageModelDto = new PackageModelDto
            {
                Id = package.Id,
                Price = package.Price,
                PackageOffer = package.PackageOffer,
                ServiceId = package.ServiceId
            }
        };

    }
}