using tg.application.Features.Following.GetFollower;
using tg.application.Mapper;
using tg.application.Repository;
using tg.application.Repository.IFollowerRepository;
using tg.domain.Entities;

namespace tg.application.Features.Follower.GetFollower;

public class GetFollowerHandler : ICommandHandler<GetFollowerRequest, GetFollowerResponse>
{
    private readonly IFollowerRepository _followerRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    
    public GetFollowerHandler(
        IFollowerRepository followerRepository,
        IUnitOfWork unitOfWork
        )
    {
        _followerRepository = followerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<GetFollowerResponse> Handle(GetFollowerRequest request, CancellationToken cancellationToken)
    {
        var userId = request.UserId;
        
        List<FollowerModel> followers = await _followerRepository.GetFollowers(userId);
        
        return new  GetFollowerResponse
        {
            Followers = followers.Select(e=>e.ToFollowerModelDto()).ToList()
        };
        
    }
    
}