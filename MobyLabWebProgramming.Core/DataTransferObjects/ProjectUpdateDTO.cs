using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public record ProjectUpdateDTO(
    Guid Id,
    string? Name = null,
    string? Title = null,
    string? Description = null,
    string? Location = null,
    DateTime? StartDate = null,
    DateTime? EndDate = null
);