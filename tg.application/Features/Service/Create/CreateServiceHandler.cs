using tg.application.Common;
using tg.application.Dtos;
using tg.application.Features.Following;
using tg.application.Mapper;
using tg.application.Repository;
using tg.application.Repository.IServiceRepository;
using tg.application.Repository.IUserRepository;
using tg.domain.Entities;

namespace tg.application.Features.Service.Create;

public class CreateServiceHandler : ICommandHandler<CreateServiceRequest, Result<CreateServiceResponse>>
{
    
    private readonly IServiceRepository _serviceRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUserService  _userService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateServiceHandler(
        IServiceRepository serviceRepository,
        IUserRepository userRepository,
        IUserService userService,
        IUnitOfWork unitOfWork
        )
    {
        _serviceRepository = serviceRepository;
        _userRepository = userRepository;
        _userService = userService;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<CreateServiceResponse>> Handle(
        CreateServiceRequest request, 
        CancellationToken cancellationToken)
    {
        if (!_userService.IsAuthenticated)
            throw new UnauthorizedAccessException("User is not authenticated");
        
        
        UserModel? user = await _userRepository.GetUserById(_userService.UserId ?? "");

        if (user == null)
        {
            return Result<CreateServiceResponse>.Failure(UserErrors.NotFound(_userService.UserId ?? ""));
        }

        // if (string.IsNullOrWhiteSpace(request.Title))
        // {
        //     return Result<CreateServiceResponse>.Failure(new Error("400", "title must have at least one character"));
        // }

        var serviceModel = await _serviceRepository.AddService(new ServiceModelDto
        {
            Title = request.Title,
            Details = request.Details,
            User = user
        });

        await _unitOfWork.Save(cancellationToken);
        
        return Result<CreateServiceResponse>.Success(new  CreateServiceResponse
        {
            Service = serviceModel?.ToServiceModelDto()
        });

    }
}