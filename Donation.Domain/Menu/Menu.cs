using Donation.Domain.Common.Models;
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

    public IReadOnlyList<MenuSection> Sections => sections.AsReadOnly();
    public HostId HostId { get; }
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
