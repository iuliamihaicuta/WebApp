using Ardalis.Specification;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Specifications;

public sealed class UserProfileProjectionSpec : Specification<UserProfile, UserProfileDTO>
{
    public UserProfileProjectionSpec(Guid id)
    {
        Query.Where(up => up.Id == id);
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
