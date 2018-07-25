using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessCache.Core.SubjectImp
{
    public class WeiboSubject
    {
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
        /// 添加一个订阅者
        /// </summary>
        /// <param name="observer">具体的订阅者对象</param>
        public void AddObserver(NotifyEventHandler observer)
        {
            NotifyEvent += observer;
        }

        /// <summary>
        /// 删除一个订阅者
        /// </summary>
        /// <param name="observer">具体的订阅者对象</param>
        public void RemoveObserver(NotifyEventHandler observer)
        {
            if (NotifyEvent != null)
            {
                NotifyEvent -= observer;
            }
        }

        /// <summary>
        /// 发布博客通知
        /// </summary>
        public void Notify(Dictionary<string, string> param)
        {
            NotifyEventArgs args = new NotifyEventArgs(param);
            NotifyEvent?.Invoke(this, args);
        }

    }
}
