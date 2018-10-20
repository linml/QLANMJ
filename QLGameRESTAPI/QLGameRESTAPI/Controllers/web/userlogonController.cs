using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using static QL.Security.Encryption;
using Microsoft.AspNetCore.Mvc;
using QL.Serialization;
using QL.Server.RedisOP;
using QL.Web;
using QL.Web.Session;
using QLGameRESTAPI.Core;
using QLGameRESTAPI.Extensions;
using System.Data;
using QL.Extension;
using QLGameRESTAPI.Core.CustomType;

namespace QLGameRESTAPI.Controllers
{
    /// <summary>
    /// 玩家登陆操作接口
    /// </summary> 
    public class userlogonController : BaseApiController
    {

        protected const string get_accessToken = "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";
        protected const string get_userInfo = "https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN";


        public const string invaildType = "传入了无效的 type 值";
        public const string invaildCode = "请求了无效的code值";
        public const string InvaildAPI = "暂时不支持该接口";
        public const string notHasCodeValue = "没有回传code值";
        public const string canNotGetUserInfo = "已经验证了传入的code值，但是无法获取用户信息";
        public const string canNotBingUserInfo = "已经完成了接口数据请求，但是在和平台对接绑定用户数据时出现未知异常";





        /// <summary>
        /// 玩家使用微登陆方式登陆
        /// </summary>
        /// <param name="code">微信登陆时获取到的code参数</param>
        /// <param name="appId">微信呢开发者后台分配的应用APPID</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult wx_app(string code, string appId = "11")
        {
            if (string.IsNullOrEmpty(code))
            {
                return WriteFail(notHasCodeValue);
            }

            var _apiConfig = Global.Instance.APIKeySecretManager.GetConfigValue(appId, "wx");
            if (_apiConfig == null)
            {
                return WriteFail("输入了错误的微信AppId");
            }


            var appid = _apiConfig.AppId;
            var secret = _apiConfig.AppSecret;

            var url = string.Format(get_accessToken, appid, secret, code);

            var res = HttpHelper.GetString(url);
            if (string.IsNullOrEmpty(res))
            {
                return WriteFail(invaildCode);
            }
            var access_token = Newtonsoft.Json.JsonConvert.DeserializeObject<accessToken_INFO>(res);
            if (access_token == null || !access_token.IsValidData)
            {
                Global.Instance.QLDebug.WriteErrorString("access_token.access_token = " + res);
                return WriteFail(canNotGetUserInfo);
            }


            url = string.Format(get_userInfo, access_token.access_token, access_token.openid);
            res = HttpHelper.GetString(url);
            if (string.IsNullOrEmpty(res))
            {
                Global.Instance.QLDebug.WriteErrorString("access_token.res = " + res);
                return WriteFail(canNotGetUserInfo);
            }
            //获取到用户信息的json字符串
            var userinfo = Newtonsoft.Json.JsonConvert.DeserializeObject<user_INFO>(res);
            if (userinfo == null || !userinfo.IsValidData)
            {
                Global.Instance.QLDebug.WriteErrorString("access_token.userinfo = " + res);
                return WriteFail(canNotBingUserInfo);
            }

            Uri headImgUri;
            if (System.Uri.TryCreate(userinfo.headimgurl, UriKind.Absolute, out headImgUri))
            {
                var oldPath = userinfo.headimgurl;

                userinfo.headimgurl = $"{headImgUri.Scheme}://{this.ConfigManager.WxHeadImgHost}{headImgUri.PathAndQuery}";
                this.WriteLog($@"玩家{userinfo.nickname} 头像
源地址：{oldPath}
新地址：{userinfo.headimgurl}");
            }




            var cacheInfo = new UserLogonCatchInfo()
            {
                HeadImg = userinfo.headimgurl + "",
                NickName = userinfo.nickname + "",
                OpenID = userinfo.openid,
                UnionID = userinfo.unionid,
                Sex = (byte)(userinfo.sex == 1 ? 1 : 2),
                RegionHost = this.ConfigManager.RegionHost,
                SNSID = (byte)_apiConfig.SNSSetID
            };

            return ProcessUserLogonResponse(cacheInfo);
        }




        /// <summary>
        /// 生成指定玩家的测试SessionKey参数
        /// </summary>
        /// <param name="userId">要获取的玩家Id</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult generateSessionKey(uint userId)
        {
            return Json(new
            {
                status = "success",
                msg = "OK",
                data = QL.Platfrom2Web.Session.UserSessionKeyProvider.GetNewSessionKey(userId, this.ConfigManager.RegionHost, QL.Common.UserType.Normal, this.APIKeySecretManager.ql_1.AppSecret)
            });


        }

        /// <summary>
        /// 生成玩家登陆使用的 AccessToken
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult generateUserAccessToken(uint userId)
        {

            return Json(new
            {
                status = "success",
                msg = "OK",
                data = GetUserAccessToken(userId)
            });

        }

        #region accessToken_INFO


        [PacketContract]
        public class UserLogonCatchInfo : WebDataSerializerBase<UserLogonCatchInfo>
        {
            private string _unionID;
            internal bool NeedCatchUserToken = true;
            [PacketMember]
            public string OpenID;
            [PacketMember]
            public byte SNSID;
            [PacketMember]
            public string NickName;
            [PacketMember]
            public string HeadImg;
            [PacketMember]
            public byte Sex;
            [PacketMember]
            public string RegionHost;
            [PacketMember]
            public string UnionID
            {
                get
                {
                    if (string.IsNullOrWhiteSpace(this._unionID))
                    {
                        return this.OpenID;
                    }
                    return this._unionID;
                }
                set
                {
                    this._unionID = value;
                }
            }
            public string Serializer()
            {
                return WebDataSerializerBase<UserLogonCatchInfo>.GetBase64String(this);
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="secret"></param>
            /// <returns></returns>
            public override byte[] MarkSign(string secret)
            {
                return MD5EncryptBytes($"{this.OpenID}{this.SNSID}{this.UnionID}{this.NickName}{this.HeadImg}{ this.Sex}{this.RegionHost}{this.Timestamp}{secret}");
            }
        }


        public class accessToken_INFO : IApiINFO
        {
            public string access_token;
            public int expires_in;
            public string refresh_token;
            public string openid;
            public string scope;
            public string unionid;
            public int errcode;
            public string errmsg;

            public bool IsValidData
            {
                get
                {
                    {
                        if (errcode != 0) return false;
                        if (string.IsNullOrWhiteSpace(this.access_token)) return false;
                        if (string.IsNullOrWhiteSpace(this.unionid)) return false;
                        if (string.IsNullOrWhiteSpace(this.openid)) return false;
                        return true;
                    }
                }
            }
        }
        #endregion
        #region user_INFO

        class user_INFO : IApiINFO
        {
            public string openid;
            public string nickname;
            public int sex;
            public string province;
            public string city;
            public string country;
            public string headimgurl;
            public string unionid;
            public int errcode;
            public string errmsg;

            public bool IsValidData
            {
                get
                {
                    if (errcode != 0) return false;
                    if (string.IsNullOrWhiteSpace(this.unionid)) return false;
                    if (string.IsNullOrWhiteSpace(this.openid)) return false;
                    return true;
                }
            }
        }


        #endregion
        #region IApiINFO

        /// <summary>
        ///  定义一个接口，实现在第三方接口返回数据时的处理协定
        /// </summary>
        public interface IApiINFO
        {
            /// <summary>
            /// 指示当前获取的用户信息是否有效
            /// </summary>
            bool IsValidData { get; }
        }


        #endregion

        private IActionResult ProcessUserLogonResponse(UserLogonCatchInfo userinfo)
        {

            IWebParamData param = null;
            //尝试获取该用户的分享参数
            //if (!string.IsNullOrEmpty(userinfo.UnionID))
            //{
            //    try
            //    {
            //        var url = RedisTools.ReadShareParam(userinfo.UnionID);
            //        if (!string.IsNullOrEmpty(url))
            //        {
            //            param = Uyi.Web.WebParamData.FromUrl(url);
            //        }
            //    }
            //    catch { }
            //}
            if (param == null)
                param = new WebParamData();

            int parentUser = 0;
            //if (!int.TryParse(param["parent"], out parentUser))
            //{
            //    int.TryParse(context.Request["parent"], out parentUser);
            //}


            //初始化数据
            string openid = userinfo.OpenID;
            string unionId = userinfo.UnionID;
            string headimg = userinfo.HeadImg;
            string nickname = userinfo.NickName;

            //调用数据接口
            DataSet ds;

            int retVal = do_WEB_ALL_UserLogon(unionId, userinfo, userinfo.SNSID, out ds);

            this.WriteLog($"玩家登陆：retVal = {retVal}");
            switch (retVal)
            {
                case 1: break;
                case -2:
                    {
                        return Json(new
                        {
                            status = "showbox",
                            msg = "您的账号已被封停，请联系客服",
                        });
                    }
                default:
                    {
                        return Json(new
                        {
                            status = "showtip",
                            msg = "服务器维护中...",
                        });
                    }
            }

            var dr = ds.Tables[0].Rows[0];
            var userid = dr.GetData("userid").ConvertToUInt32();

            if (userid <= 0)
            {
                return WriteFail("登录失败");
            }

            //userinfo.HeadImg = userinfo.HeadImg;
            //userinfo.NickName = dr["nickname"].ToString();

            var catch_userTokken = GetCatchUserToken(userinfo);

            param["status"] = "success";
            param["accesstoken"] = GetUserAccessToken(userid);
            param["catchtoken"] = catch_userTokken;

            //UyiDebug.WriteLog($"用户APP登录输出：{param.ToJson()}");

            //响应结果数据 
            return Json(param);
        }

        private int do_WEB_ALL_UserLogon(string unionId, UserLogonCatchInfo userinfo, byte SNSID, out DataSet ds)
        {
            return Core.DBTools.Data.DataProcedureHelper.WEB_ALL_UserLogon(
                 _unionId: unionId,
                 _Gender: userinfo.Sex,
                 _header: userinfo.HeadImg,
                 _ip: this.HttpContext.Connection.RemoteIpAddress.ToString(),
                 _nickName: userinfo.NickName,
                 _openId: userinfo.OpenID,
                 _snsId: userinfo.SNSID,
                 outDataSet: out ds
                 );


        }

        private string GetUserAccessToken(uint userid)
        {
            //对服务器玩家信息进行数据的加密传输

            var time_tick = EncryptionHelper.GetTimeStamp();
            var nonStr = Global.Instance.SystemConfig.LogonNonStr;
            this.WriteLog($"获取登录Token: nonStr = {nonStr}");
            var accesstoken = QL.Platfrom2Web.Session.LogonAccessTokenDataProvider.GetNewData(userid, this.ConfigManager.RegionHost, this.APIKeySecretManager.ql_1.AppSecret,
               nonStr);
            //accesstoken.Sign = accesstoken.MarkSign(APIKeySecretConfig.uyi_1.AppSecret);
            //var access_token = accesstoken.SerializerData();
            //var uuid = RedisTools.SaveAccessTokenParam(access_token);
            return accesstoken;
        }

        private string GetCatchUserToken(UserLogonCatchInfo userinfo)
        {
            //缓存玩家的登录信息到Cookies
            //userinfo.SNSID = (byte)this.SNSID;
            userinfo.MarkTimestamp();
            userinfo.Sign = userinfo.MarkSign(this.APIKeySecretManager.ql_1.AppSecret);
            var base64data = userinfo.Serializer();
            return base64data;
        }
    }
}