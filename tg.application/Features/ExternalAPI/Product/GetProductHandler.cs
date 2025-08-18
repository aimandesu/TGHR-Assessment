using tg.application.Repository;
using tg.application.Repository.IExternalApiClientRepository;

namespace tg.application.Features.ExternalAPI.Product;

public class GetProductHandler : ICommandHandler<GetProductRequest, GetProductResponse>
{
    private readonly IExternalApiClientRepository  _externalApiClientRepository;

    public GetProductHandler(
        IExternalApiClientRepository externalApiClientRepository)
    {
        _externalApiClientRepository = externalApiClientRepository;
    }
    
    public async Task<GetProductResponse> Handle(
        GetProductRequest request, 
        CancellationToken cancellationToken)
    {
        var product = await _externalApiClientRepository.GetProduct(request.ProductId);
        
        return new GetProductResponse
        {
            Product = product
        };
    }
}