using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAutomation.Data.Dapper.Factory
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        public IDbTransaction dbTransaction { get; set; }
        public async Task<IDbConnection> CreateConnectionAsync(string connectionStr, bool parmNeedTrans = false)

        {
            try
            {
                var connection = new SqlConnection(connectionStr);
                if (connection.State == ConnectionState.Open)
                    connection.Close();

                connection.Open();
                if (parmNeedTrans)
                    dbTransaction = await connection.BeginTransactionAsync();
                return connection;
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public void CloseConnectionAsync(IDbConnection conn)
        {
            try
            {
                conn.Close();
                conn.Dispose();
            }
            catch (DbException ex)
            {
                throw ex;
            }
        }
    }
}
