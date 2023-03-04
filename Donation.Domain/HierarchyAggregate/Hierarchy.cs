using Donation.Domain.Common.Models;
using Donation.Domain.Common.Models.Hierarchy;

namespace Donation.Domain.Hierarchy
{
  public sealed class Org : AggregateRootBaseSimpleParent
  {
    public IReadOnlyList<GenericValueObjectId> SystemzIds => childIds.AsReadOnly();

#pragma warning disable CS8618
    private Org() : base() { }
#pragma warning restore CS8618
  }


  public sealed class Systemz : AggregateRootBaseSimpleChild
  {
    public GenericValueObjectId OrgId { get { return this.ParentId;  } }

#pragma warning disable CS8618
    private Systemz() { }
#pragma warning restore CS8618
  }


  public sealed class BG : AggregateRootBaseSimpleParent
  {
    public IReadOnlyList<GenericValueObjectId> LeIds => this.childIds;

#pragma warning disable CS8618
    private BG() : base() { }
#pragma warning restore CS8618
  }


  public sealed class LE : AggregateRootBaseSimpleParentChild
  {
    public GenericValueObjectId BgId { get { return this.ParentId;  } }
    public IReadOnlyList<GenericValueObjectId> OuIds => this.childIds;
#pragma warning disable CS8618
    private LE() { }
#pragma warning restore CS8618
  }


  public sealed class OU : AggregateRootBaseSimpleParentChild
  {
    public GenericValueObjectId LeId { get { return this.ParentId;  } }
    public IReadOnlyList<GenericValueObjectId> SuIds => this.ChildIds;
#pragma warning disable CS8618
    private OU() { }
#pragma warning restore CS8618
  }


  public sealed class SU : AggregateRootBaseSimpleChild
  {
    public GenericValueObjectId OuId { get { return this.ParentId;  } }
#pragma warning disable CS8618
    private SU() { }
#pragma warning restore CS8618
  }
}
