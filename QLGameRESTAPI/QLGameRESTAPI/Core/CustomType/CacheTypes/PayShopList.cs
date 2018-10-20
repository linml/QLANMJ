using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGameRESTAPI.Core.CustomType.CacheTypes
{
    /// <summary>
    /// 
    /// </summary>
    public class PayShopList
    {
        /// <summary>
        /// 
        /// </summary>
        public string status = "success";
        /// <summary>
        /// 
        /// </summary>
        public IDictionary<string, object>[] data = null;
    }
}
