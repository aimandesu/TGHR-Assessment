using tg.application.Dtos;
using tg.domain.Entities;

namespace tg.application.Mapper;

public static class FollowerModelMapper
{
    public static FollowerModelDto ToFollowerModelDto(this FollowerModel followerModel)
    {
        return new FollowerModelDto
        {
            Id = followerModel.Id,
            Follower = followerModel.Follower?.ToFollowerUserModelDto(),
            DateFollowed = followerModel.DateFollowed,
        };
    }
}