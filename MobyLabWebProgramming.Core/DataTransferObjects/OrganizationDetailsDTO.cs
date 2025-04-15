using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class OrganizationDetailsDTO : OrganizationDTO
{
    public List<ProjectDTO> Projects { get; set; } = new();
}