namespace tg.domain.Entities;

public class ServiceModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty; // The freelancer offering this service
    public UserModel? User { get; set; }
    public List<PackageModel> Packages { get; set; } = [];
}