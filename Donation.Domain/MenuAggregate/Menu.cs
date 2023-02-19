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
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    public string Name { get; private set; }
    public string Description { get; private set; }
    public AverageRating AverageRating { get; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    public HostId HostId { get; private set; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Menu(
        MenuId menuId,
        HostId hostId,
        string name,
        string description,
        AverageRating averageRating,
        List<MenuSection>? sections)
        : base(menuId)
    {
      HostId = hostId;
      Name = name;
      Description = description;
      _sections = sections;
      AverageRating = averageRating;
    }

    public static Menu Create(
        HostId hostId,
        string name,
        string description,
        List<MenuSection>? sections)
    {
      return new(
          MenuId.CreateUnique(),
          hostId,
          name,
          description,
          AverageRating.CreateNew(0),
          sections);
    }

#pragma warning disable CS8618
    //private Menu() { }
#pragma warning restore CS8618
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