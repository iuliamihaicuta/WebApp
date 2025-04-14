using MobyLabWebProgramming.Core.Entities;
using Ardalis.Specification;

namespace MobyLabWebProgramming.Core.Specifications;

public sealed class OrganizationSpec : Specification<Organization>
{
    public OrganizationSpec(Guid id)
    {
        Query.Where(o => o.Id == id);
    }

    public OrganizationSpec(string name)
    {
        Query.Where(o => o.Name == name);
    }
}
