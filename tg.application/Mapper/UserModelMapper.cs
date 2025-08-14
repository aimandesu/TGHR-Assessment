using tg.application.Dtos;
using tg.domain.Entities;

namespace tg.application.Mapper;

public static class UserModelMapper
{
    public static UserModelDto ToUserModelDto(this UserModel user)
    {
        return new UserModelDto
        {
            Id = user.Id,
            Email = user.Email ?? string.Empty,
            Username = user.UserName ?? string.Empty,
            PhoneNumber = user.PhoneNumber ?? string.Empty,
            IsArchived = user.IsArchived,
            Skills = user.Skills.Select(s => s.ToSkillModelDto()).ToList(),
            Hobbies = user.Hobbies.Select(h => h.ToHobbyModelDto()).ToList(),
            Followers = user.Followers.Select(e => e.ToFollowerModelDto()).ToList(),
            Followings = user.Following.Select(e =>e.ToFollowerModelDto()).ToList()
        };
    }

    public static FollowerUserModelDto ToFollowerUserModelDto(this UserModel user)
    {
       return new FollowerUserModelDto
       {
           Id = user.Id,
           Username = user.UserName ?? string.Empty,
       };
    }
}