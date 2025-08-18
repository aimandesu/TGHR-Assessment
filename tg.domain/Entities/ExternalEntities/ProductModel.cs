using System.Text.Json.Serialization;

namespace tg.domain.Entities.ExternalEntities;

public class ProductModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
    [JsonPropertyName("price")]
    public double Price { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;
    [JsonPropertyName("image")]
    public string Image { get; set; } = string.Empty;
    //rating
}