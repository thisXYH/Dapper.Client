using System;
using System.Data;
using System.Collections.Generic;
using static Dapper.SqlMapper;

namespace Dapper.Client
{
    /// <summary>
    /// 定义数据库访问客户端。
    /// </summary>
    public partial interface IDbClient
    {
        int Execute(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        int Execute(SlimCommandDefinition command);
        // 针对 ExecuteReader 封装不太适合，因为IDataReader和DbConnection有点耦合，又因为Dapper已经有提供匿名类型类型，所以就不封装这部分了
        //IDataReader ExecuteReader(SlimCommandDefinition command, CommandBehavior commandBehavior);
        //IDataReader ExecuteReader(SlimCommandDefinition command);
        //IDataReader ExecuteReader(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        object ExecuteScalar(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        T ExecuteScalar<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        T ExecuteScalar<T>(SlimCommandDefinition command);
        object ExecuteScalar(SlimCommandDefinition command);
        IEnumerable<object> Query(Type type, string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);
        IEnumerable<T> Query<T>(string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);
        IEnumerable<TReturn> Query<TReturn>(string sql, Type[] types, Func<object[], TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        IEnumerable<dynamic> Query(string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);
        IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        IEnumerable<T> Query<T>(SlimCommandDefinition command);
        T QueryFirst<T>(SlimCommandDefinition command);
        object QueryFirst(Type type, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        T QueryFirst<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        dynamic QueryFirst(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        T QueryFirstOrDefault<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        T QueryFirstOrDefault<T>(SlimCommandDefinition command);
        dynamic QueryFirstOrDefault(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        object QueryFirstOrDefault(Type type, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        GridReader QueryMultiple(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        GridReader QueryMultiple(SlimCommandDefinition command);
        object QuerySingle(Type type, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        T QuerySingle<T>(SlimCommandDefinition command);
        T QuerySingle<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        dynamic QuerySingle(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        dynamic QuerySingleOrDefault(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        T QuerySingleOrDefault<T>(SlimCommandDefinition command);
        T QuerySingleOrDefault<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        object QuerySingleOrDefault(Type type, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
    }
}