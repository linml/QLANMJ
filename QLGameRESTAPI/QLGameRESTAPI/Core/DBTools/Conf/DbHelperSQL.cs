using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QL.Data;

namespace QLGameRESTAPI.Core.DBTools.Conf
{
    /// <summary>
    /// 
    /// </summary>
    public class DbHelperSQL : DbHelperSQLBase<DbHelperSQL>
    {
        /// <summary>
        /// 
        /// </summary>
        public override string ConnectionStringMain
        {
            get
            {
                return _connectionStringMain ?? (_connectionStringMain = Global.Instance.ConfigManager.ConfMySqlConstr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override QL.Data.IDBEntityProvide DBEntityProvide
        {
            get
            {
                return _dbEntityProvide ?? (_dbEntityProvide = new QL.Data.MySqlDBEntityProvide());
            }
        }
    }
}
