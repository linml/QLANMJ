using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using QL.Web;
using QLGameRESTAPI.Core;

namespace QLGameRESTAPI.Extensions
{
    /// <summary>
    /// 
    /// </summary>


    //[CustomParams(Name = APIKeySecretConfig.QLAppParamName, Order = 100,Mark = )]
    //[CustomParams(Name = ParamName.timestamp, Order = 100)]
    //[CustomParams(Name = ParamName.sign, Order = 100)]
    //[CustomParams(Name = ParamName.api_version, Order = 100)] 
    public abstract class WebAPICheckSignatureBase : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            string err;
            if (!CheckSafeRequest(out err))
            {
                context.Result = this.WriteFail(err);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private IAPIKeySecretConfig _webApiInfo;

        /// <summary>
        /// 
        /// </summary>
        public virtual IAPIKeySecretConfig WebApiInfo
        {
            get
            {
                if (_webApiInfo == null)
                {
                    var param = GetWebParam();
                    return (_webApiInfo = (this.APIKeySecretManager.GetQLAppInfo(param[ParamName.ql_appid])));
                }
                return _webApiInfo;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorStr"></param>
        /// <returns></returns>
        protected virtual bool CheckSafeRequest(out string errorStr)
        {
            var param = GetWebParam();
            if (param.CheckTimeOut(5 * 60))
            {
                errorStr = "请求操作已超时";
                return false;
            }
            var apiInfo = this.WebApiInfo;
            if (!param.VerifySign(apiInfo.AppSecret))
            {
                errorStr = "请求鉴权失败！";
                return false;
            }

            //权限检查器

            //if (!string.IsNullOrEmpty(this.ApiCode))
            //{
            //    if (apiInfo.Auth == null)
            //    {
            //        WriteFailJson("没有调用接口权限，请先申请接口权限;error:01");
            //        return false;
            //    }

            //    if (apiInfo.Auth == "all")
            //    {
            //        return true;
            //    }

            //    if (apiInfo.Auth.IndexOf(this.ApiCode + "|") >= 0)
            //    {
            //        return true;
            //    }
            //    WriteFailJson("没有调用接口权限，请先申请接口权限");
            //    return false;

            //}

            errorStr = "OK";
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override IWebParamData GetParamMark()
        { 
            var param = base.GetParamMark();
            param["timestamp"] = "时间戳";
            param["sign"] = "请求签名，协商签名算法";
            param[ParamName.ql_appid] = "接口的AppId（可选）没有取系统默认协商密钥";
            return param;
        }
    }
}
