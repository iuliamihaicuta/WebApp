namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class UserProfileAddDTO
{
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Bio { get; set; }
    public Guid UserId { get; set; }
}