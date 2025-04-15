using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;

namespace MobyLabWebProgramming.Infrastructure.Services.Interfaces;

public interface IUserProfileService
{
    Task<ServiceResponse<UserProfileDTO>> GetById(Guid id, CancellationToken cancellationToken = default);
    Task<ServiceResponse<UserProfileDTO>> GetByUserId(Guid userId, CancellationToken cancellationToken = default);
    Task<ServiceResponse> Create(UserProfileAddDTO dto, CancellationToken cancellationToken = default);
    Task<ServiceResponse> Update(Guid id, UserProfileAddDTO dto, CancellationToken cancellationToken = default);
    Task<ServiceResponse> Delete(Guid id, CancellationToken cancellationToken = default);
}
