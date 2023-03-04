namespace Donation.Domain.Common.Models.Hierarchy
{
  public class AggregateRootBaseSimpleParentChild : AggregateRootBaseSimpleChild
  {
    protected readonly List<GenericValueObjectId> childIds = new();
  }
}
