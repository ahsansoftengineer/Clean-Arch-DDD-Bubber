using Donation.Domain.SimpleAggregate;

namespace Donation.Domain.SimpleAggregates
{
  public class SimpleAggregateChild : SimpleAggregate
  {
    public SimpleValueObject ParentId { get; private set; }

    protected SimpleAggregateChild(
        SimpleValueObject id,
        SimpleValueObject parentId,
        string title,
        string description)
        : base(id, title, description)
    {
      ParentId = parentId;
    }

    public static SimpleAggregateChild Create(
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
    protected SimpleAggregateChild() { }
#pragma warning restore CS8618
  }
}