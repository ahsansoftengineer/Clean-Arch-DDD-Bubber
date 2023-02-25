using Donation.Domain.Common.Models;
using Donation.Domain.Menu.Entities;

namespace Donation.Domain.Hierarchy
{
  public sealed class Org : AggregateRootBase
  {
    private readonly List<Systemz> _systemz = new();

    public IReadOnlyList<Systemz> Systemzs => _systemz.AsReadOnly();

    private Org(
        GenericValueObjectId id,
        string title,
        string description,
        List<Systemz>? systems)
        : base(id, title, description)
    {
      _systemz = systems;
    }

    public static Org Create(
      string title,
      string description,
      List<Systemz>? system)
    {
      return new(
          GenericValueObjectId.CreateUnique(),
          title,
          description,
          system);
    }

    // Private Constructor is Required for EF Core
#pragma warning disable CS8618
    private Org():base() { }
#pragma warning restore CS8618
  }
}
