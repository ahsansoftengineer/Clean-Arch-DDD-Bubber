using Donation.Domain.Common.Models;

namespace Donation.Domain.Hierarchy
{
  public sealed class Systemz : AggregateRootBase
  {
    //private Systemz(
    //    GenericValueObjectId id,
    //    string title,
    //    string description)
    //    : base(id, title, description)
    //{
    //}

    //public static Systemz Create(
    //  string title,
    //  string description,
    //  Org org)
    //{
    //  return new(
    //      GenericValueObjectId.CreateUnique(),
    //      title,
    //      description);
    //}

    // Private Constructor is Required for EF Core
//#pragma warning disable CS8618
    //private Systemz() : base() { }
//#pragma warning restore CS8618
  }
}
