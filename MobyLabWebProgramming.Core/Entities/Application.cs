using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Entities;

public class Application : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    
    public Guid ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    
    public ApplicationStatusEnum Status { get; set; }
}