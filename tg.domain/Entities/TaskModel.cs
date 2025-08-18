using tg.domain.Enum;

namespace tg.domain.Entities;

public class TaskModel
{
    public Guid Id { get; set; }
    
    public string? ClientId { get; set; } // Foreign Key, if from request
    public UserModel? Client { get; set; }
    //
    // public Guid FreelancerId { get; set; } // Foreign Key, if from our packages
    // public UserModel? Freelancer { get; set; }
    
    public Guid PackageId { get; set; } // Link to the specific package purchased
    public PackageModel? Package { get; set; }
    
    public ProgressStatus Progress { get; set; } = ProgressStatus.InProgress;
    
    public PaymentModel? Payment { get; set; } // One-to-one relationship
    public ReviewModel? Review { get; set; } // One-to-one relationship
}