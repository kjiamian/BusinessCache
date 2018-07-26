using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessCache.Common
{
    public static class ConvertExtensions
    {
        public static int ToInt32(this object obj)
        {
            return Convert.ToInt32(obj);
        }

        public static T GetValue<T>(this Dictionary<string, T> dictionary, string key)
        {
            T value = default(T);
            dictionary.TryGetValue(key, out value);
            return value;
        }
    }
}
