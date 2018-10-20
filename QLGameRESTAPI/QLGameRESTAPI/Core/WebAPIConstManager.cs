/***************************************************************************
 * 
 * 创建时间：   2016/11/24 15:03:52
 * 创建人员：   沈瑞
 * CLR版本号：  4.0.30319.42000
 * 备注信息：   未填写备注信息
 * 
 * *************************************************************************/

using System;
using System.Collections.Concurrent;
using System.Data;
using QL.RedisTools;
using QL.Web;
using QLGameRESTAPI.Core;

namespace QLGameRESTAPI.Core
{

    #region APIKeySecretConfig


    /// <summary>
    /// 网站的配置参数管理类
    /// </summary>
    public class APIKeySecretConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public const string QLAppTypeName = "ql";
        /// <summary>
        /// 
        /// </summary>
        public const string QLAppKeyName = "ql_appid";


        static ServerCacheManager<string, APIKeySecretConfig> _list = new ServerCacheManager<string, APIKeySecretConfig>();
        static ServerCacheManager<string, APIKeySecretConfig> _apid_type2secret = new ServerCacheManager<string, APIKeySecretConfig>();

        /// <summary>
        /// 网站的配置参数管理类
        /// </summary>
        public APIKeySecretConfig() { }

        public string AppId { get; private set; }
        public string AppSecret { get; private set; }
        public int SNSSetID { get; private set; }
        public string PublicRsaKey => PackageData["PRsaKey"];
        public string AttachParam1 => PackageData["AP1"];
        public string AttachParam2 => PackageData["AP2"];
        public string Auth => PackageData["Auth"];

        public IWebParamData PackageData => _packageData;
        private readonly IWebParamData _packageData = new WebParamData();

        #region 获取配置的辅助器

        static APIKeySecretConfig GetValue(string id)
        {
            APIKeySecretConfig c;
            _list.TryReadValue(id, out c);
            return c ?? (c = private_GetConfig(id));
        }
        private static APIKeySecretConfig InitAPIKeySecretConfig(DataRow dr)
        {
            int SNSSetID;
            int.TryParse(dr["SNSSetID"].ToString(), out SNSSetID);

            var data = new APIKeySecretConfig()
            {
                AppId = dr["APPID"].ToString(),
                AppSecret = dr["AppSecret"].ToString(),
                SNSSetID = SNSSetID
            };

            var packageData = data.PackageData;
            foreach (DataColumn c in dr.Table.Columns)
            {
                packageData[c.ColumnName] = dr[c.ColumnName].ToString();
            }

            return data;

        }
        public static APIKeySecretConfig GetConfigValue(string appId, string type)
        {
            try
            {
                return private_GetConfigValue(appId, type);
            }
            catch (Exception ex)
            {
                QLDebug.WriteError(ex);
                return null;
            }
        }


        static APIKeySecretConfig private_GetConfig(string id)
        {
            APIKeySecretConfig c = null; 

            var sql = $"select * from `web_apikeysecretconfig` where `ID` = '{id}' limit 1";
            DataSet ds;
            QLGameRESTAPI.Core.DBTools.Data.DbHelperSQL.Instance.RunSql(sql, out ds);

            foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
            {
                c = InitAPIKeySecretConfig(dr);

                //Cache缓存
                _list[id] = c;

                return c;
            }
            return null;
        }
        static APIKeySecretConfig private_GetConfigValue(string appId, string type)
        {
            if (string.IsNullOrEmpty(appId)) return null;
            var appid_type = string.Concat(appId, "&", type);
            var config = _apid_type2secret[appid_type];
            if (config != null) return config;


            var sql = $"select * from `web_apikeysecretconfig` where APPID = '{appId.Replace("\'", "\'\'")}' and `Type` = '{type}' limit 1";
            DataSet ds;
            QLGameRESTAPI.Core.DBTools.Data.DbHelperSQL.Instance.RunSql(sql, out ds);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                config = InitAPIKeySecretConfig(dr);
                _apid_type2secret[appid_type] = config;
                return config;
            }
            return null;
        }


        #endregion

        #region 获取配置参数

        /// <summary>
        /// 短信接口的API和密钥，调用腾讯云的短信发送接口
        /// </summary>
        public static APIKeySecretConfig txyunsms { get { return GetValue("txyunsms"); } }
        /// <summary>
        /// 又拍云网站表单上传服务接口
        /// </summary>
        public static APIKeySecretConfig upyun_from_api { get { return GetValue("upyun_from_api"); } }
        /// <summary>
        /// 平台使用的主密钥
        /// </summary>
        public static APIKeySecretConfig ql_1 { get { return GetValue("ql_1"); } }

        /// <summary>
        /// 
        /// </summary>
        public static APIKeySecretConfig WxWebAppId => GetQLAppInfo(WebConfigHelper.WxWebAppId);
        /// <summary>
        /// 支付宝支付接口私钥
        /// </summary>
        public static APIKeySecretConfig alipay_default { get { return GetValue("alipay_default"); } }
        /// <summary>
        /// 腾讯云管理接口密钥信息
        /// </summary>
        public static APIKeySecretConfig txy_1 { get { return GetValue("txy_1"); } }
        /// <summary>
        /// 七牛云管理接口密钥信息
        /// </summary>
        public static APIKeySecretConfig qiniuyun { get { return GetValue("qiniuyun"); } }



        /// <summary>
        /// 微信公众号应用管理密钥
        /// </summary>
        public static APIKeySecretConfig wx_h5_web { get { return GetConfigValue(WebConfigHelper.WxH5AppId, "wx"); } }
        /// <summary>
        /// 微信PC网页登录用管理密钥
        /// </summary>
        public static APIKeySecretConfig wx_pc_web { get { return GetConfigValue(WebConfigHelper.WxPcAppId, "wx"); } }

        #endregion

        public static APIKeySecretConfig GetQLAppInfo(string appId)
        {
            return GetConfigValue(appId, QLAppTypeName) ?? ql_1;
        }
    }
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
    

    #endregion

    public partial class QLGlobal
    {

        static string apppth;
        static string weblogpath;
        static IRedisOperation _redisTools;

        static string AppPath(string vp = "~/")
        {
            return QL.IO.FileHelper.ProcessBaseDir + vp.TrimStart('~');
        }
        /// <summary>
        /// 获取当前站点的服务器根目录
        /// </summary>
        public static string WebRootPath
        {
            get
            {
                return !string.IsNullOrEmpty(apppth) ? apppth : (apppth = AppPath());
            }
        }

        /// <summary>
        /// 获取当前站点的服务器根目录
        /// </summary>
        public static string WebLogRootPath
        {
            get
            {
                return !string.IsNullOrEmpty(weblogpath) ? weblogpath : (weblogpath = AppPath("~/weblog"));
            }
        }

        public static IRedisOperation RedisTools
        {
            get
            {
                return _redisTools ?? (_redisTools = RedisClientProvider.Connect(WebConfigHelper.RedisConstr, WebConfigHelper.RedisDbId));
            }
        }
    }
}

