namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class ProjectAddDTO
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; } = null!;
    public Guid OrganizationId { get; set; }
}