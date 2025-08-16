using tg.domain.Enum;

namespace tg.domain.Entities;

public class PaymentModel
{
    public Guid Id { get; set; }
    
    public double Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentStatus Status { get; set; } = PaymentStatus.Initiated;
    
    public Guid TaskId { get; set; } // Foreign Key to Task
    public TaskModel? Task { get; set; }
}