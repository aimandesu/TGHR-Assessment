namespace tg.domain.Entities;

public class PackageModel
{
    public Guid Id { get; set; }
    public double Price { get; set; }
    public string PackageOffer { get; set; } = string.Empty;
    public Guid ServiceId { get; set; }
    public ServiceModel? Service { get; set; }
}