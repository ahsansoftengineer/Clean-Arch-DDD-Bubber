using Donation.Domain.Common.Models;
using Donation.Domain.Common.ValueObjects;
using Donation.Domain.Dinner.ValueObjects;
using Donation.Domain.Host.ValueObjects;
using Donation.Domain.Menu.Entities;
using Donation.Domain.Menu.ValueObjects;
using Donation.Domain.MenuReview.ValueObjects;

namespace Donation.Domain.Menu
{
  public sealed class Menu : AggregateRoot<MenuId>
  {
    private readonly List<MenuSection> sections = new();
    private readonly List<DinnerId> dinners = new();
    private readonly List<MenuReviewId> menuReview = new();
    public string Name { get; }
    public string Description { get; }
    public AverageRating AverageRating { get;}
    public DateTime CreatedDateTime { get; }  
    public DateTime UpdatedDateTime { get; }

    public HostId HostId { get; }
    public IReadOnlyList<MenuSection> Sections => sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnersIds => dinners.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => menuReview.AsReadOnly();
    // Constructor
    private Menu(
      MenuId menuId,
      string name,
      string description, 
      HostId hostId,
      DateTime createdDateTime, 
      DateTime updatedDateTime) : base(menuId)
    {
      Name = name;
      Description = description;
      HostId = hostId;
      CreatedDateTime = createdDateTime;
      UpdatedDateTime = updatedDateTime;
    }
    // Factory Method
    public static Menu Create(
      string name,
      string description,
      HostId hostId)
    {
      return new(
        MenuId.CreateUnique(),
        name,
        description,
        hostId,
        DateTime.UtcNow,
        DateTime.UtcNow);
    }
  }
}
/*
{
  "id": { "value": "00000000-0000-0000-0000-000000000000" },
  "name": "Yummy Menu",
  "description": "A menu with yummy food",
  "averageRating": 4.5,
  "sections": [
    {
      "id": { "value": "00000000-0000-0000-0000-000000000000" },
      "name": "Appetizers",
      "description": "Starters",
      "items": [
        {
          "id": { "value": "00000000-0000-0000-0000-000000000000" },
          "name": "Fried Pickles",
          "description": "Deep fried pickles"
        }
      ]
    }
  ],
  "hostId": { "value": "00000000-0000-0000-0000-000000000000" },
  "dinnerIds": [
    { "value": "00000000-0000-0000-0000-000000000000" }
  ],
  "menuReviewIds": [
    { "value": "00000000-0000-0000-0000-000000000000" }
  ],
  "createdDateTime": "2020-01-01T00:00:00.0000000Z",
  "updatedDateTime": "2020-01-01T00:00:00.0000000Z"
}
*/