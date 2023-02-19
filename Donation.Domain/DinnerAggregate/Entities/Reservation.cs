using Donation.Domain.Bill.ValueObjects;
using Donation.Domain.Common.Models;
using Donation.Domain.Dinner.Enums;
using Donation.Domain.Dinner.ValueObjects;
using Donation.Domain.Guest.ValueObjects;

namespace Donation.Domain.Dinner.Entities
{
  public sealed class Reservation : Entity<ReservationId>
  {
    public int GuestCount { get; }
    public ReservationStatus ReservationStatus { get; } 
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public DateTime ArrivedDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    private Reservation(
      ReservationId reservationId,
      int guestCount,
      ReservationStatus reservationStatus,
      GuestId guestId,
      BillId billId,
      DateTime arrivedDateTime,
      DateTime createdDateTime,
      DateTime updatedDateTime) : base(reservationId)
    {
      GuestCount = guestCount;
      ReservationStatus = reservationStatus;
      GuestId = guestId;
      BillId = billId;
      ArrivedDateTime = arrivedDateTime;
      CreatedDateTime = createdDateTime;
      UpdatedDateTime = updatedDateTime;
    }

    public static Reservation Create(
      int guestCount,
      ReservationStatus reservationStatus,
      GuestId guestId,
      BillId billId,
      DateTime arrivedDateTime)
    {
      return new(
        ReservationId.CreateUnique(), 
        guestCount,
        reservationStatus,
        guestId,
        billId,
        arrivedDateTime,
        DateTime.UtcNow,
        DateTime.UtcNow);
    }
  }
}

/*
{
  "id": { "value": "00000000-0000-0000-0000-000000000000" },
  "guestCount": 2,
  "reservationStatus": "Reserved", // PendingGuestConfirmation, Reserved, Canceled
  "guestId": { "value": "00000000-0000-0000-0000-000000000000" },
  "billId": { "value": "00000000-0000-0000-0000-000000000000 }",
  "arrivalDateTime": null,
  "createdDateTime": "2020-01-01T00:00:00.0000000Z",
  "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
}
*/
