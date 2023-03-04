using System.ComponentModel.DataAnnotations.Schema;

namespace Donation.Domain.Common.Models.Hierarchy
{
  public class AggregateRootBaseSimpleParent : AggregateRootBase
  {

    [NotMapped]
    protected readonly List<GenericValueObjectId> childIds = new();
    [NotMapped]
    public IReadOnlyList<GenericValueObjectId> ChildIds => childIds.AsReadOnly();
#pragma warning disable CS8618
    protected AggregateRootBaseSimpleParent() { }
#pragma warning restore CS8618
  }
}
