using Donation.Domain.Common.Models;

namespace Donation.Domain.Bill.ValueObjects
{
  // See This Later on
  public sealed class BillId : ValueObject
  {
    public Guid Value { get; }

    private BillId(Guid value)
    {
      Value = value;
    }
    public static BillId CreateUnique()
    {
      return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
