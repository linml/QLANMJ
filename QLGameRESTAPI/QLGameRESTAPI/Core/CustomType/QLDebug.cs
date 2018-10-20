using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL;
using QL.Tools;

namespace QLGameRESTAPI.Core.CustomType
{
    /// <summary>
    /// 
    /// </summary>
    public class QLDebug : IQLDebug
    {
        private class QLDebugHelper : QLDebugBase<QLDebugHelper>
        {
            protected override string ServerName => "Request";

            public override void OnPrintError(Exception err, Stream stream = null, string fname = null, string[] emils = null)
            {
                //throw new NotImplementedException();
            }

            public override void OnShowMsg(string msg, ShowMsgColor color)
            {
                //throw new NotImplementedException();
            }
        }
        private class QLErrorLog : QLDebugHelper
        {
            protected override string ServerName => "Error";
        }
        private class QLPayLog : QLDebugHelper
        {
            protected override string ServerName => "Pay";
        }

        static object root = new object();
        static string _hostName;
        /// <summary>
        /// 
        /// </summary>
        public static string HostName
        {
            get
            {
                try
                {
                    if (!string.IsNullOrEmpty(_hostName))
                    {
                        return _hostName;
                    }
                    _hostName = System.Net.Dns.GetHostName();
                    if (!string.IsNullOrEmpty(_hostName))
                    {
                        _hostName = HostName.Trim();
                    }
                    return _hostName;
                }
                catch (Exception)
                {
                    return "UnKnown";
                }

            }
        }


        IMessageQueue<LogEntity> _mq = new MessageQueue<LogEntity>();
        IMessageQueue<LogEntity> _error_log_mq = new MessageQueue<LogEntity>();
        IMessageQueue<LogEntity> _pay_log_mq = new MessageQueue<LogEntity>();

        /// <summary>
        /// 
        /// </summary>
        public QLDebug()
        {
            _mq.MessageComing = Mq_MessageComing;
            _error_log_mq.MessageComing = ErrorLogMqMessageComing;
            _pay_log_mq.MessageComing = PayLogMqMessageComing;
        }


        private static void PayLogMqMessageComing(IMessageQueue<LogEntity> sender, MessageEventArgs<LogEntity> e)
        {
            _mq_MessageComing(e.Message, 3);
        }
        private static void ErrorLogMqMessageComing(IMessageQueue<LogEntity> sender, MessageEventArgs<LogEntity> e)
        {
            _mq_MessageComing(e.Message, 2);
        }
        private static void Mq_MessageComing(IMessageQueue<LogEntity> sender, MessageEventArgs<LogEntity> e)
        {
            _mq_MessageComing(e.Message, 1);
        }
        private static void _mq_MessageComing(LogEntity context, byte type)
        {
            if (context == null) return;
            if (string.IsNullOrWhiteSpace(context.Context)) return;
            try
            {
                switch (context.TAG)
                {
                    case LogTAG.Pay:
                        {
                            QLPayLog.WriteCilentLog(context.Context);
                            break;
                        }
                    case LogTAG.Error:
                        {
                            QLPayLog.WriteCilentLog(context.Context);
                            break;
                        }
                    default:
                        {
                            QLDebugHelper.WriteCilentLog(context.Context);
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string GetErrorFormatString(Exception ex)
        {

            if (ex == null)
                throw new NullReferenceException();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("\t*********************异常文本*********************");
            sb.AppendLine("\t【出现时间】：" + DateTime.Now.ToString());

            sb.AppendLine("\t【异常类型】：" + ex.GetType().Name);
            sb.AppendLine("\t【异常信息】：" + ex.Message);
            sb.AppendLine("\t【堆栈调用】：" + ex.StackTrace);
            sb.AppendLine("\t******************************************************************");

            if (ex.InnerException != null)
            {
                sb.AppendLine(GetErrorFormatString(ex.InnerException));
            }

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void WriteLog(string context)
        {
            LogEntity log = new LogEntity()
            {
                Context = context, 
                TAG = LogTAG.Debug
            };
            _mq.Enqueue(log);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public void WriteError(Exception ex)
        {
            WriteErrorString(GetErrorFormatString(ex));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void WriteErrorString(string context)
        {
            LogEntity log = new LogEntity()
            {
                Context = context, 
                TAG = LogTAG.Error
            };
            _error_log_mq.Enqueue(log);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void WritePayLog(string context)
        {
            LogEntity log = new LogEntity()
            {
                Context = context, 
                TAG = LogTAG.Pay
            };
            _pay_log_mq.Enqueue(log);
        }



    }

    class LogEntity
    { 
        public string Context;
        public LogTAG TAG = LogTAG.Debug;
    }
    enum LogTAG
    {
        Debug,
        Pay,
        Error
    }

}
