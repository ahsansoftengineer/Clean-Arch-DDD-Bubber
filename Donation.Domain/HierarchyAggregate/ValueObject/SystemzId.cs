using Donation.Domain.Common.Models;

namespace Donation.Domain.HierarchyAggregate.ValueObjects
{
  public sealed class SystemzId : ValueObject
  {
    public Guid Value { get; }

    private SystemzId(Guid value) 
    {
      Value = value;
    }
    public static SystemzId CreateUnique()
    {
      return new(Guid.NewGuid());
    }
    public static SystemzId Create(Guid value)
    {
      return new SystemzId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
