using Donation.Application.Common.Persistence;
using Donation.Domain.Entities;

namespace Donation.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> users = new List<User>();
        public void Add(User user)
        {
            users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return users.SingleOrDefault(x => x.Email == email);
        }
    }
}
