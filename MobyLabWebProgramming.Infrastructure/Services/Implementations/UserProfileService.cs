using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.Errors;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Core.Specifications;
using MobyLabWebProgramming.Infrastructure.Database;
using MobyLabWebProgramming.Infrastructure.Repositories.Interfaces;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;

namespace MobyLabWebProgramming.Infrastructure.Services.Implementations;

public class UserProfileService(IRepository<WebAppDatabaseContext> repository) : IUserProfileService
{
    public async Task<ServiceResponse<UserProfileDTO>> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAsync(new UserProfileProjectionSpec(id), cancellationToken);
        return result != null
            ? ServiceResponse.ForSuccess(result)
            : ServiceResponse.FromError<UserProfileDTO>(CommonErrors.UserProfileNotFound);
    }

    public async Task<ServiceResponse<UserProfileDTO>> GetByUserId(Guid userId, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAsync(new UserProfileByUserIdProjectionSpec(userId), cancellationToken);
        return result != null
            ? ServiceResponse.ForSuccess(result)
            : ServiceResponse.FromError<UserProfileDTO>(CommonErrors.UserProfileNotFound);
    }

    public async Task<ServiceResponse> Create(UserProfileAddDTO dto, CancellationToken cancellationToken = default)
    {
        var entity = new UserProfile
        {
            Address = dto.Address,
            PhoneNumber = dto.PhoneNumber,
            BirthDate = dto.BirthDate,
            Bio = dto.Bio,
            UserId = dto.UserId
        };

        await repository.AddAsync(entity, cancellationToken);
        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> Update(Guid id, UserProfileAddDTO dto, CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(new UserProfileSpec(id), cancellationToken);
        if (entity == null)
        {
            return ServiceResponse.FromError(CommonErrors.UserProfileNotFound);
        }

        entity.Address = dto.Address ?? entity.Address;
        entity.PhoneNumber = dto.PhoneNumber ?? entity.PhoneNumber;
        entity.BirthDate = dto.BirthDate ?? entity.BirthDate;
        entity.Bio = dto.Bio ?? entity.Bio;

        await repository.UpdateAsync(entity, cancellationToken);
        return ServiceResponse.ForSuccess();
    }

    public async Task<ServiceResponse> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        await repository.DeleteAsync<UserProfile>(id, cancellationToken);
        return ServiceResponse.ForSuccess();
    }
}
