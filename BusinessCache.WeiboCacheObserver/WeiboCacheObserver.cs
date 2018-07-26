using System;
using System.Linq;
using BusinessCache.Common;
using BusinessCache.Core;
using BusinessCache.TestData.CacheData;
using BusinessCache.TestData.Data;

namespace BusinessCache.WeiboCacheObserver
{
    public class WeiboCacheObserver : IObserver
    {
        public string ObserverName { get; set; } = KeyMap.ObserverWeiboCache;
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
