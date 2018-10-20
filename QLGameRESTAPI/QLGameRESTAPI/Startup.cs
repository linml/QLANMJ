

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using QLGameRESTAPI.Core;
using QLGameRESTAPI.Extensions;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Linq;
using System.Threading.Tasks;
using QLGameRESTAPI.Core.Express;


namespace QLGameRESTAPI
{
    public class Startup
    {

        public const string _Project_Name = "QLGameRESTAPI";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();


#if SD
            services.AddSwaggerGen(config =>
               {

                   typeof(Core.CustomType.ApiVersions).GetEnumNames().OrderByDescending(e => e).ToList().ForEach(version =>
                   {
                       config.SwaggerDoc(version, new Info
                       {
                           Title = "平台信息交互接口文档",
                           Version = version,
                           Description = "平台信息交互接口文档 ",
                       });

                   });

                   var c = config;

                   var basePath = QL.IO.FileHelper.ProcessBaseDir;
                   var xmlPath = System.IO.Path.Combine(basePath, $"{_Project_Name}.xml"); 
                   c.IncludeXmlComments(xmlPath);
                   c.OperationFilter<AssignOperationVendorExtensions>();
                //c.DocumentFilter<ApplyTagDescriptions>();
            }); 
#endif

            //注入 HttpContext 管理服务器，用于全局获取请求上下文
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            //注入Redis服务 
            services.AddQLRedisServices();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //绑定请求服务
            HttpContextHelper.ServiceProvider = app.ApplicationServices;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           

            app.UseQLExceptionHandler();
            app.UseHttpIndexHandle();
            app.UseMvc();

#if SD
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                typeof(Core.CustomType.ApiVersions).GetEnumNames().OrderByDescending(e => e).ToList().ForEach(version =>
                {
                    c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{version}");
                });
                //注入汉化文件
                //c.InjectOnCompleteJavaScript($"/swagger_translator.js");
            });
#endif

            app.UseStaticFiles();

        }

    }
}
