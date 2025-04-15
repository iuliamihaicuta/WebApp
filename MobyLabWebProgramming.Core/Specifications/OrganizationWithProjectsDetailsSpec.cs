using Ardalis.Specification;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Specifications;

public sealed class OrganizationWithProjectsDetailsSpec : Specification<Organization, OrganizationDetailsDTO>
{
    public OrganizationWithProjectsDetailsSpec(Guid id)
    {
        Query
            .Where(o => o.Id == id)
            .Include(o => o.Projects);
        Query.Select(o => new OrganizationDetailsDTO
            {
                Id = o.Id,
                Name = o.Name,
                Projects = o.Projects.Select(p => new ProjectDTO
                {
                    Id = p.Id,
                    Title = p.Title,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    Location = p.Location
                }).ToList()
            });
    }
}