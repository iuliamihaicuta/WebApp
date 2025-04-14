namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class NotificationDTO
{
    public Guid Id { get; set; }
    public string Message { get; set; } = null!;
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }
}