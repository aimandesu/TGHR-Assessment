using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tg.domain.Entities;

public class FollowerModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    // Foreign key for the user being followed
    public string UserId { get; set; } = string.Empty;
    public UserModel? User { get; set; }

    // Foreign key for the follower
    public string FollowerId { get; set; } = string.Empty;
    public UserModel? Follower { get; set; }

    public DateTime DateFollowed { get; set; } = DateTime.UtcNow;
}