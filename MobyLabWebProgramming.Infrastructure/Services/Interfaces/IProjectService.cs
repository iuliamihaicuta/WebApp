using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces;

public interface IProjectService
{
    Task<ServiceResponse<ProjectDTO>> GetProject(Guid id, CancellationToken cancellationToken = default);
    Task<ServiceResponse<PagedResponse<ProjectDTO>>> GetProjects(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);
    Task<ServiceResponse<int>> GetProjectCount(CancellationToken cancellationToken = default);
    Task<ServiceResponse> AddProject(ProjectAddDTO project, UserDTO? requestingUser = null, CancellationToken cancellationToken = default);
    Task<ServiceResponse> UpdateProject(ProjectUpdateDTO project, UserDTO? requestingUser = null, CancellationToken cancellationToken = default);
    Task<ServiceResponse> DeleteProject(Guid id, UserDTO? requestingUser = null, CancellationToken cancellationToken = default);
}