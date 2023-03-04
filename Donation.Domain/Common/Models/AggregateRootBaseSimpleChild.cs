using System.ComponentModel.DataAnnotations.Schema;

namespace Donation.Domain.Common.Models.Hierarchy
{
  public class AggregateRootBaseSimpleChild : AggregateRootBase
  {
    [NotMapped]
    public GenericValueObjectId ParentId { get; }
    protected AggregateRootBaseSimpleChild(
        GenericValueObjectId id,
        string title,
        string description,
        GenericValueObjectId parentId
        )
        : base(id, title, description)
    {
      ParentId = parentId;
    }

    public static AggregateRootBaseSimpleChild Create(
      string title,
      string description,
      GenericValueObjectId parentId)
    {
      return new(
          GenericValueObjectId.CreateUnique(),
          title,
          description,
          parentId);
    }

    // Private Constructor is Required for EF Core
#pragma warning disable CS8618
    protected AggregateRootBaseSimpleChild() { }
#pragma warning restore CS8618
  }
}
