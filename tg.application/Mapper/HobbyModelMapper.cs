using tg.application.Dtos;
using tg.domain.Entities;

namespace tg.application.Mapper;

public static class HobbyModelMapper
{
    public static HobbyModelDto ToHobbyModelDto(this HobbyModel hobbyModel)
    {
        return new HobbyModelDto
        {
            Id = hobbyModel.Id,
            HobbyName = hobbyModel.HobbyName,
        };
    }
}