using Donation.Domain.Common.Models;

namespace Donation.Domain.HierarchyAggregate.ValueObjects
{
  public sealed class LEId : ValueObject
  {
    public Guid Value { get; }

    private LEId(Guid value) 
    {
      Value = value;
    }
    public static LEId CreateUnique()
    {
      return new (Guid.NewGuid());
    }
    public static LEId Create(Guid value)
    {
      return new LEId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
