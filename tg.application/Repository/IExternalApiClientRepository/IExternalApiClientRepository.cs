using tg.domain.Entities.ExternalEntities;

namespace tg.application.Repository.IExternalApiClientRepository;

public interface IExternalApiClientRepository
{
    Task<ProductModel?> GetProduct(int productId);
}