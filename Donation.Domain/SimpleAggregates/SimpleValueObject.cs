using Donation.Domain.Common.Models;

namespace Donation.Domain.SimpleAggregate
{
  public sealed class SimpleValueObject : ValueObject
  {
    public Guid Value { get; }

    private SimpleValueObject(Guid value) 
    {
      Value = value;
    }
    public static SimpleValueObject CreateUnique()
    {
      return new (Guid.NewGuid());
    }
    public static SimpleValueObject Create(Guid value)
    {
      return new SimpleValueObject(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
