using tg.domain.Entities;

namespace tg.application.Dtos;

public class FollowerModelDto
{
    public Guid Id { get; set; }
    public FollowerUserModelDto? Follower { get; set; }
    public DateTime DateFollowed { get; set; } = DateTime.UtcNow;
}