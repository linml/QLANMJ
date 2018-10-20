using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL.Extension;
using System.Collections;
using QLGameRESTAPI.Core.DBTools.Data;

namespace QLGameRESTAPI.Controllers.platform
{
    /// <summary>
    /// PlatformController
    /// </summary>
    [Core.CustomRoute(version: Core.CustomType.ApiVersions.platfrom)]
    public class RecordController : Extensions.UserSessionKeyRequestBase
    {
        /**
         * 
rec.recordid,
rec.mid,
rec.roomid,
rec.gameid,
rec.ownerid,
rec.groupid,
rec.tableid,
rul.rulestr,
rue.ruledesc,
rec.addtime





recordid,
userid,
nickname,
moneynum,


         */

        /// <summary>
        /// 获取战绩列表
        /// </summary>
        /// <param name="startId">起始编号</param>
        /// <param name="count">查询的数量</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult getRecordList(int startId, int count)
        {
            var u = this.UserInfo;
            if (u == null)
                return WriteFail("参数错误");

            DataSet ds;
            int ret = DataProcedureHelper.WEB_GetUserReplayList(
                _userId: (int)u.UserId,
                _count: count,
                _startId: startId,
                outDataSet: out ds);

            if (ret != 1)
            {
                return WriteFail("加载战绩回放列表失败");
            }

            Hashtable recordMap = new Hashtable();
            foreach (System.Data.DataRow dr in ds.Tables[1].Rows)
            {
                uint recordId = dr["recordId"].ConvertToUInt32();
                var item = new recordRoomDetailInfoItem()
                {
                    recordId = dr["recordId"].ConvertToUInt32(),
                    userId = dr["userId"].ConvertToInt32(),
                    addTime = dr["addTime"].ConvertToDateTime().GetTimestamp(),
                    moneyNum = dr["moneyNum"].ConvertToInt32(),
                    nickName = dr["nickName"].ToString()
                };
                if (recordMap.Contains(recordId))
                {
                    List<recordRoomDetailInfoItem> list = (List<recordRoomDetailInfoItem>)recordMap[recordId];
                    list.Add(item);
                }
                else
                {
                    List<recordRoomDetailInfoItem> list = new List<recordRoomDetailInfoItem>();
                    list.Add(item);
                    recordMap.Add(recordId, list);
                }
            }

            var _items = ds.Tables[0].Rows.Cast<DataRow>().Select(dr =>
            {
                var o = new recordRoomInfoItem();
                o.recordId = dr.GetData("recordId").ConvertToUInt32();
                o.roomId = dr.GetData("roomId").ConvertToInt32();
                o.gameId = dr.GetData("gameId").ConvertToInt32();
                o.mid = dr.GetData("mid").ToString();
                o.sid = dr.GetData("sid").ToString();
                o.ownerId = dr.GetData("ownerId").ConvertToInt32();
                o.picFile = dr.GetData("picfile").ToString();
                o.ruleStr = dr.GetData("ruleStr").ToString();
                o.ruleDesc = dr.GetData("ruleDesc").ToString();
                o.addTime = dr.GetData("addTime").ConvertToDateTime().GetTimestamp();
                o.recPath = dr.GetData("recpath").ToString();
                o.roundDetail = (List<recordRoomDetailInfoItem>)recordMap[o.recordId];
                return o;
            });

            return Json(new
            {
                status = "success",
                data = _items.ToArray()
            });


        }

