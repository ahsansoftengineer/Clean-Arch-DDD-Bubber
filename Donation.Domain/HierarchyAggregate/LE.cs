using Donation.Domain.SimpleAggregates;

namespace Donation.Domain.HierarchyAggregate
{
  public sealed class LE : SimpleAggregate
  {
    public SimpleValueObject BGId { get; private set; }

    private readonly List<OU> ous = new();
    public IReadOnlyList<OU> OUs => ous.AsReadOnly();

    private LE(
        SimpleValueObject id,
        SimpleValueObject parentId,
        string title,
        string description)
        : base(id, title, description)
    {
      BGId = parentId;
    }

    public static LE Create(
        SimpleValueObject parentId,
        string title,
        string description)
    {
      return new(
          SimpleValueObject.CreateUnique(),
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