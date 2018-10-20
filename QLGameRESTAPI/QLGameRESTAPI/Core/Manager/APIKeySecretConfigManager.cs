using QL.Web;
using QLGameRESTAPI.Core.CustomType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace QLGameRESTAPI.Core.Manager
{
    /// <summary>
    /// 
    /// </summary>
    public class APIKeySecretConfigManager : IAPIKeySecretConfigManager
    {
        private IDataCacheManager DataCache => Global.Instance.DataCacheManager;
        private const int cacheTime = 12 * 3600;


         //ServerCacheManager<string, APIKeySecretConfig> _list = new ServerCacheManager<string, APIKeySecretConfig>();
         //ServerCacheManager<string, APIKeySecretConfig> _apid_type2secret = new ServerCacheManager<string, APIKeySecretConfig>();




        #region 获取配置的辅助器

        APIKeySecretConfig GetValue(string id)
        {
            APIKeySecretConfig c = DataCache.GetItem<string, APIKeySecretConfig>(id); 
            return c ?? (c = private_GetConfig(id));
        }
        private APIKeySecretConfig InitAPIKeySecretConfig(DataRow dr)
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
        APIKeySecretConfig private_GetConfig(string id)
        {
            APIKeySecretConfig c = null;

            var sql = $"select * from `web_apikeysecretconfig` where `ID` = '{id}' limit 1";
            DataSet ds;
            DBTools.Conf.DbHelperSQL.Instance.RunSql(sql, out ds);

            foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
            {
                c = InitAPIKeySecretConfig(dr);

                //Cache缓存
                DataCache.SetItem(id, c, cacheTime);
                return c;
            }
            return null;
        }
        APIKeySecretConfig private_GetConfigValue(string appId, string type)
        {
            if (string.IsNullOrEmpty(appId)) return null;
            var appid_type = string.Concat(appId, "&", type);
            var config = DataCache.GetItem<string, APIKeySecretConfig>(appid_type);//  _apid_type2secret[appid_type];
            if (config != null) return config;


            var sql = $"select * from `web_apikeysecretconfig` where APPID = '{appId.Replace("\'", "\'\'")}' and `Type` = '{type}' limit 1";
            DataSet ds;
            QLGameRESTAPI.Core.DBTools.Conf.DbHelperSQL.Instance.RunSql(sql, out ds);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                config = InitAPIKeySecretConfig(dr);
                DataCache.SetItem(appid_type, config, cacheTime);
                //_apid_type2secret[appid_type] = config;
                return config;
            }
            return null;
        }

        #endregion

        #region 获取配置参数

        /// <summary>
        /// 短信接口的API和密钥，调用腾讯云的短信发送接口
        /// </summary>
        public IAPIKeySecretConfig txyunsms { get { return GetValue("txyunsms"); } }
        /// <summary>
        /// 又拍云网站表单上传服务接口
        /// </summary>
        public IAPIKeySecretConfig upyun_from_api { get { return GetValue("upyun_from_api"); } }
        /// <summary>
        /// 平台使用的主密钥
        /// </summary>
        public IAPIKeySecretConfig ql_1 { get { return GetValue("ql_1"); } }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public IAPIKeySecretConfig GetConfigValue(string appId, string type)
        {
            try
            {
                return private_GetConfigValue(appId, type);
            }
            catch (Exception ex)
            {
                Global.Instance.QLDebug.WriteError(ex);
                return null;
            }
        } 
        /// <summary>
        /// 支付宝支付接口私钥
        /// </summary>
        public IAPIKeySecretConfig alipay_default { get { return GetValue("alipay_default"); } }
        /// <summary>
        /// 腾讯云管理接口密钥信息
        /// </summary>
        public IAPIKeySecretConfig txy_1 { get { return GetValue("txy_1"); } }
        /// <summary>
        /// 七牛云管理接口密钥信息
        /// </summary>
        public IAPIKeySecretConfig alioss { get { return GetValue("alioss"); } }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public IAPIKeySecretConfig GetQLAppInfo(string appId)
        {
            return GetConfigValue(appId, ParamName.ql_appid) ?? ql_1;
        }

    }
}
