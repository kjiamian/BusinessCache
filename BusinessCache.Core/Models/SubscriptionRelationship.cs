using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCache.Core.Models
{
    /// <summary>
    /// 订阅关系
    /// </summary>
    public class SubscriptionRelationship
    {
        /// <summary>
        /// 主题实体名称
        /// </summary>
        public string SubjectEntityName { get; set; }

        public List<string> ObserverNames { get; set; }

    }
}
