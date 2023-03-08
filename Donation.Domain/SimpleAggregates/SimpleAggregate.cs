using Donation.Domain.Common.Models;
using Donation.Domain.SimpleAggregate;

namespace Donation.Domain.SimpleAggregates
{
  public class SimpleAggregate : AggregateRoot<SimpleValueObject>
  {
    public string Title { get; private set; }
    public string Description { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    protected SimpleAggregate(
        SimpleValueObject id,
        string title,
        string description)
        : base(id)
    {
      Title = title;
      Description = description;
    }

    public static SimpleAggregate Create(
        string title,
        string description)
    {
      return new(
          SimpleValueObject.CreateUnique(),
          title,
          description);
    }

    // Private Constructor is Required for EF Core
#pragma warning disable CS8618
    protected SimpleAggregate() { }
#pragma warning restore CS8618
  }
}