using QLGameRESTAPI.Core.CustomType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGameRESTAPI.Core
{


    /// <summary>
    /// 
    /// </summary>
    public class Global
    {
        static Global _ins;
        private IDataCacheManager _dataCacheManager;


        /// <summary>
        /// 
        /// </summary>
        public static Global Instance
        {
            get
            {
                var s = _ins;
                if(s == null)
                {
                    s = new Global();
                    _ins = s;
                }
                return s;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public Global()
        {
            QLDebug = new QLDebug();
            APIKeySecretManager = new Manager.APIKeySecretConfigManager();

            ConfigManager = WebApiConfig.Instance.Reload();
            SystemConfig = new SystemConfigManager();
        }


        /// <summary>
        /// 获取日志操作对象
        /// </summary>
        public IQLDebug QLDebug { get; }
        /// <summary>
        /// API Key 和密钥的获取接口
        /// </summary>
        public IAPIKeySecretConfigManager APIKeySecretManager { get; }
        /// <summary>
        /// 获取服务器配置管理器
        /// </summary>
        public WebApiConfig ConfigManager { get; }
        /// <summary>
        /// 
        /// </summary>
        public SystemConfigManager SystemConfig { get; }
        /// <summary>
        /// 数据缓存
        /// </summary>
        public IDataCacheManager DataCacheManager
        {
            get
            {
                var s = _dataCacheManager;
                if (s != null) return s;
                s = new DataCacheManager();
                _dataCacheManager = s;
                return s;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearCacheData()
        {
            _dataCacheManager = null;
            _ins = null;
        }

    }
}
