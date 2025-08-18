using tg.application.Repository;

namespace tg.application.Features.ExternalAPI.Product;

public sealed record class GetProductRequest(int ProductId) : ICommand<GetProductResponse>;