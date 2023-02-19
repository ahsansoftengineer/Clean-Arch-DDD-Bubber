using Donation.Domain.Common.Models;

namespace Donation.Domain.Common.ValueObjects
{
  public sealed class Rating : ValueObject
  {
    public int Value { get; }

    private Rating(int value)
    {
      Value = value;
    }
    public static Rating CreateUnique(int value)
    {
      return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
