namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class ProjectDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; } = null!;
}