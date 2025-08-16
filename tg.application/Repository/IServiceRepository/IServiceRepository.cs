using tg.application.Dtos;
using tg.domain.Entities;

namespace tg.application.Repository.IServiceRepository;

public interface IServiceRepository
{
    Task<ServiceModel?> AddService(ServiceModelDto model);
    Task<ServiceModel?> DeleteService(Guid serviceId, string userId);
}