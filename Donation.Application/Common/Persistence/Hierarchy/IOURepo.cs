using Donation.Domain.HierarchyAggregate;

namespace Donation.Application.Common.Persistence.Hierarchy
{
    public interface IOURepo
    {
        void Add(OU me);
    }
}
