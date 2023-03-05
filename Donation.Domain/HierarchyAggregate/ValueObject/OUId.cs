using Donation.Domain.Common.Models;

namespace Donation.Domain.HierarchyAggregate.ValueObjects
{
  public sealed class OUId : ValueObject
  {
    public Guid Value { get; }

    private OUId(Guid value) 
    {
      Value = value;
    }
    public static OUId CreateUnique()
    {
      return new (Guid.NewGuid());
    }
    public static OUId Create(Guid value)
    {
      return new OUId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
