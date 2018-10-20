using System;
using System.Collections.Generic;
using System.Linq;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace QLGameRESTAPI.Core
{
    //public class AssignOperationVendorExtensions : IOperationFilter
    //{
    //    public void Apply(Operation operation, OperationFilterContext context)
    //    {





    //    }
    //}



    /// <summary>
    /// 操作过过滤器 添加通用参数等
    /// </summary>
    public class AssignOperationVendorExtensions : IOperationFilter
    {
        /// <summary>
        /// apply
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(Operation operation, OperationFilterContext context)
        {



            operation.Parameters = operation.Parameters ?? new List<IParameter>();


            System.Reflection.MethodInfo m;
            if (!context.ApiDescription.TryGetMethodInfo(out m)) return;

            var dType = m.DeclaringType;

            var attr = dType.GetCustomAttributes(true).OfType<CustomRouteAttribute>().LastOrDefault()  as CustomRouteAttribute;
            context.ApiDescription.GroupName = attr?.GroupName ?? "web";
            var dObj = Activator.CreateInstance(dType);
            var obj = dObj as IGetActionParams;
            if (obj != null)
            {
                foreach(var p in obj.getParamMark())
                {
                    operation.Parameters.Add(new NonBodyParameter()
                    {
                        Name = p.Key,
                        Description = p.Value,
                        In = "query",
                    });
                }
            }


        }
    }


}
