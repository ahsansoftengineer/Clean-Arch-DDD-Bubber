using Donation.Domain.Entities;

namespace Donation.Application.Common.Persistence
{
    public interface IUserRepository : ISimpleRepo<User>
    {
        User? GetUserByEmail(string email);
    }
}
