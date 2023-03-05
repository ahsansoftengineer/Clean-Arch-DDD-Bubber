using Donation.Domain.HierarchyAggregate;

namespace Donation.Application.Common.Persistence.Hierarchy
{
    public interface IBGRepo
    {
        void Add(BG me);
    }
}
