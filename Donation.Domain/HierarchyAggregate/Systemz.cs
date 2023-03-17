using Donation.Domain.SimpleAggregates;

namespace Donation.Domain.HierarchyAggregate
{
  public sealed class Systemz : SimpleAggregate
  {
    public SimpleValueObject OrgId { get; private set; }
    public Org Org { get; private set; }

    private Systemz(
        SimpleValueObject id,
        SimpleValueObject parentId,
        string title,
        string description)
        : base(id, title, description)
    {
      OrgId = parentId;
    }

    public static Systemz Create(
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
    private Systemz() { }
#pragma warning restore CS8618
  }
}