/***************************************************************************
 * 
 * 创建时间：   2017/9/15 16:51:48
 * 创建人员：   沈瑞
 * CLR版本号：  4.0.30319.42000
 * 备注信息：   未填写备注信息
 * 
 * *************************************************************************/

using System.Collections.Generic;
using System.Text;
using QL.WebApiCommon;
using QL;

namespace QLGameRESTAPI.Core
{
    /// <summary>
    /// 类DomainWildManager的注释信息
    /// </summary>
    public class DomainWildManager
    {
        static object root = new object();
        static DomainWildManager _instance;

        private List<DomainWild> l = new List<DomainWild>();

        public static DomainWildManager Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (root)
                {
                    if (_instance != null) return _instance;
                    _instance = new DomainWildManager();
                    return _instance;
                }

            }
        }



        /// <summary>
        /// 类DomainWildManager的默认构造函数
        /// </summary>
        public DomainWildManager()
        {
            var sql = $"select * from `tb_DomainConfig` order by `SortId`";

            var h =  QLGlobal.GetDBHelper;

            System.Data.DataSet ds;
            h.RunSql(sql, out ds);

            foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
            {
                //Id	Pattern	RedirectMatch	Through	SortId	Mark
                l.Add(new DomainWild()
                {
                    Id = dr["Id"].ToString(),
                    Pattern = dr["Pattern"].ToString(),
                    RedirectMatch = dr["RedirectMatch"].ToString(),
                    Mark = dr["Mark"].ToString(),
                    Through = dr["Through"].ToString() =="1",


                });
            }




        }

        public string GetWildDomain(string host)
        {
            foreach (var r in l)
            {
                var s = r.GetWildDomain(host);
                if (string.IsNullOrEmpty(s)) continue;

                return s;
            }
            return null;
        }


        public WebRegionConfig GetWildWebRegionConfig(string region)
        {


            foreach (var r in l)
            {
                var s = r.GetWildDomain(region);
                if (string.IsNullOrEmpty(s)) continue;
                var region_config = WebRegionConfig.GetRegionConfigInfoByDb(s);
                if (region_config == null && r.Through) continue;

                return region_config;
                     
            }
            return null;
             
        }





        class DomainWild
        {
            internal string Pattern;
            internal string Id;
            internal string Mark;
            internal string RedirectMatch;
            internal bool Through;

            public string GetWildDomain(string host)
            {
                string[] result;
                if (!ToolsMethods.WildMatchByPtr(host, Pattern, out result))
                {
                    return null;
                }

                var sb = new StringBuilder(RedirectMatch);
                for (int i = 0; i < result.Length; i++)
                {
                    sb.Replace($"{{${i}}}", result[i] + "");
                }
                return sb.ToString();
            }
        }



    }
}
