using MobyLabWebProgramming.Core.Entities;
using Ardalis.Specification;

namespace MobyLabWebProgramming.Core.Specifications;

public sealed class ApplicationSpec : Specification<Application>
{
    public ApplicationSpec(Guid id) => Query.Where(a => a.Id == id);

    public ApplicationSpec(Guid userId, bool byUser) =>
        Query.Where(a => a.UserId == userId);

    public ApplicationSpec(Guid projectId, bool byProject, bool dummy = true) =>
        Query.Where(a => a.ProjectId == projectId);
}