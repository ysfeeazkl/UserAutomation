using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;

namespace UserAutomation.Dapper
{
    public static class DapperExtensions
    {
        private static readonly IEnumerable<TimeSpan> RetryTimes = new[]
        {
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(3)
        };

        private static readonly AsyncRetryPolicy RetryPolicy = Policy
                                                    .Handle<SqlException>(SqlServerTransientExceptionDetector.ShouldRetryOn)
                                                    .Or<TimeoutException>()
                                                    .OrInner<Win32Exception>(SqlServerTransientExceptionDetector.ShouldRetryOn)
                                                    .WaitAndRetryAsync(RetryTimes,
                                                                   (exception, timeSpan, retryCount, context) =>
                                                                   {
                                                                       //LogTo.Warning(
                                                                       //    exception,
                                                                       //    "WARNING: Error talking to ReportingDb, will retry after {RetryTimeSpan}. Retry attempt {RetryCount}",
                                                                       //    timeSpan,
                                                                       //    retryCount
                                                                       //);
                                                                   });



        /// <summary>
        /// 
        /// </summary>
        /// <param name="cnn"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static async Task<int> ExecuteAsyncWithRetry(this IDbConnection cnn, string sql, object param = null,
                                                    IDbTransaction transaction = null, int? commandTimeout = null,
                                                    CommandType? commandType = null)
        {
            return await RetryPolicy.ExecuteAsync(async () => await cnn.ExecuteAsync(sql, param, transaction, commandTimeout, commandType));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cnn"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<T>> QueryAsyncWithRetry<T>(this IDbConnection cnn, string sql, object param = null,
                                                                        IDbTransaction transaction = null, int? commandTimeout = null,
                                                                        CommandType? commandType = null)
        {
            return await RetryPolicy.ExecuteAsync(async () => await cnn.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cnn"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="transaction"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public static async Task<T> QueryFirstOrDefaultAsyncWithRetry<T>(this IDbConnection cnn, string sql, object param = null,
                                                                        IDbTransaction transaction = null, int? commandTimeout = null,
                                                                        CommandType? commandType = null)
        {
            return await RetryPolicy.ExecuteAsync(async () => await cnn.QueryFirstOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string? GetTableName<T>()
        {
            var tAttribute = (TableAttribute)typeof(T).GetCustomAttributes(typeof(TableAttribute), true)[0];
            string? tableName = tAttribute?.Name;
            return tableName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetColumns<T>()
        {
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            List<string> coloumns = new();
            foreach (PropertyInfo prop in props)
            {
                if (prop.Name == "Id")
                    continue;

                if (prop.PropertyType.IsGenericType)
                    if (prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                        continue;

                if (prop.PropertyType.IsClass && !prop.PropertyType.IsSealed)
                    continue;

                if (prop.GetCustomAttribute(typeof(NotMappedAttribute), true) != null)
                    continue;

                coloumns.Add(prop.Name);
            }

            return coloumns;

            //return typeof(T)
            //        .GetProperties()
            //        .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType)
            //        .Select(e => e.Name);
        }

    }
}
