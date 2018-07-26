using System;
using System.Linq;
using BusinessCache.Common;
using BusinessCache.Core;
using BusinessCache.TestData.CacheData;
using BusinessCache.TestData.Data;

namespace BusinessCache.UserInfoCacheObserver
{
    public class UserInfoCacheObserver : IObserver
    {
        public string ObserverName { get; set; } = KeyMap.ObserverUserInfoCache;

        public void Receive(object sender, NotifyEventArgs e)
        {
            var userId = e.Data.GetValue("UserId")?.ToInt32() ?? 0; 
            var userCache = DefaultCacheData.UserCaches.FirstOrDefault(p => p.Id == userId);
            if (userCache != null)
            {
                DefaultCacheData.UserCaches.Remove(userCache);
            }
            var userInfo = DefaultData.UserInfos.FirstOrDefault(p => p.Id == userId);

            if (userInfo != null)
            {
                var userLikeRecords = DefaultData.UserLikeRecords.Where(p => p.UserId == userId).ToList();
                DefaultCacheData.UserCaches.Add(DefaultCacheData.ConverToUserCache(userInfo, userLikeRecords));
            }

        }
    }
}
