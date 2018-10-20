using Microsoft.AspNetCore.Http;
using QL.Serialization.Json;
using QL.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGameRESTAPI.Core
{

    /// <summary>
    /// 类WebRegionConfig的注释信息
    /// </summary>
    public class WebRegionConfig
    {
        [ThreadStatic]
        static WebRegionConfig CurrrentConfig;
        static string _outIp;
        static string _internalIp;

        static ServerCacheManager<string, WebRegionConfig> f = new ServerCacheManager<string, WebRegionConfig>();
        Dictionary<string, string> _data = new Dictionary<string, string>();


        public static WebRegionConfig Instance
        {
            get
            {
                try
                {
                    var context = HttpContextHelper.Current; ;
                    var s = CurrrentConfig;
                    if (s == null || s.Domain != context?.Request?.Host.Host)
                    {
                        s = getCurrentConfig();
                        CurrrentConfig = s;
                    }
                    return s;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        private static WebRegionConfig getCurrentConfig()
        {

            var context = HttpContextHelper.Current;
            if (context == null) return null;
            var req = context.Request;
            if (req == null) return null;
            var res = context.Response;
            if (res == null) return null;

            var host = req.Host.Host;

            if (string.IsNullOrEmpty(host)) { Error(res); return null; }
            host = host.ToLower();
            WebRegionConfig config;
            if (f.TryReadValue(host, out config)) return config;
            config = GetRegionConfigInfo(host);
            if (config == null) return Error(res);
            config.Domain = host;
            f.WriteValue(host, config);
            return config;


        }
        private static WebRegionConfig GetRegionConfigInfo(string region)
        {
            return DomainWildManager.Instance.GetWildWebRegionConfig(region);
        }



        internal static WebRegionConfig GetRegionConfigInfoByDb(string r_region)
        {

            WebRegionConfig config;
            if (f.TryReadValue(r_region, out config)) return config.Clone();


            return null;

            System.Data.DataSet ds = null;
            //MySqlDbProcedureHelper.GetRegionConfigInfoV2(r_region, out ds);

            var tbs = ds.Tables;
            if (tbs.Count == 0) return null;
            var rows = tbs[0].Rows;
            if (rows.Count == 0) return null;

            config = new WebRegionConfig();
            var data = config._data;

            var dr = rows[0];
            var cols = dr.Table.Columns;

            foreach (System.Data.DataColumn col in cols)
            {
                data[col.ColumnName] = dr[col.ColumnName].ToString();
            }
            config.Domain = r_region;
            f.WriteValue(r_region, config);
            return config.Clone();

        }

        private WebRegionConfig Clone()
        {
            var o = this.MemberwiseClone() as WebRegionConfig;
            return o;

        }


        #region ServerIp 

        public class IpData
        {
            public string ip;
        } 
        #endregion

        public string Domain { get; private set; }
        private static WebRegionConfig Error(HttpResponse res)
        {
            res.StatusCode = 404;
            return null;
        }

        public string MsSqlConStr => GetData("MsSqlConStr");
        public string DefaultSiteName => GetData("DefaultSiteName");
        public string RegionHost => GetData("RegionHost");
        public string MpName => GetData("RegionName");
        public string WxH5AppId => GetData("WxH5AppId");
        public string WxPcAppId => GetData("WxPcAppId");
        public string WxPayAppId => GetData("WxPayAppId");
        public string PayOrderTitle => GetData("PayOrderTitle");
        public string RegionName => GetData("RegionName");
        public string DwcAppId => GetData("DwcAppId");


        public string CenterServerWebHost =>
#if DEBUG
            "http://127.0.0.1:9004";
#else  
        GetData("CenterServerWebHost"); 
#endif



        public string SupportPayType => GetData("SupportPayType");
        public string SupportIosPayType => GetData("SupportIosPayType");

        private string GetData(string key)
        {
            string value;
            _data.TryGetValue(key, out value);
            return value ?? string.Empty;
        }

        class ss : IEqualityComparer<string>
        {
            public static ss _instance = new ss();
            bool IEqualityComparer<string>.Equals(string x, string y)
            {
                return string.Compare(x, y, true) == 0;
            }
            int IEqualityComparer<string>.GetHashCode(string obj)
            {
                return obj.ToLower().GetHashCode();
            }
        }

    }

}
