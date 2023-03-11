using Donation.Domain.SimpleAggregates;

namespace Donation.Domain.HierarchyAggregate
{
  public sealed class Org : SimpleAggregate
  {
    private readonly List<Systemz> systemz = new();
    public IReadOnlyList<Systemz> Systemz => systemz.AsReadOnly();

    protected Org(
    SimpleValueObject id,
    string title,
    string description)
    : base(id, title, description)
    {
    }

    public static Org Create(
        string title,
        string description)
    {
      return new(
          SimpleValueObject.CreateUnique(),
          title,
          description);
    }

#pragma warning disable CS8618
    private Org() { }
#pragma warning restore CS8618
  }
}