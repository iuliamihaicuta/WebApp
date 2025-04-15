using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.Specifications;

public sealed class ApplicationProjectionSpec : Specification<Application, ApplicationDTO>
{
    // public ApplicationProjectionSpec(Guid? userId = null, Guid? projectId = null)
    // {
    //     Query.Include(a => a.Project)
    //         .Include(a => a.User);
    //
    //     Query.Select(a => new ApplicationDTO
    //     {
    //         Id = a.Id,
    //         UserId = a.UserId,
    //         UserName = a.User.Name,
    //         ProjectId = a.ProjectId,
    //         ProjectTitle = a.Project.Title,
    //         Status = a.Status
    //     });
    //
    //     if (userId.HasValue)
    //         Query.Where(a => a.UserId == userId.Value);
    //
    //     if (projectId.HasValue)
    //         Query.Where(a => a.ProjectId == projectId.Value);
    // }
    
    public ApplicationProjectionSpec(string? search = null)
    {
        Query.Include(a => a.Project)
            .Include(a => a.User);

        Query.Select(a => new ApplicationDTO
        {
            Id = a.Id,
            UserId = a.UserId,
            UserName = a.User.Name,
            ProjectId = a.ProjectId,
            ProjectTitle = a.Project.Title,
            Status = a.Status
        });

        if (!string.IsNullOrWhiteSpace(search))
        {
            var searchExpr = $"%{search.Trim().Replace(" ", "%")}%";
            Query.Where(a =>
                EF.Functions.ILike(a.User.Name, searchExpr) ||
                EF.Functions.ILike(a.Project.Title, searchExpr));
        }
    }

    public ApplicationProjectionSpec(Guid id, IdEnum idEnum)
    {
        switch (idEnum)
        {
            case IdEnum.UserId:
                Query.Where(a => a.Id == id);
                break;
            case IdEnum.ProjectId:
                Query.Where(a => a.ProjectId == id);
                break;
            case IdEnum.OrganizationId:
                Query.Where(a => a.Id == id);
                break;
            case IdEnum.ApplicationId:
                Query.Where(a => a.Id == id);
                break;
        }
        
        Query.Select(a => new ApplicationDTO
        {
            Id = a.Id,
            UserId = a.UserId,
            UserName = a.User.Name,
            ProjectId = a.ProjectId,
            ProjectTitle = a.Project.Title,
            Status = a.Status
        });
    }

}
