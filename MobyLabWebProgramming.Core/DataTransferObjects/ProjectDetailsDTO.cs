using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class ProjectDetailsDTO : ProjectDTO
{
    public string Description { get; set; } = null!;
    public OrganizationDTO Organization { get; set; } = null!;
    public ICollection<Application> Applications { get; set; }
}