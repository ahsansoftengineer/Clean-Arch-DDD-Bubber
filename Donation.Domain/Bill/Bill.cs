using Donation.Domain.Bill.ValueObjects;
using Donation.Domain.Common.Models;
using Donation.Domain.Dinner.ValueObjects;
using Donation.Domain.Guest.ValueObjects;
using Donation.Domain.Host.ValueObjects;

namespace Donation.Domain.Bill
{
  // See This Later on
  public sealed class Bill: AggregateRoot<BillId>
  {
    public Price Price { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }

    private Bill(
      BillId billId,
      Price price,
      DinnerId dinnerId,
      HostId hostId,
      GuestId guestId,

      DateTime createdDateTime,
      DateTime updatedDateTime) : base(billId)
    {
      Price = price;  
      DinnerId = dinnerId;
      HostId = hostId;
      GuestId = guestId;
      CreatedDateTime = createdDateTime;
      UpdatedDateTime = updatedDateTime;
    }
    // Factory Method
    public static Bill Create(
      Price price,
      DinnerId dinnerId,
      HostId hostId,
      GuestId guestId)
    {
      return new(
        BillId.CreateUnique(),
        price,
        dinnerId,
        hostId,
        guestId,
        DateTime.UtcNow,
        DateTime.UtcNow);
    }
  }
}
/*
{
  "id": { "value": "00000000-0000-0000-0000-000000000000" },
  "dinnerId": { "value": "00000000-0000-0000-0000-000000000000" },
  "guestId": { "value": "00000000-0000-0000-0000-000000000000" },
  "hostId": { "value": "00000000-0000-0000-0000-000000000000" },
  "price": {
      "amount": 10.99,
      "currency": "USD"
  },
  "createdDateTime": "2020-01-01T00:00:00.0000000Z",
  "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
}
*/
