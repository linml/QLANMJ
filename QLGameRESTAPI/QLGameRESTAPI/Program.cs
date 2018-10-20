using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace QLGameRESTAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            QL.QLSystemErrorProvide.QLSystemLogHandle += SystemErrorProvide_QLSystemLogHandle;
            QL.QLSystemErrorProvide.QLSystemErrorHandle += SystemErrorProvide_UyiSystemErrorHandle;


            BuildWebHost(args).Run();
        }

        private static void SystemErrorProvide_UyiSystemErrorHandle(object sender, Exception e)
        {
            Core.Global.Instance.QLDebug.WriteError(e);
        }

        private static void SystemErrorProvide_QLSystemLogHandle(object sender, string e)
        {
            Core.Global.Instance.QLDebug.WriteLog(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHost BuildWebHost(string[] args)
        {
            int servicesPort = Core.Global.Instance.ConfigManager.ServicesPort;
           return WebHost.CreateDefaultBuilder(args)
                .UseUrls($"http://0.0.0.0:{servicesPort}")
                .UseStartup<Startup>()
                .Build();
        }
    }
}
