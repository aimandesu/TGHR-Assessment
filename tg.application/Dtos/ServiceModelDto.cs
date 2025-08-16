using tg.domain.Entities;

namespace tg.application.Dtos;

public class ServiceModelDto
{
    public string Title { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public UserModel? User { get; set; }
}