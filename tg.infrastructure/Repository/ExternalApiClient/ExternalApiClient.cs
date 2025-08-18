using System.Text.Json;
using tg.application.Repository.IExternalApiClientRepository;
using tg.domain.Entities.ExternalEntities;

namespace tg.infrastructure.Repository.ExternalApiClient;

public class ExternalApiClient : IExternalApiClientRepository
{
    private readonly HttpClient _httpClient;

    public ExternalApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ProductModel?> GetProduct(int productId)
    {
        var res = await _httpClient.GetAsync($"products/{productId}");
        res.EnsureSuccessStatusCode();
        await using var stream = await res.Content.ReadAsStreamAsync();
        var productModel = await JsonSerializer.DeserializeAsync<ProductModel>(stream);
        return productModel;
    }
}