using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Entities;


namespace MobyLabWebProgramming.Core.Specifications;

public sealed class NotificationProjectionSpec : Specification<Notification, NotificationDTO>
{
    public NotificationProjectionSpec(Guid userId)
    {
        Query.Where(n => n.UserId == userId);
        
        Query.Select((Notification n) => new NotificationDTO
            {
                Id = n.Id,
                Message = n.Message,
                IsRead = n.IsRead,
                CreatedAt = n.CreatedAt
            })
            .OrderByDescending(n => n.CreatedAt);
    }
}
