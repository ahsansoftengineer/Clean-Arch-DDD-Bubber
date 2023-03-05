using Donation.Domain.Common.Models;

namespace Donation.Domain.HierarchyAggregate.ValueObjects
{
  public sealed class OrgId : ValueObject
  {
    public Guid Value { get; }

    private OrgId(Guid value) 
    {
      Value = value;
    }
    public static OrgId CreateUnique()
    {
      return new (Guid.NewGuid());
    }
    public static OrgId Create(Guid value)
    {
      return new OrgId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
