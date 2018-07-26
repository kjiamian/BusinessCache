using System;
using System.Collections.Generic;

namespace BusinessCache.TestData.CacheModels
{
    public class UserCache
    {
        public int Id { get; set; }

        public IEnumerable<UserLikeRecordCache> UserLikeRecordCache { get; set; }
    }

    /// <summary>
    /// 用户点赞记录缓存
    /// </summary>
    public class UserLikeRecordCache
    {
        public int Id { get; set; }
        public int WeiboId { get; set; }
        /// <summary>
        /// 点赞次数
        /// </summary>
        public int LikeCount { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

    }
}
