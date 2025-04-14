using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class ApplicationDTO
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public string ProjectTitle { get; set; } = null!;

    public Guid UserId { get; set; }
    public string UserName { get; set; } = null!;

    public ApplicationStatusEnum Status { get; set; }
}