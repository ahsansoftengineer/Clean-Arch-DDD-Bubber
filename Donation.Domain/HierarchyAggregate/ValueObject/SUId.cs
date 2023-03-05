using Donation.Domain.Common.Models;

namespace Donation.Domain.HierarchyAggregate.ValueObjects
{
  public sealed class SUId : ValueObject
  {
    public Guid Value { get; }

    private SUId(Guid value) 
    {
      Value = value;
    }
    public static SUId CreateUnique()
    {
      return new (Guid.NewGuid());
    }
    public static SUId Create(Guid value)
    {
      return new SUId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
