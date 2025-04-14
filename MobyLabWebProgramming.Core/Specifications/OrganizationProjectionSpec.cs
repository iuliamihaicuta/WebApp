using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Specifications;

public sealed class OrganizationProjectionSpec : Specification<Organization, OrganizationDTO>
{
    public OrganizationProjectionSpec(Guid id)
    {
        Query.Where(o => o.Id == id);
        
        Query.Select(o => new OrganizationDTO
            {
                Id = o.Id,
                Name = o.Name
            });
    }

    public OrganizationProjectionSpec(string? search = null)
    {
        if (!string.IsNullOrWhiteSpace(search))
        {
            Query.Where(o => o.Name.Contains(search));
        }

        Query.Select(o => new OrganizationDTO
        {
            Id = o.Id,
            Name = o.Name
        });
    }
}
