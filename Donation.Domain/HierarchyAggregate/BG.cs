using Donation.Domain.Common.Models;
using Donation.Domain.HierarchyAggregate.ValueObjects;

namespace Donation.Domain.HierarchyAggregate
{
  public sealed class BG : AggregateRoot<BGId>
  {
    public string Title { get; private set; }
    public string Description { get; private set; }

    private readonly List<LE> les = new();
    public IReadOnlyList<LE> LEs => les.AsReadOnly();
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private BG(
        BGId id,
        string title,
        string description)
        : base(id)
    {
      Title = title;
      Description = description;
    }

    public static BG Create(
        string title,
        string description)
    {
      return new(
          BGId.CreateUnique(),
          title,
          description);
    }

    // Private Constructor is Required for EF Core
#pragma warning disable CS8618
    private BG() { }
#pragma warning restore CS8618
  }
}