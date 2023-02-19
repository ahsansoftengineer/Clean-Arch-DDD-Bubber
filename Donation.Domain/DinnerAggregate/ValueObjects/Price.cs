namespace Donation.Domain.Dinner.ValueObjects
{
  public sealed class Price
  {
    public int Amount { get; set; }
    public string Currency { get; set; }
  }
}
//"price": {
//  "amount": 10.99,
//  "currency": "USD"
//},
