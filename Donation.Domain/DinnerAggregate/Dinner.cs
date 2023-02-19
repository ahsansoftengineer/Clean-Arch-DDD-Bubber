using Donation.Domain.Common.Models;
using Donation.Domain.Dinner.Entities;
using Donation.Domain.Dinner.Enums;
using Donation.Domain.Dinner.ValueObjects;
using Donation.Domain.Host.ValueObjects;
using Donation.Domain.Menu.ValueObjects;

namespace Donation.Domain.Dinner
{
  public sealed class Dinner : AggregateRoot<DinnerId>
  {
    private readonly List<Reservation> reservations = new();

    public string Name { get; }
    public string Description { get; }
    public DinnerStatus DinnerStatus { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; } 
    public string ImageUrl { get; }

    public DateTime StartedDateTime { get; }
    public DateTime EndedDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    public HostId HostId{ get; }
    public MenuId MenuId { get; }
    public Location Location { get; } // Name, Address, Latitude, Longitude
    public Price Price { get; } // Amount, Currency
    public IReadOnlyList<Reservation> Reservations => reservations.AsReadOnly();


    public Dinner(
      DinnerId dinnerId,
      string name,
      string description,
      DateTime startedDateTime,
      DateTime endedDateTime,
      HostId hostId,
      MenuId menuId,
      Location location,
      Price price,
      DateTime createdDateTime,
      DateTime updatedDateTime) : base(dinnerId)
    {
      Name = name;
      Description = description;
      StartedDateTime = startedDateTime;
      EndedDateTime= endedDateTime;
      HostId = hostId;
      MenuId = menuId;
      Location = location;
      Price = price;
      CreatedDateTime = createdDateTime;
      UpdatedDateTime = updatedDateTime;



    }
    public static Dinner Create(
      string name,
      string description,
      DateTime startedDateTime,
      DateTime endedDateTime,
      HostId hostId,
      MenuId menuId,
      Location location,
      Price price)
    {
      return new(
        DinnerId.CreateUnique(),
        name,
        description,
        startedDateTime,
        endedDateTime,
        hostId,
        menuId,
        location,
        price,
        DateTime.UtcNow,
        DateTime.UtcNow);
    }

  }
}

/*
"id": { "value": "00000000-0000-0000-0000-000000000000" },
  "name": "Yummy Dinner",
  "description": "A dinner with yummy food",
  "startDateTime": "2020-01-01T00:00:00.0000000Z",
  "endDateTime": "2020-01-01T00:00:00.0000000Z",
  "startedDateTime": null,
  "endedDateTime": null,
  "status": "Upcoming", // Upcoming, InProgress, Ended, Canceled
  "isPublic": true,
  "maxGuests": 10,
  "price": {
    "amount": 10.99,
    "currency": "USD"
  },
  "hostId": { "value": "00000000-0000-0000-0000-000000000000" },
  "menuId": { "value": "00000000-0000-0000-0000-000000000000" },
  "imageUrl": "https://image.com",
  "location": {
    "name": "Dan's Pizza Place",
    "address": "Berlin, Germany",
    "latitude": 52.520008,
    "longitude": 13.404954
  },
  "reservations": [
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
  ],
  "createdDateTime": "2020-01-01T00:00:00.0000000Z",
  "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
}


*/