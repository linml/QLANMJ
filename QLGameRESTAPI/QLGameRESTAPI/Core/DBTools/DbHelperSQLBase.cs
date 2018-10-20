using System;
using System.Data;
using System.Data.SqlClient;
using QL;
using QL.Data;
using QLGameRESTAPI.Core;

namespace QLGameRESTAPI.Core.DBTools
{
    public abstract class DbHelperSQLBase<T> : IDbHelperSQL where T : class, IDbHelperSQL, new()
    {
        protected string _connectionStringMain;
        protected IDBEntityProvide _dbEntityProvide;


        /// <summary>
        /// 数据库连接字符串主服务器提供写入服务
        /// </summary>
        public abstract string ConnectionStringMain
        {
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public abstract IDBEntityProvide DBEntityProvide
        {
            get;
        }


        static T _instance;

        /// <summary>
        /// 
        /// </summary>
        public static T Instance
        {
            get
            {
                return _instance ?? (_instance = new T());
            }
        }


        /// <summary>
        /// 执行存储过程，返回ReturnValue
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        public object RunProcedure(string storedProcName, IDataParameter[] parameters, out DataSet dataSet)
        {
            try
            {
                QLDBHelper h = new QLDBHelper(ConnectionStringMain, DBEntityProvide);
                return h.RunProcedure(storedProcName, parameters, out dataSet);
            }
            catch (Exception ex)
            {
                var tex = new Exception("调用存储过程“" + storedProcName + "”出现异常！", ex);
                QLSystemErrorProvide.OnQLSystemErrorHandleEvent(null, tex);
                dataSet = new DataSet();
                return -10000;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        public void RunSql(string sql, out System.Data.DataSet dataSet)
        {
            try
            {
                QLDBHelper h = new QLDBHelper(ConnectionStringMain, DBEntityProvide);
                h.RunSql(sql, out dataSet);
            }
            catch(Exception ex)
            {
                var tex = new Exception("执行SQL “" + sql + "”出现异常！", ex);
                QLSystemErrorProvide.OnQLSystemErrorHandleEvent(null, tex); 
                dataSet = new DataSet();
            }
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IDbHelperSQL
    {
        object RunProcedure(string storedProcName, IDataParameter[] parameters, out DataSet dataSet);
    }

}
