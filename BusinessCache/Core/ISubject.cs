using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessCache.Core
{
    public interface ISubject
    {
        string EntityName { get; set; }

        /// <summary>
        /// 发布博客通知
        /// </summary>
        void Notify(Dictionary<string, string> param);
    }
}
