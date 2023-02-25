using Donation.Domain.Common.Models;

namespace Donation.Domain.Hierarchy
{
  public sealed class BusinessGroup : AggregateRootBase
  {
    private readonly List<LegalEntity> legalEntity = new();

    public IReadOnlyList<LegalEntity> LegalEntity => legalEntity.AsReadOnly();

    private BusinessGroup(
        GenericValueObjectId id,
        string title,
        string description,
        List<LegalEntity>? legalEntity)
        : base(id, title, description)
    {
      legalEntity = legalEntity;
    }

    public static BusinessGroup Create(
      string title,
      string description,
      List<LegalEntity>? legalEntity)
    {
      return new(
          GenericValueObjectId.CreateUnique(),
          title,
          description,
          legalEntity);
    }

    // Private Constructor is Required for EF Core
#pragma warning disable CS8618
    private BusinessGroup():base() { }
#pragma warning restore CS8618
  }
}
