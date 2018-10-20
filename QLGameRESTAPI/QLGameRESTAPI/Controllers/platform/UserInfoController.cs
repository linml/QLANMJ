using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL.Extension;
using System.Text;

namespace QLGameRESTAPI.Controllers.platform
{

    /// <summary>
    /// 
    /// </summary>
    [Core.CustomRoute(version: Core.CustomType.ApiVersions.platfrom)]
    public class UserInfoController : Extensions.UserSessionKeyRequestBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpPost] 
        public IActionResult GetUploadPolicy(string type)
        {
            string ext = "mp3";

            switch (type)
            {
                case "voices":
                    {
                        ext = "mp3";
                        break;
                    }
                case "header":
                    {
                        ext = "png";
                        break;
                    }
                default:
                    type = "voices";
                    break;
            }

            var apiinfo = this.APIKeySecretManager.alioss;
            if (apiinfo == null)
            {
                return WriteFail("未配置上传用的密钥信息");
            }
            var bucketName = apiinfo.AttachParam1;
            var secret = apiinfo.AppSecret;


            var startWith = $"{type}/{DateTime.Now.ToString("yyyy/MM/dd")}/{this.UserInfo.UserId}";
            var saveKey = $"{startWith}/$(uuid).{ext}";




            //构造 policy 
            var policy = new
            {
                expiration = DateTime.Now.AddMinutes(75).ToString("yyyy-MM-ddTHH:mm:ssZ"),
                conditions = new object[]
                {
                    new {bucket = bucketName},
                    new string[]{ "starts-with", "$key", startWith }
                }
            }.ToJson();

            policy = QL.Security.Encryption.Base64Encrypt(policy);
            var key = Encoding.UTF8.GetBytes(secret.ToCharArray());
            var signature = Convert.ToBase64String(HMACSha1EncryptBytes(policy, key));



            return Json(new
            {
                status = "success",
                msg = "OK",
                policy_data = new object[] {
                    new
                    {
                        type= type,
                        url = this.ConfigManager.OssUploadUrl,
                        fileName = "file",
                        baseUrl ="http://alioss.qileah.cn/",
                        attachParam = new QL.Web.WebParamData()
                            .AddKeyValue("OSSAccessKeyId", apiinfo.AppId)
                            .AddKeyValue("key", saveKey)
                            .AddKeyValue("Signature", signature)
                            .AddKeyValue("policy", policy)
                     }
                }
            });


        }
        private byte[] HMACSha1EncryptBytes(string policy, byte[] keyBytes)
        {
            try
            {
                var data = Encoding.UTF8.GetBytes(policy);
                System.Security.Cryptography.HMACSHA1 hmac = new System.Security.Cryptography.HMACSHA1(keyBytes);
                byte[] bytes = hmac.ComputeHash(data);
                return bytes;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }
        }
    }
}