using System.Net;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Enums;
using MobyLabWebProgramming.Core.Errors;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Core.Specifications;
using MobyLabWebProgramming.Infrastructure.Database;
using MobyLabWebProgramming.Infrastructure.Repositories.Interfaces;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;

namespace MobyLabWebProgramming.Infrastructure.Services.Implementations;

public class OrganizationService(IRepository<WebAppDatabaseContext> repository) : IOrganizationService
{
    public async Task<ServiceResponse<OrganizationDTO>> GetOrganization(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAsync(new OrganizationProjectionSpec(id), cancellationToken);

        return result != null
            ? ServiceResponse.ForSuccess(result)
            : ServiceResponse.FromError<OrganizationDTO>(new(HttpStatusCode.NotFound, "Organization not found", ErrorCodes.EntityNotFound));
    }
    
    

    public async Task<ServiceResponse<PagedResponse<OrganizationDTO>>> GetOrganizations(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
        
    {
        var result = await repository.PageAsync(pagination, new OrganizationProjectionSpec(pagination.Search), cancellationToken);
        return ServiceResponse.ForSuccess(result);
    }

    public async Task<ServiceResponse> AddOrganization(OrganizationAddDTO organization, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
    {
        if (requestingUser == null || requestingUser.Role != UserRoleEnum.Admin)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only admins can add organizations", ErrorCodes.CannotAdd));
        }

        var existing = await repository.GetAsync(new OrganizationSpec(organization.Name), cancellationToken);

        if (existing != null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Conflict, "Organization already exists", ErrorCodes.EntityAlreadyExists));
        }

        await repository.AddAsync(new Organization
        {
            Name = organization.Name,
            Admins = new List<User>() // ← Poți seta adminul inițial dacă vrei
        }, cancellationToken);

        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> UpdateOrganization(OrganizationUpdateDTO organization, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
    {
        if (requestingUser == null || requestingUser.Role != UserRoleEnum.Admin)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "Only admins can update organizations", ErrorCodes.CannotUpdate));
        }

        var entity = await repository.GetAsync(new OrganizationSpec(organization.Id), cancellationToken);

        if (entity == null)
        {
            return ServiceResponse.FromError(new(HttpStatusCode.NotFound, "Organization not found", ErrorCodes.EntityNotFound));
        }

        entity.Name = organization.Name ?? entity.Name;

        await repository.UpdateAsync(entity, cancellationToken);

        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> DeleteOrganization(Guid id, CancellationToken cancellationToken = default)
    {
        await repository.DeleteAsync<Organization>(id, cancellationToken);
        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse<OrganizationDetailsDTO>> GetOrganizationProject(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAsync(new OrganizationWithProjectsDetailsSpec(id), cancellationToken);

        return result != null
            ? ServiceResponse.ForSuccess(result)
            : ServiceResponse.FromError<OrganizationDetailsDTO>(new(HttpStatusCode.NotFound, "Organization not found", ErrorCodes.EntityNotFound));

    }
}
