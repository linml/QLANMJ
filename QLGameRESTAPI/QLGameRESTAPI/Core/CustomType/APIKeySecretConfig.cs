using QL.Web;
using QLGameRESTAPI.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace QLGameRESTAPI.Core.CustomType
{

    /// <summary>
    /// 网站的配置参数管理类
    /// </summary>
    public class APIKeySecretConfig : IAPIKeySecretConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public const string QLAppTypeName = "ql";
        /// <summary>
        /// 
        /// </summary>
        public const string QLAppKeyName = "ql_appid";

        /// <summary>
        /// 网站的配置参数管理类
        /// </summary>
        public APIKeySecretConfig() { }

        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public int SNSSetID { get; set; }
        public string PublicRsaKey => PackageData["PRsaKey"];
        public string AttachParam1 => PackageData["AP1"];
        public string AttachParam2 => PackageData["AP2"];
        public string Auth => PackageData["Auth"];

        public IWebParamData PackageData => _packageData;
        private readonly IWebParamData _packageData = new WebParamData();




    }

}
