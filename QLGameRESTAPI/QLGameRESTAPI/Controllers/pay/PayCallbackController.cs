using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QLGameRESTAPI.Controllers.pay
{
    /// <summary>
    /// 
    /// </summary>
    [Core.CustomRoute(version: Core.CustomType.ApiVersions.pay)]
    public class PayCallbackController : Extensions.BaseApiController
    {
        /// <summary>
        /// 微信支付回调处理结果
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult WxPay()
        {

            var xml = GetPostData();

            var wx_pay_notify = QL.Web.RestfulApi.WeiXinPayWebParamData.FromXml(xml);

            var return_code = wx_pay_notify["return_code"];
            if (return_code != "SUCCESS")
            {
                return WriteFail($"return_code == {return_code}");
            }
            var appid = wx_pay_notify["appid"];
            var apiinfo = this.APIKeySecretManager.GetConfigValue(appid, "wxpay");
            if (apiinfo == null)
            {
                return WriteFail($"无法获取 【{appid}】的密钥信息");
            }

            if (!wx_pay_notify.VerifySign(apiinfo.AppSecret))
            {
                return WriteFail("微信数据验证签名失败！");
            }

            var time_end = wx_pay_notify["time_end"];
            var openid = wx_pay_notify["openid"];
            var transaction_id = wx_pay_notify["transaction_id"];
            var out_trade_no = wx_pay_notify["out_trade_no"];


            if (!int.TryParse(wx_pay_notify["total_fee"], out int total_fee))
            {
                return WriteFail("充值金额错误！");
            }

            System.Data.DataSet ds;
            DateTime timeEnd;
            if (!DateTime.TryParseExact(time_end, "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out timeEnd))
            {
                timeEnd = DateTime.Now;
            }
            try
            {
                var result = Core.DBTools.Data.DataProcedureHelper.WEB_UserPayResult(
                    in_orderid: out_trade_no,    //支付时的微信订单号
                    in_status: 1,                //支付状态，1成功，2失败
                    in_realrmb: ((double)total_fee) / 100,      //实际的支付金额
                    in_paytype: 1,              //支付类型
                    in_remark: transaction_id,  //透传微信订单号
                    in_returnflage: 1,          //是否启用返佣
                    outDataSet: out ds
                    );

                if (result == 1)
                {
                    if (ds.Tables.Count >= 1)
                    { 
                        this.PushUserMoneyChange(ds.Tables[0],out uint[] userIds);
                        this.PushSystemEventMsg(userIds, Core.CustomType.EventCode.HallPaySuccess);
                    }
                    return WriteSuccess();
                }
                else
                {
                    return WriteFail($"result = {result}");
                }

            }
            catch (Exception ex)
            {
                this.QLDebug.WriteError(ex);
                return WriteFail(ex.Message);
            }
        }


        ///// <summary>
        ///// 测试充值
        ///// </summary>
        ///// <param name="out_trade_no">商户订单号</param>
        ///// <param name="total_fee">支付金额，单位分</param>
        ///// <param name="transaction_id">微信充值订单号，随意填写</param>
        ///// <returns></returns>
        //[HttpPost]
        //public IActionResult TestWxPay(string out_trade_no,int total_fee,string transaction_id)
        //{
        //    try
        //    {
        //        System.Data.DataSet ds;
        //        var result = Core.DBTools.Data.DataProcedureHelper.WEB_UserPayResult(
        //            in_orderid: out_trade_no,    //支付时的微信订单号
        //            in_status: 1,                //支付状态，1成功，2失败
        //            in_realrmb: ((double)total_fee) / 100,      //实际的支付金额
        //            in_paytype: 1,              //支付类型
        //            in_remark: transaction_id,  //透传微信订单号
        //            in_returnflage: 1,          //是否启用返佣
        //            outDataSet: out ds
        //            );

        //        if (result == 1)
        //        {
        //            if (ds.Tables.Count >= 1)
        //            {
        //                this.PushUserMoneyChange(ds.Tables[0], out uint[] userIds);
        //                this.PushSystemEventMsg(userIds, Core.CustomType.EventCode.HallPaySuccess);
        //            }
        //            return WriteSuccess();
        //        }
        //        else
        //        {
        //            return WriteFail($"result = {result}");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        this.QLDebug.WriteError(ex);
        //        return WriteFail(ex.Message);
        //    }
        //}


        protected override IActionResult WriteFail(string msg)
        {
            this.WriteLog(msg);
            return Content("Fail");
        }
        protected override IActionResult WriteSuccess(string msg = "OK")
        {
            this.WriteLog(msg);
            return Content("SUCCESS");
        }
    }
}