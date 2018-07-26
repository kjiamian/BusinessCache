using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessCache.Common;

namespace BusinessCache.Core
{
    public interface IObserver
    {
        /// <summary>
        /// <see cref="KeyMap"/>
        /// </summary>
        string ObserverName { get; set; }

        /// <summary>
        /// update 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Receive(Object sender, NotifyEventArgs e);
    }
}
