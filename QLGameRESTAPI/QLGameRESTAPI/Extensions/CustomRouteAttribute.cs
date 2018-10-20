using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGameRESTAPI.Extensions
{

    /// <summary>
    /// 
    /// </summary>
    public class CustomRouteAttribute : RouteAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <param name="version"></param>
        public CustomRouteAttribute(string controller = "[controller]", string action = "[action]", ApiVersions version = ApiVersions.web) : base($"{version}/{controller}.{action}")
        {
            this.GroupName = version.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        public string GroupName { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IGetActionParams
    {
        QL.Web.IWebParamData getParamMark();
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IHttpRequestParam
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string this[string name]
        {
            get;
        }
    }

}
