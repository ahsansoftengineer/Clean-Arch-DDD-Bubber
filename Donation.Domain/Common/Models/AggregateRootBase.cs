using Donation.Domain.Common.Models;

namespace Donation.Domain.Hierarchy
{
  public class AggregateRootBase : AggregateRoot<GenericValueObjectId>
  {
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UPdatedAt { get; private set; }

    protected AggregateRootBase(
        GenericValueObjectId valueObject,
        string title,
        string description)
        : base(valueObject)
    {
      Title = title;
      Description = description;
    }

    public static AggregateRootBase Create(
      string title,
      string description)
    {
      return new(
          GenericValueObjectId.CreateUnique(),
          title,
          description);
    }

    // Private Constructor is Required for EF Core
#pragma warning disable CS8618
    protected AggregateRootBase() { }
#pragma warning restore CS8618
  }
}
