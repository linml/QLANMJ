using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGameRESTAPI.Core.CustomType
{
    public class DataCacheManager : IDataCacheManager
    {
        private class CacheStroe<TKey, TValue>
        {
            private QL.Web.ServerCacheManager<TKey, TValue> _cacheData = new QL.Web.ServerCacheManager<TKey, TValue>();
         public   TValue GetItem(TKey key)
            {
                return _cacheData.ReadValue(key);
            }

          public  void SetItem(TKey key, TValue value, long expires)
            {
                this._cacheData.WriteValue(key, value, expires);
            }
        }
        private System.Collections.Concurrent.ConcurrentDictionary<Type, object>
            _cacheItem = new System.Collections.Concurrent.ConcurrentDictionary<Type, object>();


        CacheStroe<TKey, TValue> GetCacheStore<TKey, TValue>()
        {
            Type type = typeof(TValue);
            object val;
            _cacheItem.TryGetValue(type, out val);
            var item = val as CacheStroe<TKey, TValue>;
            if (item == null)
            {
                item = new CacheStroe<TKey, TValue>();
                _cacheItem.AddOrUpdate(type, item, (k, v) =>
                {
                    var oldItem = v as CacheStroe<TKey, TValue>;
                    if (oldItem == null)
                    {
                        return item;
                    }
                    item = oldItem;
                    return oldItem;
                });
            }
            return item;

        }



        public TValue GetItem<TKey, TValue>(TKey key)
        {
           return GetCacheStore<TKey, TValue>().GetItem(key);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="exprise"></param>
        /// <returns></returns>
        public bool SetItem<TKey, TValue>(TKey key, TValue value, int exprise)
        {
            exprise = exprise * 1000;

            GetCacheStore<TKey, TValue>().SetItem(key, value, exprise);
            return true;
        }

    }
}
