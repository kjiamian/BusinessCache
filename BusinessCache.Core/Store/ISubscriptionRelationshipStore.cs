using System;
using System.Collections.Generic;
using System.Text;
using BusinessCache.Core.Models;

namespace BusinessCache.Core.Store
{
    public interface ISubscriptionRelationshipStore
    {
        List<SubscriptionRelationship> GetAllRelationships();
    }
}
