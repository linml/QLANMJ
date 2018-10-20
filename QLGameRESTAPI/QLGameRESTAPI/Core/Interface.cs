using QL.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGameRESTAPI.Core
{


    /// <summary>
    /// 为日志的操作提供服务接口
    /// </summary>
    public interface IQLDebug
    {
        /// <summary>
        /// 将一个错误信息写入日志
        /// </summary>
        /// <param name="ex">需要写入日志的错误的信息</param>
        void WriteError(Exception ex);
        /// <summary>
        /// 写入错误的信息日志
        /// </summary>
        /// <param name="context"></param>
        void WriteErrorString(string context);
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="context"></param>
        void WriteLog(string context);
        /// <summary>
        /// 写入支付相关跟踪日志
        /// </summary>
        /// <param name="context"></param>
        void WritePayLog(string context);
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IAPIKeySecretConfig
    {
        string AppId { get;  }
        string AppSecret { get;  }
        string AttachParam1 { get; }
        string AttachParam2 { get; }
        string Auth { get; }
        IWebParamData PackageData { get; }
        string PublicRsaKey { get; }
        int SNSSetID { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IAPIKeySecretConfigManager
    {
        IAPIKeySecretConfig alipay_default { get; }
        IAPIKeySecretConfig alioss { get; }
        IAPIKeySecretConfig ql_1 { get; }
        IAPIKeySecretConfig txy_1 { get; }
        IAPIKeySecretConfig txyunsms { get; }
        IAPIKeySecretConfig upyun_from_api { get; }

        IAPIKeySecretConfig GetConfigValue(string appId, string type);
        IAPIKeySecretConfig GetQLAppInfo(string appId);
    }

    /// <summary>
    /// 提供数据缓存
    /// </summary>
    public interface IDataCacheManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        TValue GetItem<TKey,TValue>(TKey key);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="exprise"></param>
        /// <returns></returns>
        bool SetItem<TKey, TValue>(TKey key, TValue value,int exprise);
    }

}
