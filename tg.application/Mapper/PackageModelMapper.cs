using tg.application.Dtos;
using tg.domain.Entities;

namespace tg.application.Mapper;

public static class PackageModelMapper
{
    public static PackageModelDto  ToPackageModelDto(this PackageModel packageModel)
    {
        return new PackageModelDto
        {
            Id = packageModel.Id,
            Price = packageModel.Price,
            PackageOffer = packageModel.PackageOffer,
            ServiceId = packageModel.ServiceId,
        };
    }
}