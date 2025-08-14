using tg.application.Common;
using tg.application.Features.Following;
using tg.application.Mapper;
using tg.application.Repository;
using tg.application.Repository.IFollowerRepository;
using tg.application.Repository.IUserRepository;
using tg.domain.Entities;

namespace tg.application.Features.Follower.Follow;

public class CreateFollowHandler : ICommandHandler<CreateFollowRequest, Result<CreateFollowResponse>>
{
    private readonly IUserRepository  _userRepository;
    private readonly IFollowerRepository _followerRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserService _userService;

    public CreateFollowHandler(
        IUserRepository userRepository,
        IFollowerRepository followerRepository,
        IUnitOfWork unitOfWork,
        IUserService userService)
    {
        _userRepository = userRepository;
        _followerRepository = followerRepository;
        _unitOfWork = unitOfWork;
        _userService = userService;
    }
    
    public async Task<Result<CreateFollowResponse>> Handle(
        CreateFollowRequest request, 
        CancellationToken cancellationToken)
    {
        if (!_userService.IsAuthenticated)
            throw new UnauthorizedAccessException("User is not authenticated");
        
        //find if user to follow exits
        UserModel? user = await _userRepository.GetUserById(request.UserId);

        if (user == null)
        {
            return Result<CreateFollowResponse>.Failure(UserErrors.NotFound(request.UserId));
        }
        
        //now we do to follow the user 
        var userFollow = await _followerRepository.FollowUser(user);
        
        await _unitOfWork.Save(cancellationToken);

        return Result<CreateFollowResponse>.Success(new CreateFollowResponse
        {
            User = userFollow?.ToUserModelDto()
        });
    }
}