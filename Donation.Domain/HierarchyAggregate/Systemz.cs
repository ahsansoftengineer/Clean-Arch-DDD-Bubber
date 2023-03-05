using Donation.Domain.Common.Models;
using Donation.Domain.HierarchyAggregate.ValueObjects;
namespace Donation.Domain.HierarchyAggregate
{
  public sealed class Systemz : AggregateRoot<SystemzId>
  {
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public OrgId OrgId { get; private set; }

    private Systemz(
        SystemzId id,
        OrgId parentId,
        string title,
        string description)
        : base(id)
    {
      OrgId = parentId;
      Title = title;
      Description = description;
    }

    public static Systemz Create(
        OrgId parentId,
        string title,
        string description)
    {
      return new(
          SystemzId.CreateUnique(),
          parentId,
          title,
          description);
    }

    // Private Constructor is Required for EF Core
#pragma warning disable CS8618
    private Systemz() { }
#pragma warning restore CS8618
  }
}