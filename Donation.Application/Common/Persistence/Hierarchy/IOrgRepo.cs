﻿using Donation.Domain.HierarchyAggregate;

namespace Donation.Application.Common.Persistence.Hierarchy
{
    public interface IOrgRepo
    {
        void Add(Org me);
    }
}
