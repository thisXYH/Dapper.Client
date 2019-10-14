using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dapper.Client
{
    public partial interface IDbClient
    {
        /// <summary>
        /// 执行参数化sql。
        /// </summary>
        /// <param name="command">命令定义。</param>
        /// <returns>返回受影响行数。</returns>
        Task<int> ExecuteAsync(SlimCommandDefinition command);

        /// <summary>
        /// 执行参数化sql。
        /// </summary>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回受影响行数。</returns>
        Task<int> ExecuteAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行参数化sql，返回<see cref="System.Data.IDataReader" />.
        /// </summary>
        /// <param name="ccp">连接对象关闭操作。</param>
        /// <param name="command">命令定义。</param>
        /// <param name="commandBehavior">命令行为。</param>
        Task<IDataReader> ExecuteReaderAsync(out ConnectionCloseOperate ccp, SlimCommandDefinition command, CommandBehavior commandBehavior);

        /// <summary>
        /// 执行参数化sql，返回<see cref="System.Data.IDataReader" />.
        /// </summary>
        /// <param name="ccp">连接对象关闭操作。</param>
        /// <param name="command">命令定义。</param>
        Task<IDataReader> ExecuteReaderAsync(out ConnectionCloseOperate ccp, SlimCommandDefinition command);

        /// <summary>
        /// 执行参数化sql，返回<see cref="System.Data.IDataReader" />.
        /// </summary>
        /// <param name="ccp">连接对象关闭操作。</param>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        Task<IDataReader> ExecuteReaderAsync(out ConnectionCloseOperate ccp, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行选择单个值的参数化sql。
        /// </summary>
        /// <param name="command">命令定义。</param>
        /// <returns>返回第一个单元格值。</returns>
        Task<object> ExecuteScalarAsync(SlimCommandDefinition command);

        /// <summary>
        /// 执行选择单个值的参数化sql。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回第一个单元格值。</returns>
        Task<T> ExecuteScalarAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行选择单个值的参数化sql。
        /// </summary>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回第一个单元格值。</returns>
        Task<object> ExecuteScalarAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行选择单个值的参数化sql。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <param name="command">命令定义。</param>
        /// <returns>返回第一个单元格值。</returns>
        Task<T> ExecuteScalarAsync<T>(SlimCommandDefinition command);

        /// <summary>
        /// 执行一个单结果集的查询语句，将指定的映射类型置换成返回类型。
        /// </summary>
        /// <typeparam name="TFirst">映射类型1。</typeparam>
        /// <typeparam name="TSecond">映射类型2。</typeparam>
        /// <typeparam name="TReturn">返回值类型。</typeparam>
        /// <param name="command">命令定义。</param>
        /// <param name="map">把映射类型置换成返回类型的委托。</param>
        /// <param name="splitOn">映射类型之间的分隔字段，缺省值Id。</param>
        /// <returns>返回经<param name="map"/>处理的<typeparam name="TReturn"/></returns>
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(SlimCommandDefinition command, Func<TFirst, TSecond, TReturn> map, string splitOn = "Id");

        /// <summary>
        /// 执行一个单结果集的查询语句，将指定的映射类型置换成返回类型。
        /// </summary>
        /// <typeparam name="TFirst">映射类型1。</typeparam>
        /// <typeparam name="TSecond">映射类型2。</typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql">执行语句。</param>
        /// <param name="map">把映射类型置换成返回类型的委托。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="buffered">是否将结果缓存到内存中。</param>
        /// <param name="splitOn">映射类型之间的分隔字段，缺省值Id。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回经<param name="map"/>处理的<typeparam name="TReturn"/></returns>
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行一个单结果集的查询语句，返回动态类型集合。
        /// </summary>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回动态类型集合，每一行可以通过 *dynamic* 语法访问成员，也可以通过转成 IDictionary[string,object]访问</returns>
        Task<IEnumerable<dynamic>> QueryAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行一个单结果集的查询语句，返回动态类型集合。
        /// </summary>
        /// <param name="command">命令定义。</param>
        /// <returns>返回动态类型集合，每一行可以通过 *dynamic* 语法访问成员，也可以通过转成 IDictionary[string,object]访问</returns>
        Task<IEnumerable<dynamic>> QueryAsync(SlimCommandDefinition command);

        /// <summary>
        /// 执行一个单结果集的查询语句，将指定的映射类型置换成返回类型。
        /// </summary>
        /// <typeparam name="TFirst">映射类型1。</typeparam>
        /// <typeparam name="TSecond">映射类型2。</typeparam>
        /// <typeparam name="TThird">映射类型3。</typeparam>
        /// <typeparam name="TReturn">返回值类型。</typeparam>
        /// <param name="sql">执行语句。</param>
        /// <param name="map">把映射类型置换成返回类型的委托。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="buffered">是否将结果缓存到内存中。</param>
        /// <param name="splitOn">映射类型之间的分隔字段，缺省值Id。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回经<param name="map"/>处理的<typeparam name="TReturn"/></returns>
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行一个单结果集的查询语句，将指定的映射类型置换成返回类型。
        /// </summary>
        /// <typeparam name="TFirst">映射类型1。</typeparam>
        /// <typeparam name="TSecond">映射类型2。</typeparam>
        /// <typeparam name="TThird">映射类型3。</typeparam>
        /// <typeparam name="TReturn">返回值类型。</typeparam>
        /// <param name="command">命令定义。</param>
        /// <param name="map">把映射类型置换成返回类型的委托。</param>
        /// <param name="splitOn">映射类型之间的分隔字段，缺省值Id。</param>
        /// <returns>返回经<param name="map"/>处理的<typeparam name="TReturn"/></returns>
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(SlimCommandDefinition command, Func<TFirst, TSecond, TThird, TReturn> map, string splitOn = "Id");

        /// <summary>
        /// 执行一个单结果集的查询语句，将指定的映射类型置换成返回类型。
        /// </summary>
        /// <typeparam name="TFirst">映射类型1。</typeparam>
        /// <typeparam name="TSecond">映射类型2。</typeparam>
        /// <typeparam name="TThird">映射类型3。</typeparam>
        /// <typeparam name="TFourth">映射类型4。</typeparam>
        /// <typeparam name="TReturn">返回值类型。</typeparam>
        /// <param name="sql">执行语句。</param>
        /// <param name="map">把映射类型置换成返回类型的委托。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="buffered">是否将结果缓存到内存中。</param>
        /// <param name="splitOn">映射类型之间的分隔字段，缺省值Id。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回经<param name="map"/>处理的<typeparam name="TReturn"/></returns>
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行一个单结果集的查询语句，将指定的映射类型置换成返回类型。
        /// </summary>
        /// <typeparam name="TFirst">映射类型1。</typeparam>
        /// <typeparam name="TSecond">映射类型2。</typeparam>
        /// <typeparam name="TThird">映射类型3。</typeparam>
        /// <typeparam name="TFourth">映射类型4。</typeparam>
        /// <typeparam name="TReturn">返回值类型。</typeparam>
        /// <param name="command">命令定义。</param>
        /// <param name="map">把映射类型置换成返回类型的委托。</param>
        /// <param name="splitOn">映射类型之间的分隔字段，缺省值Id。</param>
        /// <returns>返回经<param name="map"/>处理的<typeparam name="TReturn"/></returns>
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(SlimCommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, string splitOn = "Id");

        /// <summary>
        /// 执行一个单结果集的查询语句，返回指定类型集合。
        /// </summary>
        /// <param name="type">返回值的类型。</param>
        /// <param name="command">命令定义。</param>
        /// <returns>
        /// 返回指定类型<param name="type"/>的集合数据（映射方式：列名->成员名，忽略大小写），
        /// 如果<param name="type"/>是基础类型（int、string之类的）就取第一列的数据作为返回。
        /// </returns>
        Task<IEnumerable<object>> QueryAsync(Type type, SlimCommandDefinition command);

        /// <summary>
        /// 执行一个单结果集的查询语句，返回指定类型集合。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>
        /// 返回指定类型<typeparam name="T"/>的集合数据（映射方式：列名->成员名，忽略大小写），
        /// 如果<ptypeparamaram name="T"/>是基础类型（int、string之类的）就取第一列的数据作为返回。
        /// </returns>
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行一个单结果集的查询语句，将指定的映射类型置换成返回类型。
        /// </summary>
        /// <typeparam name="TFirst">映射类型1。</typeparam>
        /// <typeparam name="TSecond">映射类型2。</typeparam>
        /// <typeparam name="TThird">映射类型3。</typeparam>
        /// <typeparam name="TFourth">映射类型4。</typeparam>
        /// <typeparam name="TFifth">映射类型5。</typeparam>
        /// <typeparam name="TReturn">返回值类型。</typeparam>
        /// <param name="sql">执行语句。</param>
        /// <param name="map">把映射类型置换成返回类型的委托。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="buffered">是否将结果缓存到内存中。</param>
        /// <param name="splitOn">映射类型之间的分隔字段，缺省值Id。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回经<param name="map"/>处理的<typeparam name="TReturn"/></returns>
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行一个单结果集的查询语句，将指定的映射类型置换成返回类型。
        /// </summary>
        /// <typeparam name="TFirst">映射类型1。</typeparam>
        /// <typeparam name="TSecond">映射类型2。</typeparam>
        /// <typeparam name="TThird">映射类型3。</typeparam>
        /// <typeparam name="TFourth">映射类型4。</typeparam>
        /// <typeparam name="TFifth">映射类型5。</typeparam>
        /// <typeparam name="TSixth">映射类型6。</typeparam>
        /// <typeparam name="TReturn">返回值类型。</typeparam>
        /// <param name="sql">执行语句。</param>
        /// <param name="map">把映射类型置换成返回类型的委托。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="buffered">是否将结果缓存到内存中。</param>
        /// <param name="splitOn">映射类型之间的分隔字段，缺省值Id。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回经<param name="map"/>处理的<typeparam name="TReturn"/></returns>
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行一个单结果集的查询语句，将指定的映射类型置换成返回类型。
        /// </summary>
        /// <typeparam name="TFirst">映射类型1。</typeparam>
        /// <typeparam name="TSecond">映射类型2。</typeparam>
        /// <typeparam name="TThird">映射类型3。</typeparam>
        /// <typeparam name="TFourth">映射类型4。</typeparam>
        /// <typeparam name="TFifth">映射类型5。</typeparam>
        /// <typeparam name="TSixth">映射类型6。</typeparam>
        /// <typeparam name="TReturn">返回值类型。</typeparam>
        /// <param name="command">命令定义。</param>
        /// <param name="map">把映射类型置换成返回类型的委托。</param>
        /// <param name="splitOn">映射类型之间的分隔字段，缺省值Id。</param>
        /// <returns>返回经<param name="map"/>处理的<typeparam name="TReturn"/></returns>
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(SlimCommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, string splitOn = "Id");

        /// <summary>
        /// 执行一个单结果集的查询语句，将指定的映射类型置换成返回类型。
        /// </summary>
        /// <typeparam name="TFirst">映射类型1。</typeparam>
        /// <typeparam name="TSecond">映射类型2。</typeparam>
        /// <typeparam name="TThird">映射类型3。</typeparam>
        /// <typeparam name="TFourth">映射类型4。</typeparam>
        /// <typeparam name="TFifth">映射类型5。</typeparam>
        /// <typeparam name="TSixth">映射类型6。</typeparam>
        /// <typeparam name="TSeventh">映射类型7。</typeparam>
        /// <typeparam name="TReturn">返回值类型。</typeparam>
        /// <param name="sql">执行语句。</param>
        /// <param name="map">把映射类型置换成返回类型的委托。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="buffered">是否将结果缓存到内存中。</param>
        /// <param name="splitOn">映射类型之间的分隔字段，缺省值Id。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回经<param name="map"/>处理的<typeparam name="TReturn"/></returns>
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行一个单结果集的查询语句，将指定的映射类型置换成返回类型。
        /// </summary>
        /// <typeparam name="TFirst">映射类型1。</typeparam>
        /// <typeparam name="TSecond">映射类型2。</typeparam>
        /// <typeparam name="TThird">映射类型3。</typeparam>
        /// <typeparam name="TFourth">映射类型4。</typeparam>
        /// <typeparam name="TFifth">映射类型5。</typeparam>
        /// <typeparam name="TSixth">映射类型6。</typeparam>
        /// <typeparam name="TSeventh">映射类型7。</typeparam>
        /// <typeparam name="TReturn">返回值类型。</typeparam>
        /// <param name="command">命令定义。</param>
        /// <param name="map">把映射类型置换成返回类型的委托。</param>
        /// <param name="splitOn">映射类型之间的分隔字段，缺省值Id。</param>
        /// <returns>返回经<param name="map"/>处理的<typeparam name="TReturn"/></returns>
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(SlimCommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, string splitOn = "Id");

        /// <summary>
        /// 执行一个单结果集的查询语句，将指定的映射类型置换成返回类型。
        /// </summary>
        /// <typeparam name="TReturn">返回值的类型。</typeparam>
        /// <param name="sql">执行语句。</param>
        /// <param name="types">映射类型。</param>
        /// <param name="map">把映射类型置换成返回类型的委托。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="buffered">是否将结果缓存到内存中。</param>
        /// <param name="splitOn">映射类型之间的分隔字段，缺省值Id。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回经<param name="map"/>处理的<typeparam name="TReturn"/></returns>
        Task<IEnumerable<TReturn>> QueryAsync<TReturn>(string sql, Type[] types, Func<object[], TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行一个单结果集的查询语句，返回指定类型集合。
        /// </summary>
        /// <param name="type">返回值的类型。</param>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>
        /// 返回指定类型<param name="type"/>的集合数据（映射方式：列名->成员名，忽略大小写），
        /// 如果<param name="type"/>是基础类型（int、string之类的）就取第一列的数据作为返回。
        /// </returns>
        Task<IEnumerable<object>> QueryAsync(Type type, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行一个单结果集的查询语句，将指定的映射类型置换成返回类型。
        /// </summary>
        /// <typeparam name="TFirst">映射类型1。</typeparam>
        /// <typeparam name="TSecond">映射类型2。</typeparam>
        /// <typeparam name="TThird">映射类型3。</typeparam>
        /// <typeparam name="TFourth">映射类型4。</typeparam>
        /// <typeparam name="TFifth">映射类型5。</typeparam>
        /// <typeparam name="TReturn">返回值类型。</typeparam>
        /// <param name="command">命令定义。</param>
        /// <param name="map">把映射类型置换成返回类型的委托。</param>
        /// <param name="splitOn">映射类型之间的分隔字段，缺省值Id。</param>
        /// <returns>返回经<param name="map"/>处理的<typeparam name="TReturn"/></returns>
        Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(SlimCommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, string splitOn = "Id");

        /// <summary>
        /// 执行一个单结果集的查询语句，返回指定类型集合。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <param name="command">命令定义。</param>
        /// <returns>
        /// 返回指定类型<typeparam name="T"/>的集合数据（映射方式：列名->成员名，忽略大小写），
        /// 如果<ptypeparamaram name="T"/>是基础类型（int、string之类的）就取第一列的数据作为返回。
        /// </returns>
        Task<IEnumerable<T>> QueryAsync<T>(SlimCommandDefinition command);

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行，如果没有数据则抛出异常。
        /// </summary>
        /// <param name="command">执行语句。</param>
        /// <returns>返回动态类型数据，可以通过 *dynamic* 语法访问成员，也可以通过转成 IDictionary[string,object]访问。</returns>
        Task<dynamic> QueryFirstAsync(SlimCommandDefinition command);

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行，如果没有数据则抛出异常。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <param name="command">命令定义。</param>
        /// <returns>
        /// 返回指定类型<typeparam name="T"/>数据（映射方式：列名->成员名，忽略大小写），
        /// 如果<ptypeparamaram name="T"/>是基础类型（int、string之类的）就取第一个单元格的数据作为返回。
        /// </returns>
        Task<T> QueryFirstAsync<T>(SlimCommandDefinition command);

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行，如果没有数据则抛出异常。
        /// </summary>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回动态类型数据，可以通过 *dynamic* 语法访问成员，也可以通过转成 IDictionary[string,object]访问。</returns>
        Task<dynamic> QueryFirstAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行，如果没有数据则抛出异常。
        /// </summary>
        /// <param name="type">返回值的类型。</param>
        /// <param name="command">命令定义。</param>
        /// <returns>
        /// 返回指定类型<param name="type"/>的数据（映射方式：列名->成员名，忽略大小写），
        /// 如果<param name="type"/>是基础类型（int、string之类的）就取第一个单元格的数据作为返回。
        /// </returns>
        Task<object> QueryFirstAsync(Type type, SlimCommandDefinition command);

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行，如果没有数据则抛出异常。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>
        /// 返回指定类型<typeparam name="T"/>数据（映射方式：列名->成员名，忽略大小写），
        /// 如果<ptypeparamaram name="T"/>是基础类型（int、string之类的）就取第一个单元格的数据作为返回。
        /// </returns>
        Task<T> QueryFirstAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行，如果没有数据则抛出异常。
        /// </summary>
        /// <param name="type">返回值的类型。</param>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>
        /// 返回指定类型<param name="type"/>的数据（映射方式：列名->成员名，忽略大小写），
        /// 如果<param name="type"/>是基础类型（int、string之类的）就取第一个单元格的数据作为返回。
        /// </returns>
        Task<object> QueryFirstAsync(Type type, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行，如果没有数据则取默认值。
        /// </summary>
        /// <param name="command">命令定义。</param>
        /// <returns>返回动态类型数据，可以通过 *dynamic* 语法访问成员，也可以通过转成 IDictionary[string,object]访问。</returns>
        Task<dynamic> QueryFirstOrDefaultAsync(SlimCommandDefinition command);

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行，如果没有数据则取默认值。
        /// </summary>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回动态类型数据，可以通过 *dynamic* 语法访问成员，也可以通过转成 IDictionary[string,object]访问。</returns>
        Task<dynamic> QueryFirstOrDefaultAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行，如果没有数据则取默认值。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>
        /// 返回指定类型<typeparam name="T"/>数据（映射方式：列名->成员名，忽略大小写），
        /// 如果<ptypeparamaram name="T"/>是基础类型（int、string之类的）就取第一个单元格的数据作为返回。
        /// </returns>
        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行，如果没有数据则取默认值。
        /// </summary>
        /// <param name="type">返回值的类型。</param>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>
        /// 返回指定类型<param name="type"/>的数据（映射方式：列名->成员名，忽略大小写），
        /// 如果<param name="type"/>是基础类型（int、string之类的）就取第一个单元格的数据作为返回。
        /// </returns>
        Task<object> QueryFirstOrDefaultAsync(Type type, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行，如果没有数据则取默认值。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <param name="command">命令定义。</param>
        /// <returns>
        /// 返回指定类型<typeparam name="T"/>数据（映射方式：列名->成员名，忽略大小写），
        /// 如果<ptypeparamaram name="T"/>是基础类型（int、string之类的）就取第一个单元格的数据作为返回。
        /// </returns>
        Task<T> QueryFirstOrDefaultAsync<T>(SlimCommandDefinition command);

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行，如果没有数据则取默认值。
        /// </summary>
        /// <param name="type">返回值的类型。</param>
        /// <param name="command">命令定义。</param>
        /// <returns>
        /// 返回指定类型<param name="type"/>的数据（映射方式：列名->成员名，忽略大小写），
        /// 如果<param name="type"/>是基础类型（int、string之类的）就取第一个单元格的数据作为返回。
        /// </returns>
        Task<object> QueryFirstOrDefaultAsync(Type type, SlimCommandDefinition command);

        
        Task<GridReaderWapper> QueryMultipleAsync(SlimCommandDefinition command);
        Task<GridReaderWapper> QueryMultipleAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
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