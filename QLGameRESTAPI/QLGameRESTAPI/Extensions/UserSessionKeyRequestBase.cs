using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using QL.Platfrom2Web.Session;
using QL.Web;
using QLGameRESTAPI.Core;

namespace QLGameRESTAPI.Extensions
{
    /// <summary>
    /// 
    /// </summary> 
    public class UserSessionKeyRequestBase : WebAPICheckSignatureBase
    {
        /// <summary>
        /// 
        /// </summary>
        private IUserSessionKey _userInfo;

        /// <summary>
        /// 
        /// </summary>
        public virtual IUserSessionKey UserInfo
        {
            get
            {
                return _userInfo;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorStr"></param>
        /// <returns></returns>
        protected override bool CheckSafeRequest(out string errorStr)
        {

            var param = GetWebParam();

            var sessionKey = param[ParamName.sessionKey];
            if (string.IsNullOrEmpty(sessionKey))
            {
                errorStr = "缺少 sessionKey 参数";
                return false;
            }
            _userInfo = UserSessionKeyProvider.Deserializer(sessionKey);

            if(_userInfo == null)
            {
                errorStr = "无效的 sessionKey 参数";
                return false;
            }
            if (_userInfo.CheckTimeOut(70 * 60))
            {
                errorStr = "回话信息已超时无效";
                return false;
            }
            if (!_userInfo.VerifySign(this.APIKeySecretManager.ql_1.AppSecret))
            {
                errorStr = "无效的 sessionKey 参数";
                return false;
            }

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
            param["sessionKey"] = "H5客户端登录回传信息";
            param.Remove("timestamp");
            param.Remove("sign");
            param.Remove(ParamName.ql_appid);
            return param;


        }
    }
}
