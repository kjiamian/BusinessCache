using System;

namespace BusinessCache.TestData.Entities
{
    public class UserLikeRecord
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WeiboId { get; set; }
        /// <summary>
        /// 点赞次数
        /// </summary>
        public int LikeCount { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
