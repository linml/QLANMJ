using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL.Extension;
using QLGameRESTAPI.Core.CustomType.CacheTypes;

namespace QLGameRESTAPI.Controllers.platform
{

    /// <summary>
    /// 包含排行榜相关的接口
    /// </summary>
    public class HallController : Extensions.UserSessionKeyRequestBase
    {
        /// <summary>
        /// 获取玩家的排行榜数据集
        /// </summary>
        /// <param name="type">获取的排行榜数据类型 目前支持：todayRank(今日)，totalRank（总排行）</param>
        /// <param name="count">获取排名的数量</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RankList(string type, int count)
        {
            int rankType = 0;
            switch (type)
            {
                case "todayRank":
                    {
                        rankType = 1;
                        break;
                    }
                case "totalRank":
                    {
                        rankType = 2;
                        break;
                    }
                default:
                    {
                        return WriteFail("排行类型错误");
                    }
            }
            var userId = (int)this.UserInfo.UserId;
            var cacheType = $"{type}&{userId}";

            var data = DataCacheManager.GetItem<string, HallRankList>(cacheType);
            if (data != null)
            {
                return Json(data);
            }

            DataSet ds = null;
            Core.DBTools.Data.DataProcedureHelper.WEB_GetRankList(userId, count, rankType, out ds);

            if (ds.Tables.Count <= 0)
            {
                return WriteFail("没有获取到排行榜数据");
            }
            var tb = ds.Tables[0];
            data = HallRankList.ParseDataTable(tb);
            //缓存五分钟
            this.DataCacheManager.SetItem(cacheType, data, (5 * 60));

            return Json(data);

        }

        /// <summary>
        /// 获取消息列表
        /// </summary>
        /// <param name="count">获取的数量</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetMsgList(int count)
        {
            var u = this.UserInfo;
            if (u == null)
                return WriteFail("参数错误");

            int ret = Core.DBTools.Data.DataProcedureHelper.WEB_HallMsgList(in_msgobject: 'U', in_objectid: (int)u.UserId, outDataSet: out DataSet ds);


            if (ret != 1 || ds.Tables.Count <= 0)
            {
                return WriteFail("获取信息失败！");
            }

            var tb = ds.Tables[0];

            if (tb.Columns.Contains("optime"))
            {
                tb.Columns.Remove("optime");
            }

            return Json(new
            {
                status = "success",
                msg = "OK",
                column = tb.Columns.Cast<DataColumn>().Select(p => p.ColumnName).ToArray(),
                data = tb.GetDataTableArray(),

            });
        }
        /// <summary>
        /// 设置玩家已读消息的状态
        /// </summary>
        /// <param name="msgId">消息的Id</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SetUserReadMsg(int msgId)
        {
            var u = this.UserInfo;
            if (u == null)
                return WriteFail("参数错误");

            int ret = QLGameRESTAPI.Core.DBTools.Data.DataProcedureHelper.WEB_SetUserReadMsg(
                in_msgobject: 'U',
                in_objectid: (int)u.UserId,
                in_msgid: msgId,
                outDataSet: out DataSet ds);

            if (ret == 1)
            {
                return WriteSuccess("设置消息已读状态成功");
            }
            return WriteFail("设置消息已读状态失败");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ShareSuccess(string taskId)
        {
            DataSet ds;
            int ret = Core.DBTools.Data.DataProcedureHelper.WEB_UserSharedResult(taskId, (int)this.UserInfo.UserId, "玩家分享送钻石", out ds);

            int diamond = 0, gold = 0, qidou = 0;
            if (ret == 1)
            {
                if (ds.Tables.Count >= 1)
                {
                    this.PushSingleUserMoneyChange(this.UserInfo.UserId, ds.Tables[0]);
                }

                if (ds.Tables.Count >= 2)
                {
                    var tb = ds.Tables[1];

                    if (tb.Rows.Count >= 1)
                    {
                        var dr = tb.Rows[0];

                        diamond = dr.GetData("diamond").ConvertToInt32();
                        gold = dr.GetData("gold").ConvertToInt32();
                        qidou = dr.GetData("qidou").ConvertToInt32();
                    } 
                }
            }
            return Json(new
            {
                status = "success",
                msg = "OK",
                diamond,
                gold,
                qidou,
            });

        }
    }
}