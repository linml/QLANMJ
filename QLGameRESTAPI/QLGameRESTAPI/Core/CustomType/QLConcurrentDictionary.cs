using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGameRESTAPI.Core.CustomType
{

    public class QLConcurrentDictionary<TKey, TValue> : ConcurrentDictionary<TKey, TValue>
    {
        public new TValue this[TKey key]
        {
            get
            {
                TValue val;
                base.TryGetValue(key, out val);
                return val;
            }
            set
            {
                base.AddOrUpdate(key, value, (k, v) => { return value; });
            }
        }
    }

}
