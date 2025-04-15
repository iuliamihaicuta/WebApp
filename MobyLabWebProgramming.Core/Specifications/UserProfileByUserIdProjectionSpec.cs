using Ardalis.Specification;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Specifications;

public sealed class UserProfileByUserIdProjectionSpec : Specification<UserProfile, UserProfileDTO>
{
    public UserProfileByUserIdProjectionSpec(Guid userId)
    {
        Query.Where(up => up.UserId == userId);
            Query.Select(up => new UserProfileDTO
            {
                Id = up.Id,
                Address = up.Address,
                PhoneNumber = up.PhoneNumber,
                BirthDate = up.BirthDate,
                Bio = up.Bio,
                UserId = up.UserId
            });
    }
}