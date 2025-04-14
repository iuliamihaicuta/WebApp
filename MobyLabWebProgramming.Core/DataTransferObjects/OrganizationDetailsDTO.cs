using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class OrganizationDetailsDTO : OrganizationDTO
{
    public ICollection<Project> Projects { get; set; }
}