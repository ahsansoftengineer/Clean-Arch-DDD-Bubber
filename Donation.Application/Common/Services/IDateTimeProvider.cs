namespace Donation.Application.Common.Services
{
  // Impl in Infrastructure
  public interface IDateTimeProvider
  {
    DateTime UtcNow { get; }  
  }
}
