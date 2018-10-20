using QL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL.Extension;
using QL.Net;
using QL.Web;

namespace ZenTaoWebHook
{
    class Program
    {
        public static ConfigData C => ConfigData.Instance;
        static QLDBHelper H
        {
            get
            {
                return new QLDBHelper(C.MysqlConstr, QL.DBHelper.DBEntityProvideHelper.GetMySqlDBEntityProvide());
            }
        }
        static readonly string[] emstringarray = new string[0];

        const string colName = "phone";
        const string newLine = "\n";



        static void Main(string[] args)
        {
            var Server = new QL.Net.Pipeline.QLWebServer(C.WebPort);
            Server.NewRequest = ServerNewRequest;
            Server.Start();
            Console.WriteLine("服务启动成功");
            while (true)
            {
                Console.ReadKey();
            }
        }

        private static void ServerNewRequest(object sender, IWebServerRequestContext e)
        {
            try
            {
                DoServerNewRequest(sender, e);
            }
            catch (Exception ex)
            {
                UyiDebug.WriteLog(UyiDebug.GetErrorFormatString(ex));
            }
        }
        private static void DoServerNewRequest(object sender, IWebServerRequestContext e)
        {
            var token = e.Context.Request.QueryString["token"];

            UyiDebug.WriteLog($"请求Token：{token}");
            if (string.IsNullOrEmpty(token))
            {
                UyiDebug.WriteLog($"请求Token 为空");
                return;
            }
            var json = e.GetPostData();
            if (string.IsNullOrEmpty(json))
            {
                UyiDebug.WriteLog($"请求Json 为空");
                return;
            }


            UyiDebug.WriteLog($"请求数据：{json}");

            var p = WebParamData.FromJson(json);

            var objectID = p["objectID"];
            var text = p["text"];
            var objectType = p["objectType"];
            var action = p["action"];


            var send_json = BuildDingDingMsg(objectType, objectID, action,text);

            UyiDebug.WriteLog(send_json);
            HttpHelper.PostStringAsync(string.Format(C.HookUrl, token), send_json, HttpHelper.ContextType.JSON);


        }





