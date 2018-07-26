using System.Collections.Generic;
using BusinessCache.Common;
using BusinessCache.Core;

namespace BusinessCache.WeiboSubject
{
    public class WeiboSubject : ISubject
    {
        public string EntityName { get; set; } = KeyMap.EntityNameWeibo;
        /// <summary>
        /// 声明委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void NotifyEventHandler(object sender, NotifyEventArgs e);

        /// <summary>
        /// 声明事假
        /// </summary>
        public event NotifyEventHandler NotifyEvent;

        /// <summary>
        /// 发布博客通知
        /// </summary>
        public void Notify(Dictionary<string, string> param)
        {
            NotifyEventArgs args = new NotifyEventArgs(param);
            NotifyEvent?.Invoke(this, args);
        }

        public void AddObserver(IObserver observer)
        {
            NotifyEvent += observer.Receive;
        }

        public void ReomverObserver(IObserver observer)
        {
            if (NotifyEvent != null)
            {
                NotifyEvent -= observer.Receive;
            }
        }
    }
}
