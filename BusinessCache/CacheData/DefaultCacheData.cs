using System.Collections.Generic;
using System.Linq;
using BusinessCache.CacheModels;
using BusinessCache.Data;
using BusinessCache.Entities;

namespace BusinessCache.CacheData
{
    public static class DefaultCacheData
    {

        public static List<UserCache> UserCaches = new List<UserCache>() { };
        public static List<WeiboCache> WeiboCaches = new List<WeiboCache>() { };


        /// <summary>
        /// 初始化缓存，
        /// 用户缓存
        /// 微博缓存
        /// </summary>
        public static void InitCache()
        {
            InitUserCache();
            InitWeiboCache();
        }

        private static void InitUserCache()
        {
            var userInfos = DefaultData.UserInfos;
            var userLikeRecords = DefaultData.UserLikeRecords;
            UserCaches.Clear();
            UserCaches.AddRange(userInfos.Select(p => ConverToUserCache(p, userLikeRecords)));
        }

        public static UserCache ConverToUserCache(UserInfo model, IEnumerable<UserLikeRecord> userLikeRecords)
        {
            var records = userLikeRecords.Where(p => p.UserId == model.Id);
            return new UserCache()
            {
                Id = model.Id,
                UserLikeRecordCache = records.Select(ConvertToUserLikeRecordCache)
            };
        }

        private static UserLikeRecordCache ConvertToUserLikeRecordCache(UserLikeRecord model)
        {
            return new UserLikeRecordCache()
            {
                Id = model.Id,
                WeiboId = model.WeiboId,
                LikeCount = model.LikeCount,
                CreateTime = model.CreateTime,
                UpdateTime = model.UpdateTime,
            };
        }

        private static void InitWeiboCache()
        {
            var weibos = DefaultData.Weibos;
            WeiboCaches.Clear();
            WeiboCaches.AddRange(weibos.Select(ConvertToWeiboCache));
        }

        public static WeiboCache ConvertToWeiboCache(Weibo model)
        {
            return new WeiboCache() { Id = model.Id, LikeCount = model.LikeCount };
        }
    }
}
