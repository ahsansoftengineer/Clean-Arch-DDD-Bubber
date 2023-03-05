using Donation.Domain.Common.Models;

namespace Donation.Domain.HierarchyAggregate.ValueObjects
{
  public sealed class BGId : ValueObject
  {
    public Guid Value { get; }

    private BGId(Guid value) 
    {
      Value = value;
    }
    public static BGId CreateUnique()
    {
      return new (Guid.NewGuid());
    }
    public static BGId Create(Guid value)
    {
      return new BGId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
