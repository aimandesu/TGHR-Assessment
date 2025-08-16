using tg.application.Dtos;
using tg.domain.Entities;

namespace tg.application.Mapper;

public static class ServiceModelMapper
{
    public static ServiceModelDto ToServiceModelDto(this ServiceModel serviceModel)
    {
        return new ServiceModelDto
        {
            Title = serviceModel.Title,
            Details = serviceModel.Details,
            User = serviceModel.User
        };
    }
}