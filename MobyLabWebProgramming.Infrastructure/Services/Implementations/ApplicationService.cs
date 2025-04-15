using System.Net;
using MobyLabWebProgramming.Core.Constants;
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

public class ApplicationService(IRepository<WebAppDatabaseContext> repository) : IApplicationService
{
    public async Task<ServiceResponse<ApplicationDTO>> GetApplication(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAsync(new ApplicationProjectionSpec(id, IdEnum.ApplicationId), cancellationToken);
        return result != null ?
            ServiceResponse.ForSuccess(result) :
            ServiceResponse.FromError<ApplicationDTO>(CommonErrors.ApplicationNotFound);
    }

    public async Task<ServiceResponse<PagedResponse<ApplicationDTO>>> GetApplications(PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
    {
        var result = await repository.PageAsync(pagination, new ApplicationProjectionSpec(pagination.Search), cancellationToken);
        return ServiceResponse.ForSuccess(result);
    }
    
    public async Task<ServiceResponse<PagedResponse<ApplicationDTO>>> GetApplicationsByUser(Guid userId, PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
    {
        var result = await repository.PageAsync(pagination, new ApplicationProjectionSpec(userId, IdEnum.UserId), cancellationToken);
        return ServiceResponse.ForSuccess(result);
    }

    public async Task<ServiceResponse<PagedResponse<ApplicationDTO>>> GetApplicationsByProject(Guid projectId, PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
    {
        var result = await repository.PageAsync(pagination, new ApplicationProjectionSpec(projectId, IdEnum.ProjectId), cancellationToken);
        return ServiceResponse.ForSuccess(result);
    }

    public async Task<ServiceResponse<PagedResponse<ApplicationDTO>>> GetApplicationsByOrganization(Guid organizationId, PaginationSearchQueryParams pagination, CancellationToken cancellationToken = default)
    {
        var result = await repository.PageAsync(pagination, new ApplicationProjectionSpec(organizationId, IdEnum.OrganizationId), cancellationToken);
        return ServiceResponse.ForSuccess(result);
    }

    // public async Task<ServiceResponse> AddApplication(ApplicationAddDTO application, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
    // {
    //     var newEntity = new Application
    //     {
    //         UserId = application.UserId,
    //         ProjectId = application.ProjectId,
    //         Status = ApplicationStatusEnum.Pending,
    //         CreatedAt = DateTime.UtcNow
    //     };
    //
    //     await repository.AddAsync(newEntity, cancellationToken);
    //     return ServiceResponse.ForSuccess();
    // }
    public async Task<ServiceResponse> AddApplication(ApplicationAddDTO application, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
{
    if (requestingUser == null)
    {
        return ServiceResponse.FromError(new(HttpStatusCode.Forbidden, "User not authenticated.", ErrorCodes.CannotAdd));
    }

    var newEntity = new Application
    {
        UserId = requestingUser.Id, // 👈 Aici folosim userul curent
        ProjectId = application.ProjectId,
        Status = ApplicationStatusEnum.Pending,
        CreatedAt = DateTime.UtcNow
    };

    await repository.AddAsync(newEntity, cancellationToken);
    return ServiceResponse.ForSuccess();
}

    public async Task<ServiceResponse> UpdateApplication(ApplicationUpdateDTO application, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(new ApplicationSpec(application.Id), cancellationToken);
        if (entity == null)
            return ServiceResponse.FromError(CommonErrors.ApplicationNotFound);

        entity.Status = application.Status;

        await repository.UpdateAsync(entity, cancellationToken);
        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> DeleteApplication(Guid id, UserDTO? requestingUser = null, CancellationToken cancellationToken = default)
    {
        await repository.DeleteAsync<Application>(id, cancellationToken);
        return ServiceResponse.ForSuccess();
    }
}
