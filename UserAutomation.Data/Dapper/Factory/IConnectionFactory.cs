using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAutomation.Data.Dapper.Factory
{
    public interface ISqlConnectionFactory
    {
        IDbTransaction dbTransaction { get; set; }
        Task<IDbConnection> CreateConnectionAsync(string connectionStr, bool parmNeedTrans = false);
        void CloseConnectionAsync(IDbConnection conn);
    }
}
