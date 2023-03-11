using Donation.Domain.SimpleAggregates;

namespace Donation.Domain.HierarchyAggregate
{
  public sealed class BG : SimpleAggregate
  {
    private readonly List<LE> les = new();
    public IReadOnlyList<LE> LEs => les.AsReadOnly();
    protected BG(
    SimpleValueObject id,
    string title,
    string description)
    : base(id, title, description)
    {
    }

    public static BG Create(
        string title,
        string description)
    {
      return new(
          SimpleValueObject.CreateUnique(),
          title,
          description);
    }

#pragma warning disable CS8618
    private BG() { }
#pragma warning restore CS8618
  }
}