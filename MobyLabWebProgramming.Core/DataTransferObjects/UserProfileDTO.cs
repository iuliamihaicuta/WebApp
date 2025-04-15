namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class UserProfileDTO
{
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Bio { get; set; }
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
}