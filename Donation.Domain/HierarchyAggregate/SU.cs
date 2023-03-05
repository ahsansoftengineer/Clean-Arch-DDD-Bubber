using Donation.Domain.Common.Models;
using Donation.Domain.HierarchyAggregate.ValueObjects;
namespace Donation.Domain.HierarchyAggregate
{
  public sealed class SU : AggregateRoot<SUId>
  {
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public OUId OUId { get; private set; }

    private SU(
      SUId id,
      OUId parentId,
      string title,
      string description)
      : base(id)
    {
      OUId = parentId;
      Title = title;
      Description = description;
    }

    public static SU Create(
      OUId parentId,
      string title,
      string description)
    {
      return new(
        SUId.CreateUnique(),
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