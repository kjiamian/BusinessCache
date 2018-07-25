using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessCache.CacheData;
using BusinessCache.CacheModels;
using BusinessCache.Data;

namespace BusinessCache.Core.IObserverImp
{
    public class UserInfoCacheObserver : IObserver
    {
        public void Receive(object sender, NotifyEventArgs e)
        {
            var userId = Convert.ToInt32(e.Data["UserId"]);
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
