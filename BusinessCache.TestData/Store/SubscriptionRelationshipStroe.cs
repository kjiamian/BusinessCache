using System.Collections.Generic;
using BusinessCache.Core.Models;
using BusinessCache.Core.Store;
using BusinessCache.TestData.Data;

namespace BusinessCache.TestData.Store
{
    public class SubscriptionRelationshipStroe : ISubscriptionRelationshipStore
    {
        public List<SubscriptionRelationship> GetAllRelationships()
        {
            return DefaultData.SubscriptionRelationships;
        }
    }
}
