using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL;
using QL.Tools;

namespace QLGameRESTAPI.Core
{
    public static class QLDebug
    {
        static object root = new object();


        static IMessageQueue<LogEntity> _mq = new MessageQueue<LogEntity>();
        static IMessageQueue<LogEntity> _error_log_mq = new MessageQueue<LogEntity>();
        static IMessageQueue<LogEntity> _pay_log_mq = new MessageQueue<LogEntity>();
        public static string HostName = "UnKnown";

        static QLDebug()
        {
            _mq.MessageComing = Mq_MessageComing;
            _error_log_mq.MessageComing = ErrorLogMqMessageComing;
            _pay_log_mq.MessageComing = PayLogMqMessageComing;

            try
            {
                HostName = System.Net.Dns.GetHostName();
                var _invalidFileNameChars = System.IO.Path.GetInvalidFileNameChars();
                foreach (var s in _invalidFileNameChars)
                {
                    HostName = HostName.Replace(s + "", "");
                }
                HostName = HostName.Replace("/", "_");
                HostName = HostName.Replace("\\", "_");
                HostName = HostName.Trim();
                if (string.IsNullOrEmpty(HostName))
                {
                    HostName = "UnKnown";
                }
            }
            catch (Exception)
            {
                HostName = "UnKnown";
            }
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
            if (string.IsNullOrWhiteSpace(context.Domain))
            {
                context.Domain = HostName;
            }
            try
            {
                //WcfHelperManager.WebLogProvider.SaveWebRunLog(context.Domain, type, context.Context);
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

#if !TRACE
        [System.Diagnostics.Conditional("TRACE")] 
#endif
        public static void WriteLog(string context)
        {
            LogEntity log = new LogEntity()
            {
                Context = context,
                Domain = HttpContextHelper.Current?.Request?.Host.Host
            };
            _mq.Enqueue(log);
        }
        public static void WriteError(Exception ex)
        {
            WriteErrorString(GetErrorFormatString(ex));
        }
        public static void WriteErrorString(string context)
        {
            LogEntity log = new LogEntity()
            {
                Context = context,
                Domain = HttpContextHelper.Current?.Request?.Host.Host
            };
            _error_log_mq.Enqueue(log);
        }
        public static void WritePayLog(string context)
        {
            LogEntity log = new LogEntity()
            {
                Context = context,
                Domain = HttpContextHelper.Current?.Request?.Host.Host
            };
            _pay_log_mq.Enqueue(log);
        }

    }

    class LogEntity
    {
        public string Domain;
        public string Context;
    }

}
