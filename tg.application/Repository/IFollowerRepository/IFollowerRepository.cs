using tg.domain.Entities;

namespace tg.application.Repository.IFollowerRepository;

public interface IFollowerRepository
{
    Task<UserModel?> FollowUser(UserModel user);
    Task<List<FollowerModel>> GetFollowers(string userId);
}