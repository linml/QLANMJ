using QL.Extension;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGameRESTAPI.Core.CustomType
{

    /// <summary>
    /// 
    /// </summary>
    public class SystemConfigManager
    {
        private ConcurrentDictionary<string, string> _data;
        public ConcurrentDictionary<string, string> CacheData
        {
            get
            {
                var s = _data;
                if (s != null) return s;

                s = LoadConfig();

                return s;
            }
        }

        string _logonNonStr;



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ConcurrentDictionary<string, string> LoadConfig()
        {
            var sql = @"SELECT syskey,sysvalue from sys_config";
            System.Data.DataSet ds;
            DBTools.Data.DbHelperSQL.Instance.RunSql(sql, out ds);
            if (ds.Tables.Count >= 1)
            {
                var tb = ds.Tables[0];

               var data =  tb.Rows.Cast<System.Data.DataRow>().Select(dr =>
                {
                    var key = dr.GetData("syskey").ToString();
                    var value = dr.GetData("sysvalue").ToString();

                    return new KeyValuePair<string, string>(key, value);
                }).ToArray();

                var s  = new ConcurrentDictionary<string, string>(data);
                _data = s;
                return s;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetConfigByKey(string key)
        {
            string value = "" ;
            CacheData?.TryGetValue(key, out value);

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        public string LogonNonStr
        {
            get
            {
                return _logonNonStr ?? (_logonNonStr = (GetConfigByKey("LogonNonStr") ?? "qilelogon"));
            }
        }
    }
}
