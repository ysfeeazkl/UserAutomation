using Dapper;
using UserAutomation.Data.Dapper.Factory;
using System.Data.Common;
using UserOtomation.Shared.Entities.Abstrack;

namespace UserAutomation.Dapper.Repository
{
    public partial class DapperRepository<TEntity> : IDapperRepository<TEntity>
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        public DapperRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> AddAsync(string connectionString, TEntity entity)
        {
            var columns = DapperExtensions.GetColumns<TEntity>();
            var stringOfColumns = string.Join(", ", columns);
            var stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));
            var query = @$"DECLARE @OutputTable TABLE (Id int)";
            query += @$"
                            INSERT INTO [{DapperExtensions.GetTableName<TEntity>()}] ({stringOfColumns}) OUTPUT INSERTED.ID INTO @OutputTable VALUES ({stringOfParameters})";
            query += $@"
                        SELECT * FROM @OutputTable";
            var conn = await _connectionFactory.CreateConnectionAsync(connectionString);
            try
            {
                var result = await conn.QueryFirstOrDefaultAsyncWithRetry<TEntity>(query, entity);
                //entity.Id = result.Id;
                return entity;
            }
            catch (DbException ex) { throw ex; }
            finally { _connectionFactory.CloseConnectionAsync(conn); }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(string connectionString, TEntity entity)
        {
            var columns = DapperExtensions.GetColumns<TEntity>();
            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));
            var query = $"UPDATE [{DapperExtensions.GetTableName<TEntity>()}] SET {stringOfColumns} where Id = @Id";
            var conn = await _connectionFactory.CreateConnectionAsync(connectionString);
            try
            {
                await conn.ExecuteAsyncWithRetry(query, entity);
            }
            catch (DbException ex) { throw ex; }
            finally { _connectionFactory.CloseConnectionAsync(conn); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateQueryAsync(string connectionString, string expressions, object param)
        {
            var conn = await _connectionFactory.CreateConnectionAsync(connectionString);
            var query = $"UPDATE [{DapperExtensions.GetTableName<TEntity>()}] SET {expressions}";
            try
            {
                await conn.ExecuteAsyncWithRetry(query, param);
            }
            catch (DbException ex) { throw ex; }
            finally { _connectionFactory.CloseConnectionAsync(conn); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string connectionString, TEntity entity)
        {
            var conn = await _connectionFactory.CreateConnectionAsync(connectionString);
            try
            {
                await conn.ExecuteAsyncWithRetry($"DELETE FROM [{DapperExtensions.GetTableName<TEntity>()}] WHERE [Id] = @Id", new { entity });
            }
            catch (DbException ex) { throw ex; }
            finally { _connectionFactory.CloseConnectionAsync(conn); }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync(string connectionString)
        {
            var conn = await _connectionFactory.CreateConnectionAsync(connectionString);
            try
            {
                var data = await conn.QueryAsyncWithRetry<TEntity>($"SELECT * FROM [{DapperExtensions.GetTableName<TEntity>()}]");
                return data;
            }
            catch (DbException ex) { throw ex; }
            finally { _connectionFactory.CloseConnectionAsync(conn); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> GetByIdAsync(string connectionString, TEntity entity)
        {
            var conn = await _connectionFactory.CreateConnectionAsync(connectionString);
            try
            {
                var data = await conn.QueryFirstOrDefaultAsyncWithRetry<TEntity>($"SELECT * FROM [{DapperExtensions.GetTableName<TEntity>()}] WHERE Id = @Id", new { entity });
                return data;
            }
            catch (Exception ex) { throw; }
            finally { _connectionFactory.CloseConnectionAsync(conn); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="expression"></param>
        /// <param name="param"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> QueryAsync(string connectionString, string? expression = null, object? param = null)
        {
            var query = $"SELECT * FROM [{DapperExtensions.GetTableName<TEntity>()}] ";
            if (expression is not null) query += expression;

            var conn = await _connectionFactory.CreateConnectionAsync(connectionString);
            try
            {
                return await conn.QueryAsyncWithRetry<TEntity>(query, param);
            }
            catch (DbException ex) { throw ex; }
            finally { _connectionFactory.CloseConnectionAsync(conn); }
        }

      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="expression"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<TEntity> QueryFirstOrDefaultAsync(string connectionString, string? expression = null, object? param = null)
        {
            var result = await QueryAsync(connectionString, expression, param);
            if (result is not null && result.Count() > 0)
                return result.FirstOrDefault();
            return result.FirstOrDefault();
        }
    }
}