        private static string BuildDingDingMsg(string objectType, string objectID, string action, string text)
        {

            UserInfo userInfo = default(UserInfo);
            bool isAtAll = false;
            switch (objectType)
            {
                case "task":
                case "bug":
                    userInfo = GetDefaultUserInfo(objectID, objectType, action);
                    break;
                case "testtask":
                    userInfo = GetTestUserInfo(objectID, objectType, action);
                    break;
                case "case":
                    isAtAll = false;
                    break;
                default:
                    isAtAll = true;
                    break;
            }
            //处理消息内容
            int i = text.LastIndexOf(")");
            if (i > 0)
                text = text.Insert(i, " ");
            if (!string.IsNullOrEmpty(userInfo.realname))
                text += userInfo.realname;

            var atMobiles = new string[0];
            if (userInfo.mobile != null)
            {
                atMobiles = userInfo.mobile;
            }
            var atMobilesg = atMobiles.GroupBy(k => k).Select(k => k.Key).ToArray();
            if (!isAtAll)
                isAtAll = atMobilesg.Length >= 5;


            return new
            {
                msgtype = "text",
                text = new
                {
                    content = text
                },
                at = new
                {
                    atMobiles = isAtAll ? emstringarray : atMobilesg,
                    isAtAll = isAtAll
                }
            }.ToJson();

        }
        private static UserInfo GetTestUserInfo(string objectID, string objectType, string action)
        {

            try
            {
                bool mailTo = true;
                string sql;
                switch (action)
                {
                    default:
                        sql = $"SELECT realname,{colName} from zt_user where account = (SELECT owner from zt_{objectType} where id={objectID} limit 1);";
                        break;

                }

                string[] m = null;
                string realname = "";


                System.Data.DataSet ds;
                {
                    H.RunSql(sql, out ds);
                    var u = ConvertUserInfoFromDataSet(ds);
                    m = m.ArrayConcat(u.mobile);
                    if (!string.IsNullOrEmpty(u.realname))
                    {
                        realname += $"{newLine}指派给：{u.realname}";
                    }
                }
                if (mailTo)
                {
                    var u = GetMailToUser(objectType, objectID);
                    m = m.ArrayConcat(u.mobile);
                    if (!string.IsNullOrEmpty(u.realname))
                    {
                        realname += $"{newLine}抄送给：{u.realname}";
                    }
                }

                return new UserInfo()
                {
                    mobile = m,
                    realname = realname,
                };
            }
            catch (Exception ex)
            {
                return default(UserInfo);
            }
        }
        private static UserInfo GetDefaultUserInfo(string objectID, string objectType, string action)
        {
            try
            {
                string openedBy = $@"SELECT realname,{colName} from zt_user where account = (SELECT openedBy from zt_{objectType} where id={objectID} limit 1);"; ;
                string assignedTo = $"SELECT realname,{colName} from zt_user where account = (SELECT assignedTo from zt_{objectType} where id={objectID} limit 1);";
                bool mailTo = true; //指示是否需要标记抄送信息

                switch (action)
                {
                    case "resolved":
                    case "finished":
                        mailTo = false;
                        break;
                    case "closed":
                    case "canceled":
                        mailTo = false;
                        assignedTo = null;
                        break;
                    default:
                        openedBy = null;
                        break;
                }
                //计算需要@的用户手机号码
                string[] mobiles = null;
                string realname = "";
                System.Data.DataSet ds;
                if (!string.IsNullOrEmpty(openedBy))
                {
                    H.RunSql(openedBy, out ds);
                    var u = ConvertUserInfoFromDataSet(ds);
                    mobiles = mobiles.ArrayConcat(u.mobile);
                    if (!string.IsNullOrEmpty(u.realname))
                    {
                        realname += $"{newLine}通知给：{u.realname}";
                    }
                }
                if (!string.IsNullOrEmpty(assignedTo))
                {
                    H.RunSql(assignedTo, out ds);
                    var u = ConvertUserInfoFromDataSet(ds);
                    mobiles = mobiles.ArrayConcat(u.mobile);
                    if (!string.IsNullOrEmpty(u.realname))
                    {
                        realname += $"{newLine}指派给：{u.realname}";
                    }
                }
                if (mailTo)
                {
                    var u = GetMailToUser(objectType, objectID);
                    mobiles = mobiles.ArrayConcat(u.mobile);
                    if (!string.IsNullOrEmpty(u.realname))
                    {
                        realname += $"{newLine}抄送给：{u.realname}";
                    }
                }

                return new UserInfo()
                {
                    mobile = mobiles,
                    realname = realname
                };

            }
            catch (Exception ex)
            {
                return default(UserInfo);
            }

        }
        private static UserInfo GetMailToUser(string objectType, string objectID)
        {
            var getMailTo = $"SELECT mailto from zt_{objectType} where id={objectID} limit 1;";
            System.Data.DataSet ds;
            H.RunSql(getMailTo, out ds);
            if (ds.Tables.Count <= 0) return default(UserInfo);
            var drs = ds.Tables[0].Rows;
            if (drs.Count <= 0) return default(UserInfo);

            var mTos = drs[0]["mailto"].ToString().Split(',').Where(p => !string.IsNullOrEmpty(p)).Select(p => $"'{p}'").ToArray();
            if (mTos.Length <= 0) return default(UserInfo);

            var u = $"SELECT realname,{colName} from zt_user where account in ({mTos.MapString(',')})";


            H.RunSql(u, out ds);
            return ConvertUserInfoFromDataSet(ds);

        }


        private static UserInfo ConvertUserInfoFromDataSet(System.Data.DataSet ds)
        {
            if (ds.Tables.Count <= 0) return default(UserInfo);
            var tb = ds.Tables[0];
            if (tb.Rows.Count <= 0) return default(UserInfo);
            var drs = tb.Rows;
            var realname = drs.Cast<System.Data.DataRow>()
                .Select(dr => dr["realname"].ToString())
                .Where(p => !string.IsNullOrEmpty(p))
                .ToArray()
                .MapString('，');

            var mobile = drs.Cast<System.Data.DataRow>()
                .Select(dr => dr[colName].ToString())
                .Where(p => !string.IsNullOrEmpty(p))
                .ToArray();

            return new UserInfo()
            {
                mobile = mobile,
                realname = realname,
            };

        }
        struct UserInfo
        {
            public string realname;
            public string[] mobile;
        }
    }
}
