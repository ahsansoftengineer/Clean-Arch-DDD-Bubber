namespace Donation.Domain.Common.Models.Hierarchy
{
  public class AggregateRootBaseSimpleParentChild : AggregateRootBaseSimpleChild
  {
    protected readonly List<GenericValueObjectId> childIds = new();
    public IReadOnlyList<GenericValueObjectId> ChildIds => childIds.AsReadOnly();
#pragma warning disable CS8618
    protected AggregateRootBaseSimpleParentChild() { }
#pragma warning restore CS8618
  }
}
