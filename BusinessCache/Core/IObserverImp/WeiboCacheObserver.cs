using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessCache.CacheData;
using BusinessCache.Data;

namespace BusinessCache.Core.IObserverImp
{
    public class WeiboCacheObserver : IObserver
    {
        public void Receive(object sender, NotifyEventArgs e)
        {
            var weiboId = Convert.ToInt32(e.Data["WeiboId"]);
            var weiboCache = DefaultCacheData.WeiboCaches.FirstOrDefault(p => p.Id == weiboId);
            if (weiboCache != null)
            {
                DefaultCacheData.WeiboCaches.Remove(weiboCache);
            }
            var weibo = DefaultData.Weibos.FirstOrDefault(p => p.Id == weiboId);
            if (weibo != null)
            {
                DefaultCacheData.WeiboCaches.Add(DefaultCacheData.ConvertToWeiboCache(weibo));
            }
        }
    }
}
