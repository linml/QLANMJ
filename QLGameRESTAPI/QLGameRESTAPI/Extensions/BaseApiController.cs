using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QL.Extension;
using Microsoft.AspNetCore.Mvc.Filters;
using QL.Web;
using Microsoft.Extensions.Primitives;
using QLGameRESTAPI.Core;
using QLGameRESTAPI.Core.CustomType;
using System.IO;
using Microsoft.AspNetCore.Http.Internal;


namespace QLGameRESTAPI.Extensions
{
    /// <summary>
    /// 
    /// </summary> 
    [CustomRouteAttribute(version: ApiVersions.web)]
    public abstract class BaseApiController : Controller, IGetActionParams
    {

        private HttpRequestParam _requestData;
        private MemoryStream _requestBody;
        public const string NewLine = "\r\n";


        /// <summary>
        /// 
        /// </summary>
        public const int DataCacheTime1Day = (24 * 3600);
        /// <summary>
        /// 
        /// </summary>
        public const int DataCacheTime12Hour = (12 * 3600);
        /// <summary>
        /// 
        /// </summary>
        public const int DataCacheTime2Hour = (2 * 3600);
        /// <summary>
        /// 
        /// </summary>
        public const int DataCacheTime1Hour = (1 * 3600);
        /// <summary>
        /// 
        /// </summary>
        public const int DataCacheTime5Minute = (5 * 60);
        /// <summary>
        /// 
        /// </summary>
        public const int DataCacheTime30Minute = (30 * 60);
        /// <summary>
        /// 
        /// </summary>
        public const int DataCacheTime15Minute = (15 * 60);



        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            OnTraceHTTPRequest();
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            base.OnActionExecuting(context);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        /// <summary>
        /// 写入抓取服务器跟踪日志信息
        /// </summary>
        [NonAction]
        protected void OnTraceHTTPRequest()
        {
            this.WriteLog($@"{this.Request.Host.Host}{this.Request.Path}?{GetWebParam().ToUrlNoEncode()}{GetPostData()}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected virtual IActionResult WriteSuccess(string msg = "OK")
        {
            msg = msg.ToJson();
            return Content($@"{{""status"":""success"",""msg"":{msg}}}");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected virtual IActionResult WriteFail(string msg)
        {
            msg = msg.ToJson();
            return Content($@"{{""status"":""fail"",""msg"":{msg}}}");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected virtual IActionResult WriteShowTip(string msg)
        {
            msg = msg.ToJson();
            return Content($@"{{""status"":""showtip"",""msg"":{msg}}}");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected virtual IActionResult WriteShowBox(string msg)
        {
            msg = msg.ToJson();
            return Content($@"{{""status"":""showbox"",""msg"":{msg}}}");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        protected virtual IActionResult WriteStatusMsg(string status, string msg)
        {
            msg = msg.ToJson();
            return Content($@"{{""status"":""{status}"",""msg"":{msg}}}");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [NonAction]
        protected virtual IWebParamData GetWebParam() => getHttpRequestParam().ToNewWebParamData(true);
        [NonAction]
        IWebParamData IGetActionParams.getParamMark()
        {
            return this.GetParamMark();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual IWebParamData GetParamMark()
        {
            return new WebParamData();
        }


        /// <summary>
        /// 获取当前请求的请求域名（即HOST）
        /// </summary>
        public virtual string RequestHost
        {
            get
            {
                return this.Request.Host.Host;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual string RequestPath
        {
            get
            {
                return Request.Path;
            }
        }
        /// <summary>
        /// 获取客户端的IP
        /// </summary>
        public virtual string ClientIpAdress
        {
            get
            {
                StringValues ipstr;
                if (!Request.Headers.TryGetValue("X-Forwarded-For", out ipstr))
                {
                    ipstr = this.ControllerContext.HttpContext.Connection.RemoteIpAddress.ToString();
                }
                return ipstr;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public IHttpRequestParam HttpRequestParam => getHttpRequestParam();

        private HttpRequestParam getHttpRequestParam()
        {

            if (_requestData != null)
            {
                return _requestData;
            }
            var param = new HttpRequestParam();
            var query = this.Request.Query;
            foreach (var item in query)
            {
                param[item.Key] = item.Value;
            }
            if (this.Request.HasFormContentType)
            {
                var from = this.Request.Form;
                foreach (var item in from)
                {
                    param[item.Key] = item.Value;
                }
            }

            return (_requestData = param);
        }

        #region 定义系统用相关功能管理器

        /// <summary>
        /// 获取日志操作对象
        /// </summary>
        public IQLDebug QLDebug => Global.Instance.QLDebug;
        /// <summary>
        /// API Key 和密钥的获取接口
        /// </summary>
        public IAPIKeySecretConfigManager APIKeySecretManager => Global.Instance.APIKeySecretManager;
        /// <summary>
        /// 获取服务器配置管理器
        /// </summary>
        public WebApiConfig ConfigManager => Global.Instance.ConfigManager;
        /// <summary>
        /// 
        /// </summary>
        public IDataCacheManager DataCacheManager => Global.Instance.DataCacheManager;




        /// <summary>
        /// 写入服务器跟踪日志
        /// </summary>
        /// <param name="msg"></param>
        [NonAction]
        public virtual void WriteLog(string msg)
        {
            this.QLDebug.WriteLog($"{ControllerName} : {msg}");
        }
        /// <summary>
        /// 获取当前控制器的名称
        /// </summary>
        public virtual string ControllerName => this.ControllerContext.ActionDescriptor.ControllerName;

        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public string GetPostData()
        {
            string postStr = "";
            var stream = this.RequestBody;
            if (stream.CanSeek)
            {
                long currentPos = stream.Position;
                stream.Position = 0;
                postStr = System.Text.Encoding.UTF8.GetString(stream.ToArray());
                if (!string.IsNullOrEmpty(postStr))
                {
                    postStr = NewLine + postStr;
                }
                stream.Position = currentPos;

            }
            return postStr;
        }
        /// <summary>
        /// 
        /// </summary>
        public MemoryStream RequestBody
        {
            get
            {
                if (_requestBody != null)
                {
                    _requestBody.Position = 0;
                    return _requestBody;

                }
                _requestBody = new MemoryStream();
                this.Request.EnableRewind();
                long currentPos = 0;

                var stream = this.Request.Body;
                if (stream.CanRead && stream.CanSeek)
                {
                    currentPos = stream.Position;

                    stream.Position = 0;
                    stream.CopyTo(_requestBody);
                    stream.Position = currentPos;
                }
                _requestBody.Position = 0;
                return _requestBody;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tb"></param>
        [NonAction]
        public void PushUserMoneyChange(System.Data.DataTable tb, out uint[] userIdArray)
        {
            userIdArray = new uint[0];
            if (tb.Rows.Count <= 0) return;

            var mm = tb.Rows.Cast<System.Data.DataRow>().Select(dr =>
             {
                 return new QL.Common.PlayerMoneyBag()
                 {
                     UserID = dr.GetData("UserID").ConvertToUInt32(),
                     MoneyNum = dr.GetData("MoneyNum").ConvertToInt32(),
                     MoneyType = dr.GetData("MoneyType").ConvertToByte(),
                 };
             }).ToArray();

            userIdArray = mm.GroupBy(p => p.UserID).Select(p => p.Key).Where(p => p > 0).ToArray();

            foreach (var u in userIdArray)
            {
                var msg = new QL.Common.MSG_S_PlayerLatestBalance()
                {
                    MoneyBag = mm.Where(p => p.UserID == u).ToArray()
                };
                QL.Server.RedisOP.RedisOperation.SendMessageToUser(u, msg);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tb"></param>
        /// <param name="userIdArray"></param>
        [NonAction]
        public void PushSingleUserMoneyChange(uint userId, System.Data.DataTable tb)
        {

            if (tb.Rows.Count <= 0) return;

            var mm = tb.Rows.Cast<System.Data.DataRow>().Select(dr =>
            {
                return new QL.Common.PlayerMoneyBagBase()
                {
                    MoneyNum = dr.GetData("MoneyNum").ConvertToInt32(),
                    MoneyType = dr.GetData("MoneyType").ConvertToByte(),
                };
            }).ToArray();

            var msg = new QL.Common.MSG_S_PlayerLatestBalance()
            {
                MoneyBag = mm
            };
            QL.Server.RedisOP.RedisOperation.SendMessageToUser(userId, msg);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="eventCode"></param>
        /// <param name="eventData"></param>
        [NonAction]
        public virtual void PushSystemEventMsg(uint userId, string eventCode, IWebParamData eventData = null)
        {
            var msg = new QL.Common.MSG_S_SystemPushMsg()
            {
                TargerUser = userId,
                EventCode = eventCode,
                EventData = eventData?.Select(p => new QL.Common.KeyValueData() { Key = p.Key, Value = p.Value }).ToArray()
            };

            QL.Server.RedisOP.RedisOperation.SendMessageToUser(userId, msg);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="eventCode"></param>
        /// <param name="eventData"></param>
        [NonAction]
        public virtual void PushSystemEventMsg(uint[] userIds, string eventCode, IWebParamData eventData = null)
        {
            if (userIds == null && userIds.Length <= 0) return;


            var msg = new QL.Common.MSG_S_SystemPushMsg()
            {
                TargerUser = 0,
                EventCode = eventCode,
                EventData = eventData?.Select(p => new QL.Common.KeyValueData() { Key = p.Key, Value = p.Value }).ToArray()
            };
            foreach (var userId in userIds)
            {
                msg.TargerUser = userId;
                QL.Server.RedisOP.RedisOperation.SendMessageToUser(userId, msg);
            }
        }




    }

}