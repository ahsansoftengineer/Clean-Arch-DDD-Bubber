namespace Donation.Domain.Common.Models.Hierarchy
{
  public class AggregateRootBaseSimpleParent : AggregateRootBase
  {
    protected readonly List<GenericValueObjectId> childIds = new();
    public IReadOnlyList<GenericValueObjectId> ChildIds => childIds.AsReadOnly();
#pragma warning disable CS8618
    protected AggregateRootBaseSimpleParent() { }
#pragma warning restore CS8618
  }
}
