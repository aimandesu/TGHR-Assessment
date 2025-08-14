using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using tg.application.Repository.IFollowerRepository;
using tg.application.Repository.IUserRepository;
using tg.domain.Entities;
using tg.infrastructure.Data;

namespace tg.infrastructure.Repository.FollowerRepository;

public class FollowerRepository : IFollowerRepository
{
    
    private readonly ApplicationDbContext  _context;
    private readonly IUserService  _userService;
    private readonly IUserRepository _userRepository;

    
    public FollowerRepository(
        ApplicationDbContext context,
        IUserService userService,
        IUserRepository userRepository)
    {
        _context = context;
        _userService = userService;
        _userRepository = userRepository;
    }
    
    public async Task<UserModel?> FollowUser(UserModel user) //user we want to follow its id
    {
     
        UserModel? Me = await _userRepository.GetUserById(_userService.UserId ?? "");
       
       await _context.Followers.AddAsync( new FollowerModel
       {
           UserId = user.Id,
           User = user,
           FollowerId = _userService.UserId ?? "", //me
           Follower = Me //me
       });
       
       return user;
       
    }

    public async Task<List<FollowerModel>> GetFollowers(string userId)
    {
        // var user = await _context.Users //The one doesnt work
        //     .Include(u => u.Followers) // make sure EF loads Followers
        //     .FirstOrDefaultAsync(u => u.Id == userId);
        
        return await _context.Followers
            .Where(f => f.UserId == userId)
            .Include(f => f.Follower)      // <--- load the follower user object
            // .OrderByDescending(f => f.DateFollowed)
            .ToListAsync();

        // return user?.Followers ?? new List<FollowerModel>();
    }

}