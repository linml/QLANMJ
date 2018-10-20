using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QL.Extension;

namespace QLGameRESTAPI.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class WebConfigHelper
    {
        /// <summary>
        /// 网站的分区信息
        /// </summary>
        public static string RegionHost => WebApiConfig.Instance.RegionHost;
        /// <summary>
        /// Redis 服务地址
        /// </summary>
        public static string RedisConstr => WebApiConfig.Instance.RedisConstr;
        /// <summary>
        /// Redis 服务数据库编号
        /// </summary>
        public static int RedisDbId => WebApiConfig.Instance.RedisDbId;
        /// <summary>
        /// 数据库连接地址
        /// </summary>
        public static string MySqlConstr => WebApiConfig.Instance.MySqlConstr;
        /// <summary>
        /// 网站接口操作密钥
        /// </summary>
        public static string WebSecret => WebApiConfig.Instance.WebSecret;

        //public static string GetIpAdress { get; set; }
        //public static string GetInnerIpAdress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static string WxWebAppId => WebApiConfig.Instance.WxWebAppId;
        /// <summary>
        /// 
        /// </summary>
        public static string WxH5AppId => WebApiConfig.Instance.WxH5AppId;
        /// <summary>
        /// 
        /// </summary>
        public static string WxPcAppId => WebApiConfig.Instance.WxPcAppId;

        public static bool HasHttps { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfigValue(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }
    }
}
