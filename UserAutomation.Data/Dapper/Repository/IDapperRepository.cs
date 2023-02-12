

using UserOtomation.Shared.Entities.Abstrack;

namespace UserAutomation.Dapper.Repository
{

    public interface IDapperRepository<TEntity> 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> AddAsync(string connectionString, TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(string connectionString, TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task UpdateQueryAsync(string connectionString, string expressions, object param);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task DeleteAsync(string connectionString, TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync(string connectionString);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(string connectionString, TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> QueryAsync(string connectionString, string? expression = null, object? param = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="expression"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        Task<TEntity?> QueryFirstOrDefaultAsync(string connectionString, string? expression = null, object? param = null);
    }
}
