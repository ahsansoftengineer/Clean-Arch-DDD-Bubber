using Donation.Domain.Common.Models;
using Donation.Domain.HierarchyAggregate.ValueObjects;

namespace Donation.Domain.HierarchyAggregate
{
  public sealed class LE : AggregateRoot<LEId>
  {
    public string Title { get; private set; }
    public string Description { get; private set; }
    public BGId BGId { get; private set; }

    private readonly List<OUId> ouids = new();
    public IReadOnlyList<OUId> OUIds => ouids.AsReadOnly();
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private LE(
        LEId id,
        BGId parentId,
        string title,
        string description)
        : base(id)
    {
      BGId = parentId;
      Title = title;
      Description = description;
    }

    public static LE Create(
        BGId parentId,
        string title,
        string description)
    {
      return new(
          LEId.CreateUnique(),
          parentId,
          title,
          description);
    }

    // Private Constructor is Required for EF Core
#pragma warning disable CS8618
    private LE() { }
#pragma warning restore CS8618
  }
}