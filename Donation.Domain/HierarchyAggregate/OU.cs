using Donation.Domain.SimpleAggregates;

namespace Donation.Domain.HierarchyAggregate
{
  public sealed class OU : SimpleAggregate
  {
    public SimpleValueObject LEId { get; private set; }

    private readonly List<SU> sus = new();
    public IReadOnlyList<SU> SUs => sus.AsReadOnly();
    private OU(
       SimpleValueObject id,
       SimpleValueObject parentId,
       string title,
       string description)
       : base(id, title, description)
    {
      LEId = parentId;
    }

    public static OU Create(
        SimpleValueObject parentId,
        string title,
        string description)
    {
      return new(
          SimpleValueObject.CreateUnique(),
          parentId,
          title,
          description);
    }

    // Private Constructor is Required for EF Core
#pragma warning disable CS8618
    private OU() { }
#pragma warning restore CS8618
  }
}