using Donation.Domain.Common.Models;
using Donation.Domain.Guest.ValueObjects;
using Donation.Domain.Host.ValueObjects;
using Donation.Domain.Menu.ValueObjects;
using Donation.Domain.MenuReview.ValueObjects;

namespace Donation.Domain.MenuReview
{
  public sealed class MenuReview : AggregateRoot<MenuReviewId>
  {
    public string Rating { get; }
    public string Comment { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public GuestId GuestId { get; }
    //public DinnerId DinnerId { get; } # THINK

    private MenuReview(
     MenuReviewId menuReviewId,
     string rating,
     string comment,
     HostId hostId,
     MenuId menuId,
     GuestId guestId,
     DateTime createdDateTime,
     DateTime updatedDateTime) : base(menuReviewId)
    {
      Rating = rating;
      Comment = comment;
      HostId = hostId;
      MenuId = menuId;
      GuestId = guestId;
      CreatedDateTime = createdDateTime;
      UpdatedDateTime = updatedDateTime;
    }
    // Factory Method
    public static MenuReview Create(
     string rating,
     string comment,
     HostId hostId,
     MenuId menuId,
     GuestId guestId)
    {
      return new(
        MenuReviewId.CreateUnique(),
        rating,
        comment,
        hostId,
        menuId,
        guestId,
        DateTime.UtcNow,
        DateTime.UtcNow);
    }
  }
}
//{
//  "id": { "value": "00000000-0000-0000-0000-000000000000" },
//    "rating": 4,
//    "comment": "A menu with yummy food",
//    "hostId": { "value": "00000000-0000-0000-0000-000000000000" },
//    "menuId": { "value": "00000000-0000-0000-0000-000000000000" },
//    "guestId": { "value": "00000000-0000-0000-0000-000000000000" },
//    "dinnerId": { "value": "00000000-0000-0000-0000-000000000000" },
//    "createdDateTime": "2020-01-01T00:00:00.0000000Z",
//    "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
//}