using Donation.Domain.Common.Models;
using Donation.Domain.Guest.ValueObjects;
using Donation.Domain.Host.ValueObjects;
using Donation.Domain.User.ValueObjects;

namespace Donation.Domain.User
{
  public sealed class User : AggregateRoot<UserId>
  {
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Password { get; } // Hash this
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    public HostId HostId { get; }
    public GuestId GuestId { get; }

    private User(
    UserId userId,
    string firstName,
    string lastName,
    string email,
    HostId hostId,
    GuestId guestId,
    DateTime createdDateTime,
    DateTime updatedDateTime) : base(userId)
    {
      FirstName = firstName;
      LastName = lastName;
      Email = email;
      HostId = hostId;
      GuestId = guestId;
      CreatedDateTime = createdDateTime;
      UpdatedDateTime = updatedDateTime;
    }
    // Factory Method
    public static User Create(
      string firstName,
      string lastName,
      string email,
      HostId hostId,
      GuestId guestId)
    {
      return new(
        UserId.CreateUnique(),
        firstName,
        lastName,
        email,
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
  "firstName": "Tiffany",
  "lastName": "Doe",
  "email": "user@gmail.com",
  "password": "Amiko1232!", // TODO: Hash this
  "createdDateTime": "2020-01-01T00:00:00.0000000Z",
  "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
}
*/
