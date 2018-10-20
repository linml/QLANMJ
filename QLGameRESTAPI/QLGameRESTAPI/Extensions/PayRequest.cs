using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QL.Extension;


namespace QLGameRESTAPI.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public class PayRequestBase: UserSessionKeyRequestBase
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="shopId"></param>
        /// <param name="_rmb">返回支付的人民币数量</param>
        /// <returns></returns>
        protected string GetOutTradeNo(int userId,int shopId,out double _rmb)
        {
            string regionId = this.ConfigManager.RegionId;
            string outNo = $"{regionId}{DateTime.Now.ToString("yyyyMMddHHmmssffffff")}{userId.ToString().PadLeft(8, '0')}";
            //4+18+8 = 30

            System.Data.DataSet ds;
            object o_rmb;
            Core.DBTools.Data.DataProcedureHelper.WEB_UserPayRequest(
                in_userid: userId,
                _shopId: shopId,
                in_outNo: outNo,
                _rmb:out o_rmb,
                outDataSet: out ds
                );
            _rmb = o_rmb.ConvertToDouble();

            return outNo;

        }

    }
}
