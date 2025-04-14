using MobyLabWebProgramming.Core.Enums;

namespace MobyLabWebProgramming.Core.DataTransferObjects;

public record ApplicationUpdateDTO(Guid Id, ApplicationStatusEnum Status);
