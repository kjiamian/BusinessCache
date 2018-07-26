using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BusinessCache.Common;
using Microsoft.Extensions.PlatformAbstractions;

namespace BusinessCache.Core
{
    public class CacheManager
    {
        private Dictionary<string, ISubject> _subjects = new Dictionary<string, ISubject>();
        private Dictionary<string, IObserver> _observers = new Dictionary<string, IObserver>();
        public CacheManager()
        {
            string path = PlatformServices.Default.Application.ApplicationBasePath;
            ExtUtility.WriteObjectToCache(Path.Combine(path, "Subject"), _subjects, subject => subject.EntityName);
            ExtUtility.WriteObjectToCache(Path.Combine(path, "Observer"), _observers, observer => observer.ObserverName);

            //反射实例化ISubject，IObserver 的实现
            var weiboSubject = _subjects[KeyMap.EntityNameWeibo];

            var userInfoCacheObserver = _observers[KeyMap.ObserverUserInfoCache];
            var weiboCacheObserver = _observers[KeyMap.ObserverWeiboCache];


            weiboSubject.AddObserver(userInfoCacheObserver);
            weiboSubject.AddObserver(weiboCacheObserver);

        }

        public void Notify(string entityName, Dictionary<string, string> param)
        {
            var items = _subjects.Where(p => p.Key == entityName);
            foreach (var item in items)
            {
                var subject = item.Value;
                subject.Notify(param);
            }
        }

    }

    public class ExtUtility
    {
        /// <summary>
        /// 反射加载程序集
        /// </summary>
        /// <typeparam name="TK"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="cacheDict"></param>
        /// <param name="getKey"></param>
        public static void WriteObjectToCache<TK, T>(string path, Dictionary<TK, T> cacheDict, Func<T, TK> getKey)
        {
            if (string.IsNullOrEmpty(path))
                return;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string[] files = Directory.GetFiles(path, "*.dll");
            Type typeFromHandle = typeof(T);
            Func<Type, bool> isTypeMethod = GetIsTypeMethod(typeFromHandle);
            string[] array = files;
            foreach (string text in array)
            {
                FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(text);
                if (versionInfo.Comments.Equals("Extension", StringComparison.OrdinalIgnoreCase))
                {
                    Assembly assembly = Assembly.LoadFrom(text);
                    Type[] types = assembly.GetTypes();
                    foreach (Type type in types)
                    {
                        if (!isTypeMethod(type))
                        {
                            continue;
                        }
                        T value = (T)((object)Activator.CreateInstance(type));
                        cacheDict.Add(getKey(value), value);
                    }
                }
            }
        }
        private static Func<Type, bool> GetIsTypeMethod(Type outType)
        {
            Func<Type, bool> result;
            if (outType.IsInterface)
            {
                //接口
                result = t => t.GetInterface(outType.Name) != null;
            }
            else
            {
                //实现基类
                result = t => t.BaseType != null && t.BaseType.Name == outType.Name;
            }
            return result;
        }
    }
}
