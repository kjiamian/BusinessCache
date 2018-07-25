using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessCache.Core.IObserverImp;
using BusinessCache.Core.SubjectImp;

namespace BusinessCache.Core
{
    public class CacheManager
    {
        public CacheManager()
        {
            //todo:通过配置，处理订阅关系
            var subject = new WeiboSubject();

            var userInfoCacheObserver = new UserInfoCacheObserver();
            var weiboCacheObserver = new WeiboCacheObserver();

            subject.NotifyEvent += userInfoCacheObserver.Receive;
            subject.NotifyEvent += weiboCacheObserver.Receive;

            subject.Notify(new Dictionary<string, string>()
            {
                { "UserId", "1" }
            });

        }
    }
}
