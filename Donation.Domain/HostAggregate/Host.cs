using Donation.Domain.Common.Models;
using Donation.Domain.Common.ValueObjects;
using Donation.Domain.Dinner.ValueObjects;
using Donation.Domain.Host.ValueObjects;
using Donation.Domain.Menu.ValueObjects;
using Donation.Domain.User.ValueObjects;

namespace Donation.Domain.Host
{
  public sealed class Host : AggregateRoot<HostId>
  {
    private readonly List<MenuId> menus = new();
    private readonly List<DinnerId> dinners = new();
    public string FirstName { get; }
    public string LastName { get; }
    public string Description { get; }
    public string ProfileImage { get; }
    public AverageRating AverageRating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    public UserId UserId { get; }
    public IReadOnlyList<MenuId> MenuIds => menus.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => dinners.AsReadOnly();

    private Host(
      HostId hostId,
      string firstName,
      string lastName,
      string description,
      string profileImage,
      AverageRating averageRating,
      UserId userId,
      DateTime createdDateTime,
      DateTime updatedDateTime) : base(hostId)
    {
      FirstName = firstName;
      LastName = lastName;
      Description = description;
      ProfileImage = profileImage;  
      AverageRating = averageRating;
      UserId = userId;
      CreatedDateTime = createdDateTime;
      UpdatedDateTime = updatedDateTime;
    }
    // Factory Method
    public static Host Create(
      string firstName,
      string lastName,
      string description,
      string profileImage,
      AverageRating averageRating,
      UserId userId)
    {
      return new(
        HostId.CreateUnique(),
        firstName,
        lastName,
        description,
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
  "firstName": "Tiffany",
  "lastName": "Doe",
  "profileImage": "https://www.gravatar.com/avatar/00000000000000000000000000000000?d=mp",
  "averageRating": 4.5,
  "userId": { "value": "00000000-0000-0000-0000-000000000000" },
  "menuIds": [
    { "value": "00000000-0000-0000-0000-000000000000" }
  ],
  "dinnerIds": [
    { "value": "00000000-0000-0000-0000-000000000000" }
  ],
  "createdDateTime": "2020-01-01T00:00:00.0000000Z",
  "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
}
*/