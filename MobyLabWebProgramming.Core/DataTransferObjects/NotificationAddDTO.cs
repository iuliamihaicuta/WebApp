namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class NotificationAddDTO
{
    public Guid UserId { get; set; }
    public string Message { get; set; } = null!;
}