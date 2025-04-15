namespace MobyLabWebProgramming.Core.Entities;

public class UserProfile : BaseEntity
{
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Bio { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
}