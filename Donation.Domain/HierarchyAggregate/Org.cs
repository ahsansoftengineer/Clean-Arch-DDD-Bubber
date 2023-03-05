using Donation.Domain.Common.Models;
using Donation.Domain.HierarchyAggregate.ValueObjects;

namespace Donation.Domain.HierarchyAggregate
{
  public sealed class Org : AggregateRoot<OrgId>
  {
    public string Title { get; private set; }
    public string Description { get; private set; }

    private readonly List<Systemz> systemz = new();
    public IReadOnlyList<Systemz> Systemz => systemz.AsReadOnly();
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Org(
        OrgId id,
        string title,
        string description)
        : base(id)
    {
      Title = title;
      Description = description;
    }

    public static Org Create(
        string title,
        string description)
    {
      return new(
          OrgId.CreateUnique(),
          title,
          description);
    }

    // Private Constructor is Required for EF Core
#pragma warning disable CS8618
    private Org() { }
#pragma warning restore CS8618
  }
}