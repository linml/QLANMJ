using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL.Extension;
using QL.Web;
using QLGameRESTAPI.Core;
using QLGameRESTAPI.Core.CustomType.CacheTypes;

namespace QLGameRESTAPI.Controllers.pay
{
    /// <summary>
    /// 支付请求操作
    /// </summary>
    [CustomRoute(version: Core.CustomType.ApiVersions.pay)]
    public class PayController : Extensions.PayRequestBase
    {



        const string wxpayunifiedorder = "https://api.mch.weixin.qq.com/pay/unifiedorder";
        string WxWapPaySceneInfo => new
        {
            h5_info = new
            {
                type = "Wap",
                wap_url = $"http://{RequestHost}/",
                wap_name = this.ConfigManager.WebName
            }
        }.ToJson();



        /// <summary>
        /// 发起一个微信wap支付请求
        /// </summary>
        /// <param name="appId">微信支付分配的appId</param>
        /// <param name="subject">商品的标题/交易标题/订单标题/订单关键字等。</param> 
        /// <param name="shopId">商城商品Id</param> 
        /// <returns></returns>
        [HttpPost]
        public IActionResult WxAppPay(string appId, string subject, int shopId)
        {
            var userId = this.UserInfo.UserId;
            double total_fee = 1;
            string mchId = "";
            string secret = "";

            var param = this.GetWebParam();

            if (string.IsNullOrEmpty(appId)
                || string.IsNullOrEmpty(subject)
                || shopId == 0
                )
            {
                return WriteFail("缺少参数");
            }

            var apiinfo = this.APIKeySecretManager.GetConfigValue(appId, "wxpay");
            if (apiinfo == null) return WriteFail("输入参数 appId 无效");

            mchId = apiinfo.AttachParam1;
            secret = apiinfo.AppSecret;

            var trade_no = GetOutTradeNo((int)this.UserInfo.UserId, shopId, out total_fee);
            total_fee *= 100;
            if (string.IsNullOrEmpty(trade_no)) return WriteShowTip("生成订单失败");

            var wxPayRequest = new QL.Web.RestfulApi.WeiXinPayWebParamData();

            wxPayRequest["appid"] = appId;
            wxPayRequest["mch_id"] = mchId;
            wxPayRequest["nonce_str"] = Guid.NewGuid().ToString("n").Substring(0, 8);
            wxPayRequest["body"] = subject;
            wxPayRequest["out_trade_no"] = trade_no;
            wxPayRequest["total_fee"] = total_fee.ToString("0");
            wxPayRequest["spbill_create_ip"] = this.ClientIpAdress;

            if (this.ConfigManager.UseHttps != 0)
                wxPayRequest["notify_url"] = $"https://{RequestHost}/pay/PayCallback.WxPay";
            else
                wxPayRequest["notify_url"] = $"http://{RequestHost}/pay/PayCallback.WxPay";
            //wxPayRequest["attach"] = attach.ToUrl();
            wxPayRequest["trade_type"] = "APP";

            wxPayRequest["sign"] = wxPayRequest.MarkSign(false, secret);
            var xmlbody = wxPayRequest.ToXml();
            var result_xml = HttpHelper.PostString(wxpayunifiedorder, xmlbody);


            var result = WebParamData.FromXml(result_xml);
            var appWxPayData = new QL.Web.RestfulApi.WeiXinPayWebParamData();
            if (result["return_code"] != "SUCCESS")
            {
                appWxPayData["status"] = "fail";
                appWxPayData["msg"] = result["return_msg"];
                return Json(appWxPayData);
            }
            appWxPayData["appid"] = appId;
            appWxPayData["partnerid"] = mchId;
            appWxPayData["prepayid"] = result["prepay_id"];
            appWxPayData["package"] = "Sign=WXPay";
            appWxPayData["timestamp"] = QL.Security.Encryption.EncryptionHelper.GetTimeStamp();
            appWxPayData["noncestr"] = Guid.NewGuid().ToString("n").Substring(0, 8);
            appWxPayData["sign"] = appWxPayData.MarkSign(false, secret);
            appWxPayData["status"] = "success";
            appWxPayData["msg"] = "OK";

            return Json(appWxPayData);


        }
        /// <summary>
        /// 发起一个微信wap支付请求
        /// </summary>
        /// <param name="appId">微信支付分配的appId</param>
        /// <param name="subject">商品的标题/交易标题/订单标题/订单关键字等。</param> 
        /// <param name="shopId">商城商品Id</param> 
        [HttpPost]
        public IActionResult WxWapPay(string appId, string subject, int shopId)
        {

            var userId = this.UserInfo.UserId;
            double total_fee = 1;
            string mchId = "";
            string secret = "";

            var param = this.GetWebParam();

            if (string.IsNullOrEmpty(appId)
                || string.IsNullOrEmpty(subject)
                || shopId == 0
                )
            {
                return WriteFail("缺少参数");
            }

            var apiinfo = this.APIKeySecretManager.GetConfigValue(appId, "wxpay");
            if (apiinfo == null) return WriteFail("输入参数 appId 无效");

            mchId = apiinfo.AttachParam1;
            secret = apiinfo.AppSecret;

            var trade_no = GetOutTradeNo((int)this.UserInfo.UserId, shopId, out total_fee);
            total_fee *= 100;

            if (string.IsNullOrEmpty(trade_no)) return WriteShowTip("生成订单失败");



            var wxPayRequest = new QL.Web.RestfulApi.WeiXinPayWebParamData();

            wxPayRequest["appid"] = appId;
            wxPayRequest["mch_id"] = mchId;
            wxPayRequest["nonce_str"] = Guid.NewGuid().ToString("n").Substring(0, 8);
            wxPayRequest["body"] = subject;
            wxPayRequest["out_trade_no"] = trade_no;
            wxPayRequest["total_fee"] = total_fee.ToString("0");
            wxPayRequest["scene_info"] = WxWapPaySceneInfo;
            wxPayRequest["spbill_create_ip"] = this.ConfigManager.ServicesIp;

            if (this.ConfigManager.UseHttps != 0)
                wxPayRequest["notify_url"] = $"https://{RequestHost}/pay/PayCallback.WxPay";
            else
                wxPayRequest["notify_url"] = $"http://{RequestHost}/pay/PayCallback.WxPay";
            wxPayRequest["trade_type"] = "MWEB";
            wxPayRequest["sign"] = wxPayRequest.MarkSign(false, secret);
            var xmlbody = wxPayRequest.ToXml();

            this.WriteLog($@"支付下单请求参数：
{xmlbody}");

            var unifiedorderResultXml = HttpHelper.PostString("https://api.mch.weixin.qq.com/pay/unifiedorder", xmlbody);

            this.WriteLog(unifiedorderResultXml);

            var unifiedorderResult = WebParamData.FromXml(unifiedorderResultXml);

            {

                //处理下订单的结果
                var return_code = unifiedorderResult["return_code"];
                var return_msg = unifiedorderResult["return_msg"];

                if (return_code != "SUCCESS")
                {
                    this.WriteLog($@"支付下单操作结果：{return_msg}");
                    return WriteFail("支付下单失败");
                }
            }

            {

                //处理下订单的结果
                var return_code = unifiedorderResult["return_code"];
                var return_msg = unifiedorderResult["return_code"];
            }

            var mweb_url = unifiedorderResult["mweb_url"];
            string payUrl = mweb_url;

            if (string.IsNullOrEmpty(payUrl))
            {
                return WriteFail("支付下单失败！");
            }

            var res = HttpHelper.GetString(mweb_url, $@"http://{RequestHost}/{RequestPath}");


            const string pattern = @"weixin://wap/pay?.*?(?="";)";
            var reg = new System.Text.RegularExpressions.Regex(pattern);
            var matachs_cols = reg.Matches(res);
            if (matachs_cols.Count <= 0)
            {
                this.WriteLog("支付地址获取失败1");
                goto Result;
            }
            payUrl = matachs_cols[0].Value;
            if (string.IsNullOrEmpty(payUrl))
            {
                this.WriteLog("支付地址获取失败2");
                payUrl = mweb_url;
                goto Result;
            }

            Result:
            return Json(new
            {
                status = "success",
                msg = "OK",
                payUrl = payUrl
            });


        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PayList()
        {


            PayShopList list = this.DataCacheManager.GetItem<string, PayShopList>("PayShopList");
            if (list != null)
            {
                return Json(list);
            }
            var sql = @"select * from sys_shop where `status` = 1";

            System.Data.DataSet ds;
            QLGameRESTAPI.Core.DBTools.Data.DbHelperSQL.Instance.RunSql(sql, out ds);

            if (ds.Tables.Count <= 0)
            {
                WriteFail("没有获取到支付列表");
            }
            list = new PayShopList()
            {
                status = "success",
                data = ds.Tables[0].GetDataTableArrayHasColum()
            };

            this.DataCacheManager.SetItem("PayShopList", list, DataCacheTime1Day);

            return Json(new
            {
                status = "success",
                data = ds.Tables[0].GetDataTableArrayHasColum()
            });

        }

    }
}