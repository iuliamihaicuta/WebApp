using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces;

public interface IApplicationService
{
    Task<ServiceResponse<ApplicationDTO>> GetApplication(Guid id, CancellationToken cancellationToken = default);
    Task<ServiceResponse<PagedResponse<ApplicationDTO>>> GetApplications(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);
    Task<ServiceResponse> AddApplication(ApplicationAddDTO application, UserDTO? requestingUser = null, CancellationToken cancellationToken = default);
    Task<ServiceResponse> UpdateApplication(ApplicationUpdateDTO application, UserDTO? requestingUser = null, CancellationToken cancellationToken = default);
    Task<ServiceResponse> DeleteApplication(Guid id, UserDTO? requestingUser = null, CancellationToken cancellationToken = default);
    Task<ServiceResponse<PagedResponse<ApplicationDTO>>> GetApplicationsByUser(Guid userId, PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);
    Task<ServiceResponse<PagedResponse<ApplicationDTO>>> GetApplicationsByProject(Guid projectId, PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);
    Task<ServiceResponse<PagedResponse<ApplicationDTO>>> GetApplicationsByOrganization(Guid organizationId, PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);
}