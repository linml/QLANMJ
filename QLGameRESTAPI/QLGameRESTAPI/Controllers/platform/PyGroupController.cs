using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL.Extension;
using QLGameRESTAPI.Core.DBTools.Data;

namespace QLGameRESTAPI.Controllers.platform
{
    /// <summary>
    /// PlatformController
    /// </summary>
    [Core.CustomRoute(version: Core.CustomType.ApiVersions.platfrom)]
    public class PyGroupController : Extensions.UserSessionKeyRequestBase
    {
        /// <summary>
        /// 玩家创建亲友圈
        /// </summary>
        /// <param name="name">亲友圈的名称</param> 
        /// <returns></returns>
        [HttpPost]
        public IActionResult create(string name)
        {
            var u = this.UserInfo;
            if (u == null)
            {
                return WriteFail("参数无效");
            }

            DataSet ds;
            int ret = DataProcedureHelper.WEB_PyGroupCreate(
                 _userid: (int)u.UserId,
                 _name: name,
                 outDataSet: out ds
                 );

            if (ret != 1)
            {
                return WriteFail("创建亲友圈失败");
            }
            else
            {
                return WriteSuccess("OK");
            }
        }
        /// <summary>
        /// 玩家加入亲友圈
        /// </summary>
        /// <param name="groupId">亲友圈Id</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult userjoin(int groupId)
        {
            var u = this.UserInfo;
            if (u == null)
            {
                return WriteFail("参数无效");
            }

            string errmsg;
            DataSet ds;
            int ret = Core.DBTools.Data.DataProcedureHelper.WEB_PyGroupUserJoin(
                _userid: (int)u.UserId,
                _errmsg: out errmsg,
                _friendid: groupId,
                outDataSet: out ds
                );

            if (ret != 1)
            {
                return WriteFail(errmsg);
            }

            return WriteSuccess();


        }
        /// <summary>
        /// 管理员同意或者拒绝玩家加入亲友圈的申请
        /// </summary>
        /// <param name="logId">需要操作的请求Id</param>
        /// <param name="groupId">指定是在哪一个亲友圈</param>
        /// <param name="status">操作状态：1接受，2拒绝</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult acceptjoin(int logId, int groupId, int status)
        {
            var u = this.UserInfo;
            if (u == null)
            {
                return WriteFail("参数无效");
            }


            DataSet ds;
            int ret = DataProcedureHelper.WEB_PyGroupAcceptJoin(
                _userid: (int)u.UserId,
               _friendid: groupId,
               _joinid: logId,
               _status: status,
               outDataSet: out ds);


            if (ret == 1)
            {
                return WriteSuccess();
            }

            return WriteFail("操作失败");

        }
        /// <summary>
        /// 玩家退出（踢出）亲友圈
        /// </summary>
        /// <param name="exitId">要退出或者被踢出的玩家Id</param>
        /// <param name="groupId">指定要从哪一个亲友圈退出</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult userexit(int exitId, int groupId)
        {
            var u = this.UserInfo;
            if (u == null)
            {
                return WriteFail("参数无效");
            }

            DataSet ds;
            int ret = DataProcedureHelper.WEB_PyGroupUserExit(
                _userid: (int)u.UserId,
                _friendid: groupId,
                _exitid: exitId,
                outDataSet: out ds);


            if (ret == 1)
            {
                return WriteSuccess();
            }

            return WriteFail("操作失败");



        }
        /// <summary>
        /// 加载玩家加入的亲友圈列表
        /// </summary>
        /// <returns>输出玩家已经加入的亲友圈列表</returns>
        [HttpPost]
        public IActionResult getlist()
        {
            var u = this.UserInfo;
            if (u == null)
                return WriteFail("参数错误");


            DataSet ds;
            int ret = DataProcedureHelper.WEB_PyGroupList(
                _userid: (int)u.UserId,
                outDataSet: out ds);


            if (ret != 1)
            {
                return WriteFail("加载失败！");
            }
            else
            {


                var _list = ds.Tables[0].Rows.Cast<DataRow>().Select(dr =>
                {
                    return new
                    {
                        Header = dr.GetData("Header").ToString(),
                        UserId = dr.GetData("UserId").ConvertToInt32(),
                        Id = dr.GetData("Id").ConvertToInt32(),
                        Name = dr.GetData("Name").ToString(),
                        UserCount = dr.GetData("UserCount").ConvertToInt32(),
                        MaxUserCount = dr.GetData("MaxUserCount").ConvertToInt32(),
                        notice = dr.GetData("notice").ToString(),
                    };
                });

                return Json(new
                {
                    status = "success",
                    data = _list.ToArray()
                });

            }


        }
        /// <summary>
        /// 获取指定亲友圈的玩法信息
        /// </summary>
        /// <param name="groupId">亲友圈Id</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult getrulelist(int groupId)
        {
            var u = this.UserInfo;
            if (u == null)
                return WriteFail("参数错误");


            DataSet ds;
            int ret = DataProcedureHelper.WEB_PyGroupRuleList(groupId, out ds);


            if (ret != 1)
            {
                return WriteFail("加载失败！");
            }

            var _list = ds.Tables[0].Rows.Cast<DataRow>().Select(dr =>
           {
               return new pygroupRuleItem()
               {
                   GameId = dr.GetData("GameId").ConvertToInt32(),
                   Id = dr.GetData("Id").ConvertToInt32(),
                   GameName = dr.GetData("GameName").ToString(),
                   ModuleName = dr.GetData("modulename").ToString(),
                   RuleStr = dr.GetData("RuleStr").ToString(),
                   RuleDesc = dr.GetData("RuleDesc").ToString(),

               };
           });




            return Json(new
            {
                status = "success",
                data = _list.ToArray()
            });


        }
        /// <summary>
        /// 获取指定亲友圈的成员列表
        /// </summary>
        /// <param name="groupId">亲友圈Id</param>
        /// <param name="startId">起始编号</param>
        /// <param name="count">查询的数量</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult getuserlist(int groupId, int startId, int count)
        {
            var u = this.UserInfo;
            if (u == null)
                return WriteFail("参数错误");
            if (startId == 0)
            {
                startId = int.MaxValue;
            }
            DataSet ds;
            int ret = DataProcedureHelper.WEB_PyGroupUserList(
                _userid: (int)u.UserId,
                _friendid: groupId,
                _size: count,
                _startid: startId,
                outDataSet: out ds);

            if (ret !=1)
            {
                return WriteFail("加载成员列表失败");
            }

            var _items = ds.Tables[0].Rows.Cast<DataRow>().Select(dr =>
            {
                return new
                {
                    id = dr.GetData("id").ConvertToInt32(),
                    Header = dr.GetData("Header").ToString(),
                    IsAdmin = dr.GetData("IsAdmin").ConvertToInt32(),
                    UserId = dr.GetData("UserId").ConvertToUInt32(),
                    Name = dr.GetData("Name").ToString(),

                };
            }).ToArray();
            int nextId = -1;
            if (_items.Length > 0)
            {
                nextId = _items.Min(p => p.id);
            }


            return Json(new
            {
                status = "success",
                data = _items,
                nextId = nextId
            });


        }
        /// <summary>
        /// 添加亲友圈玩法
        /// </summary>
        /// <param name="groupId">亲友圈Id</param>
        /// <param name="gameId">添加规则的游戏</param>
        /// <param name="ruleStr">添加规则的特殊字符串</param>
        /// <param name="ruleDesc">规则的描述</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult addrule(int groupId, int gameId, string ruleStr, string ruleDesc)
        {
            var u = this.UserInfo;
            if (u == null)
                return WriteFail("参数错误");


            DataSet ds;
            int ret = DataProcedureHelper.WEB_PyGroupAddRule(
                _userid: (int)u.UserId,
                _friendid: groupId,
                _gameid: gameId,
                _ruledesc: ruleDesc,
                _rulestr: ruleStr,
                outDataSet: out ds);



            if (ret == 1)
            {
                return WriteSuccess();
            }

            return WriteFail("操作失败");
        }
        /// <summary>
        /// 删除亲友圈的规则玩法
        /// </summary>
        /// <param name="groupId">指定亲友圈Id</param>
        /// <param name="ruleId">指定要删除的规则Id</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult deleterule(int groupId, int ruleId)
        {
            var u = this.UserInfo;
            if (u == null)
                return WriteFail("参数错误");


            DataSet ds;
            int ret = DataProcedureHelper.WEB_PyGroupDeleteRule(
                _userid: (int)u.UserId,
                _friendid: groupId,
                _ruleid: ruleId,
                outDataSet: out ds);

            if (ret == 1)
            {
                return WriteSuccess();
            }

            return WriteFail("操作失败");
        }
        /// <summary>
        /// 添加或者删除管理员
        /// </summary>
        /// <param name="userid">要添加的玩家Id</param>
        /// <param name="groupId">指定亲友圈Id</param>
        /// <param name="isadmin">指定是否是管理员 1是管理员 ，0 不是管理员</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult setadmin(int userid, int groupId, int isadmin)
        {

            var u = this.UserInfo;
            if (u == null)
                return WriteFail("参数错误");

            isadmin = isadmin == 1 ? 1 : 0;

            DataSet ds;
            int ret = DataProcedureHelper.WEB_PyGroupSetAdmin(
                _userid: (int)u.UserId,
                _friendid: groupId,
                _aid: userid,
                _isadmin: isadmin,
                outDataSet: out ds);

            if (ret == 1)
            {
                return WriteSuccess();
            }

            return WriteFail("操作失败");
        }
        /// <summary>
        /// 获取亲友圈消息列表
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult loadmsg(int groupId)
        {

            var u = this.UserInfo;
            if (u == null)
                return WriteFail("参数错误");

            DataSet ds;
            int ret = QLGameRESTAPI.Core.DBTools.Data.DataProcedureHelper.WEB_PyGroupMsgList(
                _friendid: groupId,
                _userId: (int)u.UserId,
                outDataSet: out ds
                );

            if (ret != 1 || ds.Tables.Count <= 0)
            {
                return WriteFail("获取信息失败！");
            }

            var tb = ds.Tables[0];

            return Json(new
            {
                status = "success",
                msg = "OK",
                column = tb.Columns.Cast<DataColumn>().Select(p => p.ColumnName).ToArray(),
                data = tb.GetDataTableArray(),



            });



        }
        /// <summary>
        /// 修改亲友圈信息
        /// </summary>
        /// <param name="notice">公告内容</param>
        /// <param name="title">公告标题</param>
        /// <param name="friendId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult setinfo(int friendId, string notice, string title)
        {
            var u = this.UserInfo;
            if (u == null)
            {
                return WriteFail("请求参数错误");
            }

            int ret = QLGameRESTAPI.Core.DBTools.Data.DataProcedureHelper.WEB_PyGroupSetInfo(_userid: (int)u.UserId,
                _friendid: friendId,
                _title: title,
                _notice: notice,
                outDataSet: out DataSet ds,
                _errMsg: out string errMsg);

            if (ret != 1)
            {
                return WriteFail(errMsg);
            }

            return WriteSuccess("OK");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="friendId"></param>
        /// <param name="tableId"></param>
        /// <returns></returns>
        [HttpPost]
        public Task<IActionResult> getTableInfo(int friendId, int tableId)
        {
            TaskCompletionSource<IActionResult> taskComplete = new TaskCompletionSource<IActionResult>();

            QL.Server.RedisOP.RedisOperation.GetCreateTableInfo((uint)tableId, cr =>
             {
                 IActionResult result;

                 if (cr == null)
                 {
                     result = WriteFail("房间信息不存在");
                 }
                 else
                 {

                     result = Json(new
                     {
                         status = "success",
                         data = cr
                     });
                 }

                 if (result == null)
                 {
                     result = WriteFail("房间信息不存在");
                 }

                 taskComplete.TrySetResult(result);
             });

            return taskComplete.Task;
        }


        #region MyRegion

        /// <summary>
        /// 亲友圈列表数据
        /// </summary>
        class pygrouplistItem
        {
            /// <summary>
            /// 亲友圈编号
            /// </summary>
            public int Id;
            /// <summary>
            /// 圈主ID
            /// </summary>
            public int UserId;
            /// <summary>
            /// 名称
            /// </summary>
            public string Name;
            /// <summary>
            /// 亲友圈圈主头像
            /// </summary>
            public string Header;
            /// <summary>
            /// 亲友圈成员的数量
            /// </summary>
            public int UserCount;
            /// <summary>
            /// 
            /// </summary>
            public int MaxUserCount;
        }
        class pygroupRuleItem
        {
            public int Id;
            public int GameId;
            public string GameName;
            public string RuleStr;
            public string RuleDesc;
            public string ModuleName;
        }
        class pyGroupUserInfoItem
        {
            public uint UserId;
            public string Name;
            public string Header;
            public int IsAdmin;

        }
        #endregion
    }
}