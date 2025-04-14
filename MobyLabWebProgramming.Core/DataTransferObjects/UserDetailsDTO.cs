using MobyLabWebProgramming.Core.Entities;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class UserDetailsDTO : UserDTO
{
    public ICollection<Application> Applications { get; set; } = null!;
    public ICollection<Notification> Notifications { get; set; } = null!;
}