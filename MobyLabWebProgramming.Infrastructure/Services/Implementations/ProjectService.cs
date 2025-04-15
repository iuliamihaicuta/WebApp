using System.Net;
using MobyLabWebProgramming.Core.Constants;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Errors;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Core.Specifications;
using MobyLabWebProgramming.Infrastructure.Database;
using MobyLabWebProgramming.Infrastructure.Repositories.Interfaces;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;

namespace MobyLabWebProgramming.Infrastructure.Services.Implementations;

public class ProjectService(IRepository<WebAppDatabaseContext> repository) : IProjectService
{
    public async Task<ServiceResponse<ProjectDTO>> GetProject(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAsync(new ProjectProjectionSpec(id), cancellationToken);
        return result != null ?
            ServiceResponse.ForSuccess(result) :
            ServiceResponse.FromError<ProjectDTO>(CommonErrors.ProjectNotFound);
    }

    public async Task<ServiceResponse<PagedResponse<ProjectDTO>>> GetProjects(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
    {
        var result = await repository.PageAsync(pagination, new ProjectProjectionSpec(pagination.Search), cancellationToken);
        return ServiceResponse.ForSuccess(result);
    }

    public async Task<ServiceResponse<int>> GetProjectCount(CancellationToken cancellationToken = default) =>
        ServiceResponse.ForSuccess(await repository.GetCountAsync<Project>(cancellationToken));

    public async Task<ServiceResponse> AddProject(ProjectAddDTO project, UserDTO? requestingUser, CancellationToken cancellationToken = default)
    {
        // TODO: Add role check or organization ownership validation if needed
        

        var entity = new Project
        {
            Title = project.Title,
            Description = project.Description,
            Location = project.Location,
            StartDate = project.StartDate,
            EndDate = project.EndDate,
            OrganizationId = project.OrganizationId
        };

        await repository.AddAsync(entity, cancellationToken);
        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> UpdateProject(ProjectUpdateDTO project, UserDTO? requestingUser, CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(new ProjectSpec(project.Id), cancellationToken);
        if (entity == null)
        {
            return ServiceResponse.FromError(CommonErrors.ProjectNotFound);
        }

        entity.Title = project.Name ?? entity.Title;
        entity.Description = project.Description ?? entity.Description;
        entity.Location = project.Location ?? entity.Location;
        entity.StartDate = project.StartDate ?? entity.StartDate;
        entity.EndDate = project.EndDate ?? entity.EndDate;

        await repository.UpdateAsync(entity, cancellationToken);
        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> DeleteProject(Guid id, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
    {
        await repository.DeleteAsync<Project>(id, cancellationToken);
        return ServiceResponse.ForSuccess();
    }
}