        /// <summary>
        /// 获取玩家战绩列表数据
        /// </summary>
        /// <param name="startId">获取数据的起始Id 如果加载最新的数据请传入 0 </param>
        /// <param name="count">获取的数量</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult getTotalRecordLIst(int startId, int count)
        {
            if(startId == 0)
            {
                startId = int.MaxValue;
            }

            DataSet ds = null;
            int ret = DataProcedureHelper.WEB_GetUserReplayListMM((int)this.UserInfo.UserId, startId, count, out ds);
            if(ret != 1)
            { 
                return WriteFail("加载战绩回放列表失败");
            }

            var tb1 = ds.Tables[0];
            var tb2 = ds.Tables[1];


            var userTotalNum = tb2.Rows.Cast<DataRow>().Select(dr =>
            {
                return new
                {

                    mid = dr.GetData("mid").ToString(),
                    userItem = new
                    { 
                        userid = dr.GetData("userid").ConvertToInt32(),
                        nickname = dr.GetData("nickname").ToString(),
                        moneynum = dr.GetData("moneynum").ConvertToInt32(),
                    }
                };
            });

            var recGroupList = tb1.Rows.Cast<DataRow>().Select(dr =>
            {
                int recordId = dr.GetData("recordid").ConvertToInt32();
                string mId = dr.GetData("mid").ToString();

                return new
                {
                    recordId = recordId,
                    mId = dr.GetData("mid").ToString(),
                    roomId = dr.GetData("roomid").ConvertToInt32(),
                    gameId = dr.GetData("gameid").ConvertToInt32(),
                    ownerId = dr.GetData("ownerid").ConvertToInt32(),
                    groupId = dr.GetData("groupid").ConvertToInt32(),
                    tableId = dr.GetData("tableid").ConvertToInt32(),
                    gameNum = dr.GetData("gameNum").ConvertToInt32(),
                    //rulestr = dr.GetData("rulestr").ConvertToInt32(),
                    //ruledesc = dr.GetData("ruledesc").ConvertToInt32(),
                    addtime = dr.GetData("addtime").ConvertToDateTime().GetTimestamp() * 1000,
                    userData = userTotalNum.Where(p => p.mid == mId).Select(p=>p.userItem).ToArray()
                };
            }).ToArray();

            int minStartId = -1;

            if (recGroupList.Length >= 1)
            {
                minStartId = recGroupList.Min(p => p.recordId);
            }


            return Json(new
            {
                status = "success",
                msg = "OK",
                data = recGroupList,
                nextStartId = minStartId
            });

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult getSubReplayList(string mId)
        {

            DataSet ds = null;

             
            int ret = DataProcedureHelper.WEB_GetUserReplayListDD(mId,(int)this.UserInfo.UserId, out ds);
            if (ret != 1)
            {
                return WriteFail("加载战绩详情列表数据失败！");
            }


            var tb1 = ds.Tables[0];
            var tb2 = ds.Tables[1];


            var userNum = tb2.Rows.Cast<DataRow>().Select(dr =>
            {
                return new
                {
                    recordid = dr.GetData("recordid").ConvertToInt32(),
                    item = new
                    {
                        userid = dr.GetData("userid").ConvertToInt32(),
                        moneynum = dr.GetData("moneynum").ConvertToInt32(),
                    }
                }; 
            });
            var subReplayList = tb1.Rows.Cast<DataRow>().Select(dr =>
            {
                int recordId = dr.GetData("recordid").ConvertToInt32();
                return new
                {
                    recordId = recordId,
                    recPath = dr.GetData("recPath").ToString(),
                    data = userNum.Where(p=>p.recordid == recordId).Select(p=>p.item).ToArray()
                };
            }).ToArray();


            return Json(new
            {
                status = "success",
                msg = "OK",
                data = subReplayList
            });

        }









        #region MyRegion

        /// <summary>
        /// 战绩玩家数据
        /// </summary>
        class recordRoomInfoItem
        {
            /// <summary>
            /// 战绩ID
            /// </summary>
            public uint recordId;
            /// <summary>
            /// 房间号
            /// </summary>
            public int roomId;
            /// <summary>
            /// 游戏ID
            /// </summary>
            public int gameId;
            /// <summary>
            /// mid
            /// </summary>
            public string mid;
            /// <summary>
            /// sid
            /// </summary>
            public string sid;
            /// <summary>
            /// 房主
            /// </summary>
            public int ownerId;
            /// <summary>
            /// 头像地址
            /// </summary>
            public string picFile;
            /// <summary>
            /// 玩法规则
            /// </summary>
            public string ruleStr;
            /// <summary>
            /// 规则描述
            /// </summary>
            public string ruleDesc;
            /// <summary>
            /// 时间
            /// </summary>
            public long addTime;
            /// <summary>
            /// 录像地址
            /// </summary>
            public string recPath;
            /// <summary>
            /// 每一局的详情
            /// </summary>
            public List<recordRoomDetailInfoItem> roundDetail;

        }
        /// <summary>
        /// 房间每局数详情
        /// </summary>
        class recordRoomDetailInfoItem
        {
            /// <summary>
            /// 战绩ID
            /// </summary>
            public uint recordId;
            /// <summary>
            /// 玩家ID
            /// </summary>
            public int userId;
            /// <summary>
            /// 分数
            /// </summary>
            public int moneyNum;
            /// <summary>
            /// 时间
            /// </summary>
            public long addTime;
            /// <summary>
            /// 昵称
            /// </summary>
            public string nickName;
        }
        #endregion
    }
}