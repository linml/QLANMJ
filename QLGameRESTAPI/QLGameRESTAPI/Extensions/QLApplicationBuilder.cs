using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGameRESTAPI.Core.Express
{

    /// <summary>
    /// 
    /// </summary>
    public static class QLApplicationBuilder
    {

        static bool isFirst = true;


        private static Task ErrorEvent(HttpContext context)
        {
            var feature = context.Features.Get<IExceptionHandlerFeature>();
            var error = feature?.Error;
            Global.Instance.QLDebug.WriteError(error);
            context.Response.StatusCode = 500;
            return context.Response.WriteAsync("系统未知异常，请联系管理员");

        }
        private static void RedisOperation_RedisMessageComing(object sender, GameIF.RedisMessage e)
        {
            //throw new NotImplementedException();
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public static void AddQLRedisServices(this IServiceCollection app)
        {

            QL.Server.RedisOP.RedisOperation.ServerType = QL.Common.ServerType.WebApiServer;
            QL.Server.RedisOP.RedisOperation.RedisMessageComing += RedisOperation_RedisMessageComing;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public static void UseQLExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(iab => iab.Run(ErrorEvent));
        }
        /// <summary>
        /// 
        /// </summary>
        public static void UseHttpIndexHandle(this IApplicationBuilder app)
        {
            app.Use((context, next) =>
            {
                if (isFirst)
                {
                    Console.SetOut(System.IO.TextWriter.Null);
                    isFirst = false;
                }
                var req = context.Request;
                if (req.Path.Value == "/")
                {
                    var res = context.Response; ;
                    res.StatusCode = 200;
                    res.WriteAsync("200");
                    return null;
                }
                return next();
            });
        }




    }
}
