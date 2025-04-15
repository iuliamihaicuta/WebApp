using Ardalis.Specification;
using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.Specifications;

public sealed class UserProfileSpec : Specification<UserProfile>
{
    public UserProfileSpec(Guid id, bool byUserId = false)
    {
        if (byUserId)
        {
            Query.Where(p => p.UserId == id);
        }
        else
        {
            Query.Where(p => p.Id == id);
        }

        Query.Include(p => p.User);
    }
}