using Donation.Domain.Entities;

namespace Donation.Application.Common.Persistence
{
  public interface IUserRepository
  {
    User? GetUserByEmail(string email);  
    void Add (User user);
  }
}
