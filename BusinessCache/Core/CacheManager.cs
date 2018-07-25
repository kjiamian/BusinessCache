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
        public List<ISubject> subjects = new List<ISubject>();
        public CacheManager()
        {
            //todo:通过配置，处理订阅关系
            var weiboSubject = new WeiboSubject();

            var userInfoCacheObserver = new UserInfoCacheObserver();
            var weiboCacheObserver = new WeiboCacheObserver();

            weiboSubject.NotifyEvent += userInfoCacheObserver.Receive;
            weiboSubject.NotifyEvent += weiboCacheObserver.Receive;
            
            subjects.Add(weiboSubject);
        }

        public void Notify(string entityName, Dictionary<string, string> param)
        {
            var items = subjects.Where(p => p.EntityName == entityName);
            foreach (var subject in items)
            {
                subject.Notify(param);
            }
        }

    }
}
