using Donation.Domain.Common.Models;

namespace Donation.Domain.Hierarchy
{
  public sealed class Org : AggregateRootBase
  {
    private readonly List<GenericValueObjectId> systemzIds = new();
    public IReadOnlyList<GenericValueObjectId> SystemzIds => systemzIds.AsReadOnly();

    // Private Constructor is Required for EF Core
#pragma warning disable CS8618
    private Org():base() { }
#pragma warning restore CS8618
  }
}
