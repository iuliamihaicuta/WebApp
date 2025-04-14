namespace MobyLabWebProgramming.Core.Entities;

public class Organization : BaseEntity
{
    public string Name { get; set; } = null!;
    
    public ICollection<Project> Projects { get; set; }
    public ICollection<User> Admins { get; set; }
}