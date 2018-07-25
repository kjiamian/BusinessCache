using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessCache.Core
{
    public interface IObserver
    {
        void Receive(Object sender, NotifyEventArgs e);
    }
}
