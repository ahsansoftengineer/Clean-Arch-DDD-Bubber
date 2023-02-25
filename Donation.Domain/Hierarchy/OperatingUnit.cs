using Donation.Domain.Common.Models;

namespace Donation.Domain.Hierarchy
{
  public sealed class OperatingUnit : AggregateRootBase
  {
    private readonly List<SubUnit> subUnits = new();

    public IReadOnlyList<SubUnit> SubUnits => subUnits.AsReadOnly();

    private OperatingUnit(
        GenericValueObjectId id,
        string title,
        string description,
        List<SubUnit>? subUnits)
        : base(id, title, description)
    {
      this.subUnits = subUnits;
    }

    public static OperatingUnit Create(
      string title,
      string description,
      LegalEntity legalEntity,
      List<SubUnit>? subUnits)
    {
      return new(
          GenericValueObjectId.CreateUnique(),
          title,
          description,
          subUnits);
    }

    // Private Constructor is Required for EF Core
#pragma warning disable CS8618
    private OperatingUnit():base() { }
#pragma warning restore CS8618
  }
}
