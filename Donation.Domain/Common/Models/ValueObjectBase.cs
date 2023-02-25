namespace Donation.Domain.Common.Models
{
  public class GenericValueObjectId : ValueObject
  {
    public Guid Value { get; }

    protected GenericValueObjectId(Guid value)
    {
      Value = value;
    }
    public static GenericValueObjectId CreateUnique()
    {
      return new(Guid.NewGuid());
    }
    public static GenericValueObjectId Create(Guid value)
    {
      return new GenericValueObjectId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
