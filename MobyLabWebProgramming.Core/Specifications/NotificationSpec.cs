using MobyLabWebProgramming.Core.Entities;
using Ardalis.Specification;

namespace MobyLabWebProgramming.Core.Specifications;

public sealed class NotificationSpec : Specification<Notification>
{
    public NotificationSpec(Guid id) => Query.Where(n => n.Id == id);

    public NotificationSpec(Guid userId, bool byUser) =>
        Query.Where(n => n.UserId == userId);
}
