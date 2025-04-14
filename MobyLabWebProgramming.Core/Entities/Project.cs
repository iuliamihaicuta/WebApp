namespace MobyLabWebProgramming.Core.Entities;

public class Project : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; } = null!;
    
    public Guid OrganizationId { get; set; }
    public Organization Organization { get; set; } = null!;
    
    public ICollection<Application> Applications { get; set; }
}