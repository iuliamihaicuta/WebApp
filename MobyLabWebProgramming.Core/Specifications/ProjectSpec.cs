using MobyLabWebProgramming.Core.Entities;
using Ardalis.Specification;

namespace MobyLabWebProgramming.Core.Specifications;

public sealed class ProjectSpec : Specification<Project>
{
    public ProjectSpec(Guid id) => Query.Where(p => p.Id == id);
    
    public ProjectSpec(Guid organizationId, bool byOrganization) =>
        Query.Where(p => p.OrganizationId == organizationId);
}
