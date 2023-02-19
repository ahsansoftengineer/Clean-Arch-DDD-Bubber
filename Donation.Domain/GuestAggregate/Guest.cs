using Donation.Domain.Bill.ValueObjects;
using Donation.Domain.Common.Models;
using Donation.Domain.Common.ValueObjects;
using Donation.Domain.Dinner.ValueObjects;
using Donation.Domain.Guest.Entities;
using Donation.Domain.Guest.ValueObjects;
using Donation.Domain.MenuReview.ValueObjects;
using Donation.Domain.User.ValueObjects;

namespace Donation.Domain.Guest
{
  // Needs Attention in Future 
  public sealed class Guest : AggregateRoot<GuestId>
  {
    private readonly List<DinnerId> dinnerIds = new();
    private readonly List<BillId> billIds = new();
    private readonly List<MenuReviewId> menuReviewIds = new();
    private readonly List<GuestRating> guestRatings = new();
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public AverageRating AverageRating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    public UserId UserId { get; }
    public IReadOnlyList<DinnerId> DinnerIds => dinnerIds.AsReadOnly();
    public IReadOnlyList<BillId> BillIds => billIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => menuReviewIds.AsReadOnly();
    public IReadOnlyList<GuestRating> GuestRatings => guestRatings.AsReadOnly();

    private Guest(
      GuestId guestId,
      string firstName,
      string lastName,
      string profileImage,
      AverageRating averageRating,
      UserId userId,
      DateTime createdDateTime,
      DateTime updatedDateTime) : base(guestId)
    {
      FirstName = firstName;
      LastName = lastName;
      ProfileImage = profileImage;
      AverageRating = averageRating;
      UserId = userId;
      CreatedDateTime = createdDateTime;
      UpdatedDateTime = updatedDateTime;
    }
    // Factory Method
    public static Guest Create(
      string firstName,
      string lastName,
      string profileImage,
      AverageRating averageRating,
      UserId userId)
    {
      return new(
        GuestId.CreateUnique(),
        firstName,
        lastName,
        profileImage,
        averageRating,
        userId,
        DateTime.UtcNow,
        DateTime.UtcNow);
    }

  }
}

/*
{
  "id": { "value": "00000000-0000-0000-0000-000000000000" },
  "firstName": "John",
  "lastName": "Doe",
  "profileImage": "https://www.gravatar.com/avatar/00000000000000000000000000000000?d=mp",
  "averageRating": 4.5,
  "userId": { "value": "00000000-0000-0000-0000-000000000000" },
  "upcomingDinnerIds": [
    { "value": "00000000-0000-0000-0000-000000000000" }
  ],
  "pastDinnerIds": [
    { "value": "00000000-0000-0000-0000-000000000000" }
  ],
  "pendingDinnerIds": [
    { "value": "00000000-0000-0000-0000-000000000000" }
  ],
  "billIds": [
    { "value": "00000000-0000-0000-0000-000000000000" }
  ],
  "menuReviewIds": [
    { "value": "00000000-0000-0000-0000-000000000000" }
  ],
  "ratings": [
    {
      "id": { "value": "00000000-0000-0000-0000-000000000000" },
      "hostId": { "value": "00000000-0000-0000-0000-000000000000" },
      "dinnerId": { "value": "00000000-0000-0000-0000-000000000000" },
      "rating": 4,
      "createdDateTime": "2020-01-01T00:00:00.0000000Z",
      "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
    }
  ],
  "createdDateTime": "2020-01-01T00:00:00.0000000Z",
  "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
}



*/
