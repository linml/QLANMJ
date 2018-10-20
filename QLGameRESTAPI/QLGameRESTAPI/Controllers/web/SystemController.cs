using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL.Extension;
using QLGameRESTAPI.Core;

namespace QLGameRESTAPI.Controllers.web
{
    /// <summary>
    /// 
    /// </summary>
    [Core.CustomRoute(version: Core.CustomType.ApiVersions.web)]
    public class SystemController : Extensions.BaseApiController
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult reflush()
        {
            Global.Instance.ClearCacheData();
            return Content("success");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult getUpdateInfo(string region,int device_type)
        {
            //id	region	device_type	pkg_version	downloadurl	js_version	packageUrl	remoteManifestUrl	remoteVersionUrl	mark
            region = (region + "").Replace("\'", "\'\'");


            var sql = $@"select * from `web_hotupdateconf` c where c.region = '{region}' and c.device_type = {device_type};";

            System.Data.DataSet ds;
            Core.DBTools.Conf.DbHelperSQL.Instance.RunSql(sql,out ds);
            var p = new QL.Web.WebParamData();
            p["status"] = "fail";
            p["msg"] = "没有获取到热更新配置信息";

            if (ds.Tables.Count >= 1)
            {
                var rows = ds.Tables[0].Rows;
                if (rows.Count >= 1)
                {
                    var dr = rows[0];
                    foreach(System.Data.DataColumn col in dr.Table.Columns)
                    {
                        p[col.ColumnName] = dr.GetData(col.ColumnName).ToString();
                    }
                    p["status"] = "success";
                    p["msg"] = "OK";

                }
            }




            return Json(p);
        }
        //public IActionResult setUpdateInfo()


    }
}