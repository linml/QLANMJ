using Microsoft.AspNetCore.Http;
using System;

namespace QLGameRESTAPI.Core
{
    public class HttpContextHelper
    {

        public static IServiceProvider ServiceProvider;

        /// <summary>
        /// 获取当前请求的上下文
        /// </summary>
        public static HttpContext Current
        {
            get
            {
                object factory = ServiceProvider?.GetService(typeof(IHttpContextAccessor));
                return (factory as IHttpContextAccessor)?.HttpContext;
            }
        }
    }
}
