using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Dapper.Helper
{
    public interface IDapperHelper
    {
        /// <summary>
        /// Execute a non-query command.
        /// </summary>
        /// <param name="sql">The SQL to execute.</param>
        /// <param name="param">The parameters to use for this command.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The number of rows affected.</returns>
        int Execute(string sql, object param = null, CommandType? commandType = null);


        /// <summary>
        /// Execute a non-query command asynchronously.
        /// </summary>
        /// <param name="sql">The SQL to execute.</param>
        /// <param name="param">The parameters to use for this command.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> ExecuteAsync(string sql, object param = null, CommandType? commandType = null);


        /// <summary>
        /// Execute parameterized SQL that selects a single value.
        /// </summary>
        /// <param name="sql">The SQL to execute.</param>
        /// <param name="param">The parameters to use for this command.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The first cell returned, as System.Object.</returns>
        object QueryScalar(string sql, object param = null, CommandType? commandType = null);


        /// <summary>
        /// Execute parameterized SQL asynchronously that selects a single value.
        /// </summary>
        /// <param name="sql">The SQL to execute.</param>
        /// <param name="param">The parameters to use for this command.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <returns>The first cell returned, as System.Object.</returns>
        Task<object> QueryScalarAsync(string sql, object param = null, CommandType? commandType = null);


        /// <summary>
        /// Execute a query.
        /// </summary>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <returns>A sequence of data of T; if a basic type (int, string, etc) is queried then the data from the first column in assumed, otherwise an instance is created per row,and a direct column-name===member-name mapping is assumed (case insensitive).</returns>
        IEnumerable<T> Query<T>(string sql, object param = null, CommandType? commandType = null);


        /// <summary>
        /// Execute a query asynchronously.
        /// </summary>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <returns>A sequence of data of T; if a basic type (int, string, etc) is queried then the data from the first column in assumed, otherwise an instance is created per row,and a direct column-name===member-name mapping is assumed (case insensitive).</returns>
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, CommandType? commandType = null);


        /// <summary>
        /// Perform a asynchronous multi-mapping query with 2 input types. This returns a single type, combined from the raw types via map.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <param name="buffered">Whether to buffer the results in memory.</param>
        /// <typeparam name="T1">The first type in the record set.</typeparam>
        /// <typeparam name="T2">The second type in the record set.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <returns>An enumerable of TReturn.</returns>
        IEnumerable<TReturn> Query<T1, T2, TReturn>(string sql, Func<T1, T2, TReturn> map, object param = null, CommandType? commandType = null, bool buffered = true);


        /// <summary>
        /// Perform a asynchronous multi-mapping query with 2 input types. This returns a single type, combined from the raw types via map.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <param name="buffered">Whether to buffer the results in memory.</param>
        /// <typeparam name="T1">The first type in the record set.</typeparam>
        /// <typeparam name="T2">The second type in the record set.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <returns>An enumerable of TReturn.</returns>
        Task<IEnumerable<TReturn>> QueryAsync<T1, T2, TReturn>(string sql, Func<T1, T2, TReturn> map, object param = null, CommandType? commandType = null, bool buffered = true);


        /// <summary>
        /// Perform a asynchronous multi-mapping query with 3 input types. This returns a single type, combined from the raw types via map.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <param name="buffered">Whether to buffer the results in memory.</param>
        /// <typeparam name="T1">The first type in the record set.</typeparam>
        /// <typeparam name="T2">The second type in the record set.</typeparam>
        /// <typeparam name="T3">The third type in the record set.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <returns>An enumerable of TReturn.</returns>
        IEnumerable<TReturn> Query<T1, T2, T3, TReturn>(string sql, Func<T1, T2, T3, TReturn> map, object param = null, CommandType? commandType = null, bool buffered = true);


        /// <summary>
        /// Perform a asynchronous multi-mapping query with 3 input types. This returns a single type, combined from the raw types via map.
        /// </summary>
        /// <param name="sql">The SQL to execute for this query.</param>
        /// <param name="map">The function to map row types to the return type.</param>
        /// <param name="param">The parameters to use for this query.</param>
        /// <param name="commandType">Is it a stored proc or a batch?</param>
        /// <param name="buffered">Whether to buffer the results in memory.</param>
        /// <typeparam name="T1">The first type in the record set.</typeparam>
        /// <typeparam name="T2">The second type in the record set.</typeparam>
        /// <typeparam name="T3">The third type in the record set.</typeparam>
        /// <typeparam name="TReturn">The combined type to return.</typeparam>
        /// <returns>An enumerable of TReturn.</returns>
        Task<IEnumerable<TReturn>> QueryAsync<T1, T2, T3, TReturn>(string sql, Func<T1, T2, T3, TReturn> map, object param = null, CommandType? commandType = null, bool buffered = true);


        /// <summary>
        /// Execute a non-query transaction.
        /// </summary>
        /// <param name="scripts">The 'SqlScript' set of this transaction to execute.</param>
        /// <returns>The number of rows affected.</returns>
        int ExecuteTransaction(IEnumerable<SqlScript> scripts);

        /// <summary>
        /// Execute a non-query transaction asynchronously.
        /// </summary>
        /// <param name="scripts">The 'SqlScript' set of this transaction to execute.</param>
        /// <returns>The number of rows affected.</returns>
        Task<int> ExecuteTransactionAsync(IEnumerable<SqlScript> scripts);

        /// <summary>
        /// Execute a transaction with the specify operation inside
        /// </summary>
        /// <param name="transaction">transaction operation</param>
        void ExecuteTransaction(Action<IDbConnection> transaction);

        /// <summary>
        /// Execute a transaction with the specify operation inside
        /// </summary>
        /// <param name="transaction">transaction operation</param>
        /// <typeparam name="TResult">return value type of the transaction operation</typeparam>
        /// <returns>return value of the transaction operation</returns>
        TResult ExecuteTransaction<TResult>(Func<IDbConnection, TResult> transaction);
    }
}
