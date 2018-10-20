using QL.Extension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace QLGameRESTAPI.Core.CustomType.CacheTypes
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ResponseDataBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string status = "success";
        /// <summary>
        /// 
        /// </summary>
        public string msg = "OK";
    }
    /// <summary>
    /// 
    /// </summary>
    public class TableResponseDataBase : ResponseDataBase
    { 
        /// <summary>
        /// 
        /// </summary>
        public string[] column;
        /// <summary>
        /// 
        /// </summary>
        public object[][] data;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class TableResponseDataBase<T> : TableResponseDataBase
        where T : TableResponseDataBase, new()
    {
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static T ParseDataTable(DataTable tb)
        {
            T ins = new T();

            ins.column = tb.Columns.Cast<DataColumn>().Select(p => p.ColumnName).ToArray();
            ins.data = tb.GetDataTableArray();

            return ins;
        }
}

}
