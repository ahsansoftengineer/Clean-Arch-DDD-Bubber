using Donation.Domain.Common.Models;
using Donation.Domain.HierarchyAggregate.ValueObjects;

namespace Donation.Domain.HierarchyAggregate
{
  public sealed class OU : AggregateRoot<OUId>
  {
    public string Title { get; private set; }
    public string Description { get; private set; }
    public LEId LEId { get; private set; }

    private readonly List<SUId> suids = new();
    public IReadOnlyList<SUId> SUIds => suids.AsReadOnly();
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private OU(
        OUId id,
        LEId parentId,
        string title,
        string description)
        : base(id)
    {
      LEId = parentId;
      Title = title;
      Description = description;
    }

    public static OU Create(
        LEId parentId,
        string title,
        string description)
    {
      return new(
          OUId.CreateUnique(),
          parentId,
          title,
          description);
    }

    // Private Constructor is Required for EF Core
#pragma warning disable CS8618
    private OU() { }
#pragma warning restore CS8618
  }
}