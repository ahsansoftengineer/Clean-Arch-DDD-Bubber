using Donation.Domain.Common.Models;

namespace Donation.Domain.Hierarchy
{
  public sealed class LegalEntity : AggregateRootBase
  {
    private readonly List<OperatingUnit> operatingUnit = new();

    public IReadOnlyList<OperatingUnit> Systemzs => operatingUnit.AsReadOnly();

    private LegalEntity(
        GenericValueObjectId id,
        string title,
        string description,
        List<OperatingUnit>? operatingUnit)
        : base(id, title, description)
    {
      this.operatingUnit = operatingUnit;

    }

    public static LegalEntity Create(
      string title,
      string description,
      List<OperatingUnit>? operatingUnit)
    {
      return new(
          GenericValueObjectId.CreateUnique(),
          title,
          description,
          operatingUnit);
    }

    // Private Constructor is Required for EF Core
#pragma warning disable CS8618
    private LegalEntity():base() { }
#pragma warning restore CS8618
  }
}
