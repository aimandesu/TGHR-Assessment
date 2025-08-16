using tg.application.Common;
using tg.application.Features.Following;
using tg.application.Mapper;
using tg.application.Repository;
using tg.application.Repository.IServiceRepository;
using tg.application.Repository.IUserRepository;
using tg.domain.Entities;

namespace tg.application.Features.Service.Delete;

public class DeleteServiceHandler : ICommandHandler<DeleteServiceRequest, Result<DeleteServiceResponse>>
{
    
    private readonly IServiceRepository _serviceRepository;
    private readonly IUserService  _userService;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteServiceHandler(
        IServiceRepository serviceRepository,
        IUnitOfWork unitOfWork,
        IUserService userService
        )
    {
        _serviceRepository = serviceRepository;
        _unitOfWork = unitOfWork;
        _userService = userService;
    }
    
    public async Task<Result<DeleteServiceResponse>> Handle(
        DeleteServiceRequest request, 
        CancellationToken cancellationToken)
    {
        if (!_userService.IsAuthenticated)
            throw new UnauthorizedAccessException("User is not authenticated");

        var service = await _serviceRepository.DeleteService(
            serviceId: new Guid(request.Id ?? ""), 
            userId: _userService.UserId ?? ""
            );

        if (service == null)
        {
            return Result<DeleteServiceResponse>.Failure(new Error("400", "No service found with the given id"));
        }
        
        await _unitOfWork.Save(cancellationToken);
        
        return Result<DeleteServiceResponse>.Success(new DeleteServiceResponse
        {
            Service = service.ToServiceModelDto()
        });
        
    }
}