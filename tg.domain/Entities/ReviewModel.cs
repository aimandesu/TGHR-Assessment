namespace tg.domain.Entities;

public class ReviewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;

    public Guid TaskId { get; set; } // Foreign Key to Task
    public TaskModel? Task { get; set; }
    // add able to upload picture later
    
}