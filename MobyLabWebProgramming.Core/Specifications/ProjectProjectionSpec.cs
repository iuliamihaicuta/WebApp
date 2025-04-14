using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Specifications;

public sealed class ProjectProjectionSpec : Specification<Project, ProjectDTO>
{
    public ProjectProjectionSpec(string? search = null)
    {
        Query.Select(p => new ProjectDTO
            {
                Id = p.Id,
                Title = p.Title,
                Location = p.Location,
                StartDate = p.StartDate,
                EndDate = p.EndDate
            })
            .OrderByDescending(p => p.CreatedAt);

        if (!string.IsNullOrWhiteSpace(search))
        {
            var searchExpr = $"%{search.Trim().Replace(" ", "%")}%";
            Query.Where(p => EF.Functions.ILike(p.Title, searchExpr));
        }
    }
    
    public ProjectProjectionSpec(Guid id)
    {
        Query.Where(p => p.Id == id);
        Query.Select(p => new ProjectDTO
        {
            Id = p.Id, 
            Title = p.Title, 
            Location = p.Location, 
            StartDate = p.StartDate, 
            EndDate = p.EndDate
            });
    }

}
