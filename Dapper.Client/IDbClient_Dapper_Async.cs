using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using static Dapper.SqlMapper;

namespace Dapper.Client
{
    public partial interface IDbClient
    {
        Task<int> ExecuteAsync(SlimCommandDefinition command);
        Task<int> ExecuteAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        // 针对 ExecuteReader 封装不太适合，因为IDataReader和DbConnection有点耦合，又因为Dapper已经有提供匿名类型类型，所以就不封装这部分了
        //Task<IDataReader> ExecuteReaderAsync(SlimCommandDefinition command, CommandBehavior commandBehavior);
        //Task<IDataReader> ExecuteReaderAsync(SlimCommandDefinition command);
        //Task<IDataReader> ExecuteReaderAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<object> ExecuteScalarAsync(SlimCommandDefinition command);
        Task<T> ExecuteScalarAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<object> ExecuteScalarAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<T> ExecuteScalarAsync<T>(SlimCommandDefinition command);
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(SlimCommandDefinition command, Func<TFirst, TSecond, TReturn> map, string splitOn = "Id");
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        Task<IEnumerable<dynamic>> QueryAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<IEnumerable<dynamic>> QueryAsync(SlimCommandDefinition command);
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(SlimCommandDefinition command, Func<TFirst, TSecond, TThird, TReturn> map, string splitOn = "Id");
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(SlimCommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, string splitOn = "Id");
        Task<IEnumerable<object>> QueryAsync(Type type, SlimCommandDefinition command);
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(SlimCommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, string splitOn = "Id");
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(SlimCommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, string splitOn = "Id");
        Task<IEnumerable<TReturn>> QueryAsync<TReturn>(string sql, Type[] types, Func<object[], TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        Task<IEnumerable<object>> QueryAsync(Type type, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(SlimCommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, string splitOn = "Id");
        Task<IEnumerable<T>> QueryAsync<T>(SlimCommandDefinition command);
        Task<dynamic> QueryFirstAsync(SlimCommandDefinition command);
        Task<T> QueryFirstAsync<T>(SlimCommandDefinition command);
        Task<dynamic> QueryFirstAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<object> QueryFirstAsync(Type type, SlimCommandDefinition command);
        Task<T> QueryFirstAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<object> QueryFirstAsync(Type type, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<dynamic> QueryFirstOrDefaultAsync(SlimCommandDefinition command);
        Task<dynamic> QueryFirstOrDefaultAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<object> QueryFirstOrDefaultAsync(Type type, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<T> QueryFirstOrDefaultAsync<T>(SlimCommandDefinition command);
        Task<object> QueryFirstOrDefaultAsync(Type type, SlimCommandDefinition command);
        Task<GridReader> QueryMultipleAsync(SlimCommandDefinition command);
        Task<GridReader> QueryMultipleAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<dynamic> QuerySingleAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<object> QuerySingleAsync(Type type, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<T> QuerySingleAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<object> QuerySingleAsync(Type type, SlimCommandDefinition command);
        Task<T> QuerySingleAsync<T>(SlimCommandDefinition command);
        Task<dynamic> QuerySingleAsync(SlimCommandDefinition command);
        Task<object> QuerySingleOrDefaultAsync(Type type, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<object> QuerySingleOrDefaultAsync(Type type, SlimCommandDefinition command);
        Task<dynamic> QuerySingleOrDefaultAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<dynamic> QuerySingleOrDefaultAsync(SlimCommandDefinition command);
        Task<T> QuerySingleOrDefaultAsync<T>(SlimCommandDefinition command);
    }
}