



namespace QLGameRESTAPI.Core.DBTools.Data
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
                return _connectionStringMain ?? (_connectionStringMain = Global.Instance.ConfigManager.MySqlConstr);
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
