using Donation.Domain.SimpleAggregates;

namespace Donation.Domain.HierarchyAggregate
{
  public sealed class SU : SimpleAggregate
  {
    public SimpleValueObject OUId { get; private set; }

    private SU(
        SimpleValueObject id,
        SimpleValueObject parentId,
        string title,
        string description)
        : base(id, title, description)
    {
      OUId = parentId;
    }

    public static SU Create(
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
    private SU() { }
#pragma warning restore CS8618
  }
}