namespace tg.application.Dtos;

public class PackageModelDto
{
    public Guid Id { get; set; }
    public double Price { get; set; }
    public string PackageOffer { get; set; } = string.Empty;
    public Guid ServiceId { get; set; }
}