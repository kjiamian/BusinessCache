using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessCache.Core
{
    public class NotifyEventArgs : EventArgs
    {
        public NotifyEventArgs(Dictionary<string, string> data)
        {
            Data = data;
        }

        public Dictionary<string, string> Data { get; set; }
    }
}
