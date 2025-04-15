namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces;

using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;

public interface IOrganizationService
{
    Task<ServiceResponse<OrganizationDTO>> GetOrganization(Guid id, CancellationToken cancellationToken = default);
    Task<ServiceResponse<PagedResponse<OrganizationDTO>>> GetOrganizations(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default);
    Task<ServiceResponse> AddOrganization(OrganizationAddDTO organization, UserDTO? requestingUser = null, CancellationToken cancellationToken = default);
    Task<ServiceResponse> UpdateOrganization(OrganizationUpdateDTO organization, UserDTO? requestingUser = null, CancellationToken cancellationToken = default);
    Task<ServiceResponse> DeleteOrganization(Guid id, CancellationToken cancellationToken = default);
    Task<ServiceResponse<OrganizationDetailsDTO>> GetOrganizationProject(Guid id, CancellationToken cancellationToken = default);
}
