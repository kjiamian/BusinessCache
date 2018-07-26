using System.Collections.Generic;
using BusinessCache.Common;

namespace BusinessCache.Core
{
    public interface ISubject
    {
        /// <summary>
        /// <see cref="KeyMap"/>
        /// </summary>
        string EntityName { get; set; }

        /// <summary>
        /// 发布博客通知
        /// </summary>
        void Notify(Dictionary<string, string> param);

        void AddObserver(IObserver observer);
        void ReomverObserver(IObserver observer);
    }
}
