using QL.Data;
using QLGameRESTAPI.Core.DBTools.Data;
using System.Data; 

namespace QLGameRESTAPI.Core.DBTools.Data
{



    /// <summary>
    /// 存储过程帮助类
    /// </summary>
    public partial class DataProcedureHelper
    {
        /// <summary>
        /// 执行存储过程 WEB_ALL_UserLogon 并返回执行结果
        /// </summary>
        public static int WEB_ALL_UserLogon(string _unionId, string _openId, string _nickName, string _header, int _snsId, string _ip, int _Gender, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?_unionId",_unionId),
                new CMySqlParameter("?_openId",_openId),
                new CMySqlParameter("?_nickName",_nickName),
                new CMySqlParameter("?_header",_header),
                new CMySqlParameter("?_snsId",_snsId),
                new CMySqlParameter("?_ip",_ip),
                new CMySqlParameter("?_Gender",_Gender),
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_ALL_UserLogon", parameters, out outDataSet));


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_GetRankList 并返回执行结果
        /// </summary>
        public static int WEB_GetRankList(int _userId, int _count, int rankType, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?_userId",_userId),
                new CMySqlParameter("?_count",_count),
                new CMySqlParameter("?rankType",rankType),
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_GetRankList", parameters, out outDataSet));


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_GetUserReplayList 并返回执行结果
        /// </summary>
        public static int WEB_GetUserReplayList(int _userId, int _startId, int _count, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?_userId",_userId),
                new CMySqlParameter("?_startId",_startId),
                new CMySqlParameter("?_count",_count),
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_GetUserReplayList", parameters, out outDataSet));


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_HallMsgList 并返回执行结果
        /// </summary>
        public static int WEB_HallMsgList(object in_msgobject, int in_objectid, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?in_msgobject",in_msgobject),
                new CMySqlParameter("?in_objectid",in_objectid),
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_HallMsgList", parameters, out outDataSet));


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_PyGroupAcceptJoin 并返回执行结果
        /// </summary>
        public static int WEB_PyGroupAcceptJoin(int _userid, int _joinid, int _friendid, int _status, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?_userid",_userid),
                new CMySqlParameter("?_joinid",_joinid),
                new CMySqlParameter("?_friendid",_friendid),
                new CMySqlParameter("?_status",_status),
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_PyGroupAcceptJoin", parameters, out outDataSet));


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_PyGroupAddRule 并返回执行结果
        /// </summary>
        public static int WEB_PyGroupAddRule(int _userid, int _friendid, int _gameid, string _rulestr, string _ruledesc, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?_userid",_userid),
                new CMySqlParameter("?_friendid",_friendid),
                new CMySqlParameter("?_gameid",_gameid),
                new CMySqlParameter("?_rulestr",_rulestr),
                new CMySqlParameter("?_ruledesc",_ruledesc),
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_PyGroupAddRule", parameters, out outDataSet));


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_PyGroupCreate 并返回执行结果
        /// </summary>
        public static int WEB_PyGroupCreate(int _userid, string _name, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?_userid",_userid),
                new CMySqlParameter("?_name",_name),
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_PyGroupCreate", parameters, out outDataSet));


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_PyGroupDeleteRule 并返回执行结果
        /// </summary>
        public static int WEB_PyGroupDeleteRule(int _userid, int _friendid, int _ruleid, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?_userid",_userid),
                new CMySqlParameter("?_friendid",_friendid),
                new CMySqlParameter("?_ruleid",_ruleid),
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_PyGroupDeleteRule", parameters, out outDataSet));


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_PyGroupList 并返回执行结果
        /// </summary>
        public static int WEB_PyGroupList(int _userid, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?_userid",_userid),
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_PyGroupList", parameters, out outDataSet));


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_PyGroupMsgList 并返回执行结果
        /// </summary>
        public static int WEB_PyGroupMsgList(int _friendid, int _userId, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?_friendid",_friendid),
                new CMySqlParameter("?_userId",_userId),
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_PyGroupMsgList", parameters, out outDataSet));


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_PyGroupRuleList 并返回执行结果
        /// </summary>
        public static int WEB_PyGroupRuleList(int _friendid, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?_friendid",_friendid),
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_PyGroupRuleList", parameters, out outDataSet));


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_PyGroupSetAdmin 并返回执行结果
        /// </summary>
        public static int WEB_PyGroupSetAdmin(int _userid, int _aid, int _isadmin, int _friendid, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?_userid",_userid),
                new CMySqlParameter("?_aid",_aid),
                new CMySqlParameter("?_isadmin",_isadmin),
                new CMySqlParameter("?_friendid",_friendid),
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_PyGroupSetAdmin", parameters, out outDataSet));


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_PyGroupSetInfo 并返回执行结果
        /// </summary>
        public static int WEB_PyGroupSetInfo(int _userid, int _friendid, string _title, string _notice, out string _errMsg, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?_userid",_userid),
                new CMySqlParameter("?_friendid",_friendid),
                new CMySqlParameter("?_title",_title),
                new CMySqlParameter("?_notice",_notice),
                new CMySqlParameter("?_errMsg", null) { Direction = ParameterDirection.Output},
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_PyGroupSetInfo", parameters, out outDataSet));
            _errMsg = (string)(parameters[4].Value ?? "");


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_PyGroupUpdate 并返回执行结果
        /// </summary>
        public static int WEB_PyGroupUpdate(int _userid, int _friendid, string _name, string _notice, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?_userid",_userid),
                new CMySqlParameter("?_friendid",_friendid),
                new CMySqlParameter("?_name",_name),
                new CMySqlParameter("?_notice",_notice),
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_PyGroupUpdate", parameters, out outDataSet));


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_PyGroupUserExit 并返回执行结果
        /// </summary>
        public static int WEB_PyGroupUserExit(int _userid, int _friendid, int _exitid, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?_userid",_userid),
                new CMySqlParameter("?_friendid",_friendid),
                new CMySqlParameter("?_exitid",_exitid),
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_PyGroupUserExit", parameters, out outDataSet));


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_PyGroupUserJoin 并返回执行结果
        /// </summary>
        public static int WEB_PyGroupUserJoin(int _userid, int _friendid, out string _errmsg, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?_userid",_userid),
                new CMySqlParameter("?_friendid",_friendid),
                new CMySqlParameter("?_errmsg", null) { Direction = ParameterDirection.Output},
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_PyGroupUserJoin", parameters, out outDataSet));
            _errmsg = (string)(parameters[2].Value ?? "");


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_PyGroupUserList 并返回执行结果
        /// </summary>
        public static int WEB_PyGroupUserList(int _userid, int _friendid, int _startid, int _size, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?_userid",_userid),
                new CMySqlParameter("?_friendid",_friendid),
                new CMySqlParameter("?_startid",_startid),
                new CMySqlParameter("?_size",_size),
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_PyGroupUserList", parameters, out outDataSet));


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_SetUserReadMsg 并返回执行结果
        /// </summary>
        public static int WEB_SetUserReadMsg(object in_msgobject, int in_objectid, int in_msgid, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?in_msgobject",in_msgobject),
                new CMySqlParameter("?in_objectid",in_objectid),
                new CMySqlParameter("?in_msgid",in_msgid),
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_SetUserReadMsg", parameters, out outDataSet));


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_UserPayRequest 并返回执行结果
        /// </summary>
        public static int WEB_UserPayRequest(int in_userid, int _shopId, string in_outNo, out object _rmb, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?in_userid",in_userid),
                new CMySqlParameter("?_shopId",_shopId),
                new CMySqlParameter("?in_outNo",in_outNo),
                new CMySqlParameter("?_rmb", null) { Direction = ParameterDirection.Output},
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_UserPayRequest", parameters, out outDataSet));
            _rmb = (object)(parameters[3].Value ?? null);


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_UserPayResult 并返回执行结果
        /// </summary>
        public static int WEB_UserPayResult(string in_orderid, object in_status, object in_realrmb, object in_paytype, string in_remark, object in_returnflage, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?in_orderid",in_orderid),
                new CMySqlParameter("?in_status",in_status),
                new CMySqlParameter("?in_realrmb",in_realrmb),
                new CMySqlParameter("?in_paytype",in_paytype),
                new CMySqlParameter("?in_remark",in_remark),
                new CMySqlParameter("?in_returnflage",in_returnflage),
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_UserPayResult", parameters, out outDataSet));


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_UserSharedResult 并返回执行结果
        /// </summary>
        public static int WEB_UserSharedResult(string in_taskid, int in_user, string in_remark, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?in_taskid",in_taskid),
                new CMySqlParameter("?in_user",in_user),
                new CMySqlParameter("?in_remark",in_remark),
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_UserSharedResult", parameters, out outDataSet));


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_GetUserReplayListDD 并返回执行结果
        /// </summary>
        public static int WEB_GetUserReplayListDD(string _mid, int _userId, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?_mid",_mid),
                new CMySqlParameter("?_userId",_userId),
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_GetUserReplayListDD", parameters, out outDataSet));


            return returnVal;
        }
        /// <summary>
        /// 执行存储过程 WEB_GetUserReplayListMM 并返回执行结果
        /// </summary>
        public static int WEB_GetUserReplayListMM(int _userId, int _startId, int _count, out DataSet outDataSet)
        {
            CMySqlParameter[] parameters = {
                new CMySqlParameter("?_userId",_userId),
                new CMySqlParameter("?_startId",_startId),
                new CMySqlParameter("?_count",_count),
                new CMySqlParameter("?returnvalue", null) { Direction = ParameterDirection.Output},

            };
            int returnVal = (int)(DbHelperSQL.Instance.RunProcedure("WEB_GetUserReplayListMM", parameters, out outDataSet));


            return returnVal;
        }



    }



}
