using QL.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLGameRESTAPI.Core.CustomType
{
    /// <summary>
    /// 
    /// </summary>
    [AppConfigPathInfo("WebApiConfig")]
    public class WebApiConfig : AppConfigBase<WebApiConfig>
    {
        /// <summary>
        /// 服务分区
        /// </summary>
        public string RegionHost  = "ceshi";
        /// <summary>
        /// 服务Redis服务地址
        /// </summary>
        public string RedisConstr  = "127.0.0.1:6379";
        /// <summary>
        /// 服务Redis 数据库编号
        /// </summary>
        public int RedisDbId  = -1;
        /// <summary>
        /// Mysql 配置数据库
        /// </summary>
        public string MySqlConstr  = "server=60.166.25.18;port=3300;user=user76;password=user76@123;database=entertainment_76; pooling=true; CharSet=utf8;";
        /// <summary>
        /// 配置数据库连接字符串
        /// </summary>
        public string ConfMySqlConstr = "server=60.166.25.18;port=3300;user=user76;password=user76@123;database=entertainment_76; pooling=true; CharSet=utf8;";
        /// <summary>
        /// 服务器使用的主密钥
        /// </summary>
        public string WebSecret  = "Pc0sM75itrf9024W4wU54x1v7sbObmQIBPuFbP8K64KeTt9KFG"; 
        /// <summary>
        /// 指示服务器是否启用SSL 证书
        /// </summary>
        public int UseHttps = 0;
        /// <summary>
        /// 网站的服务端口
        /// </summary>
        public int ServicesPort = 12345;
        /// <summary>
        /// 微信头像的缓存cdn地址
        /// </summary>
        public string WxHeadImgHost = "wxheader.qileah.cn";
        /// <summary>
        /// 服务器Ip
        /// </summary>
        public string ServicesIp = "127.0.0.1";
        /// <summary>
        /// 网站名称
        /// </summary>
        public string WebName = "七乐互娱";
        /// <summary>
        /// Oss文件上传地址
        /// </summary>
        public string OssUploadUrl = "http://qile-files.oss-cn-shanghai.aliyuncs.com";
        /// <summary>
        /// 分区编号
        /// </summary>
        public string RegionId = "1001";
    }
}
