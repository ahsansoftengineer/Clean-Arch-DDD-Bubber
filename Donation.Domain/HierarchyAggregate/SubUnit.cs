using Donation.Domain.Common.Models;

namespace Donation.Domain.Hierarchy
{
  public sealed class SubUnit : AggregateRootBase
  {
    //private SubUnit(
    //    GenericValueObjectId id,
    //    string title,
    //    string description)
    //    : base(id, title, description)
    //{
    //}

    //public static SubUnit Create(
    //  string title,
    //  string description)
    //{
    //  return new(
    //      GenericValueObjectId.CreateUnique(),
    //      title,
    //      description);
    //}

    // Private Constructor is Required for EF Core
#pragma warning disable CS8618
    //private SubUnit() : base() { }
#pragma warning restore CS8618
  }
}
