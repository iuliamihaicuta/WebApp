using Ardalis.Specification;
using MobyLabWebProgramming.Core.Entities;
using MobyLabWebProgramming.Core.DataTransferObjects;

namespace MobyLabWebProgramming.Core.Specifications;

public sealed class UserWithProfileProjectionSpec : Specification<User, UserDTO>
{
    public UserWithProfileProjectionSpec(Guid id)
    {
        Query
            .Where(u => u.Id == id)
            .Include(u => u.Profile); // Include Profile to load the related entity
        
        Query.Select(u => new UserDTO
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email,
            Role = u.Role,
            Profile = u.Profile != null ? new UserProfileDTO
            {
                Address = u.Profile.Address,
                PhoneNumber = u.Profile.PhoneNumber,
                BirthDate = u.Profile.BirthDate,
                Bio = u.Profile.Bio
            } : null // Handle null profile
        });
    }
}