using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Dapper.Client
{
    /// <summary>
    /// <see cref="IDbClient"/>的基本实现。
    /// 这是一个抽象类。
    /// </summary>
    public abstract partial class AbstractDbClient
    {
        /// <summary>
        /// 执行参数化sql。
        /// </summary>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回受影响行数。</returns>
        public int Execute(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Execute(sql, param, Transaction, commandTimeout ?? DefaultWriteTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行参数化sql。
        /// </summary>
        /// <param name="command">命令定义。</param>
        /// <returns>返回受影响行数。</returns>
        public int Execute(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Execute(ConvertSlimCommandDefinitionWithWriteTimeout(command));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行参数化sql，返回<see cref="System.Data.IDataReader" />.
        /// <strong>该方法需要手动关闭连接对象。</strong>
        /// </summary>
        /// <param name="ccp">连接对象关闭操作。</param>
        /// <param name="command">命令定义。</param>
        /// <param name="commandBehavior">命令行为。</param>
        public IDataReader ExecuteReader(
            out ConnectionCloseOperate ccp, SlimCommandDefinition command, CommandBehavior commandBehavior)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                // 暴露一个关闭操作给外部，通过外部关闭当前连接。
                ccp = new ConnectionCloseOperate(connection);
                return connection.ExecuteReader(ConvertSlimCommandDefinitionWithWriteTimeout(command), commandBehavior);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 执行参数化sql，返回<see cref="System.Data.IDataReader" />.
        /// <strong>该方法需要手动关闭连接对象。</strong>
        /// </summary>
        /// <param name="ccp">连接对象关闭操作。</param>
        /// <param name="command">命令定义。</param>
        public IDataReader ExecuteReader(out ConnectionCloseOperate ccp, SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                // 暴露一个关闭操作给外部，通过外部关闭当前连接。
                ccp = new ConnectionCloseOperate(connection);
                return connection.ExecuteReader(ConvertSlimCommandDefinitionWithWriteTimeout(command));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 执行参数化sql，返回<see cref="System.Data.IDataReader" />.
        /// <strong>该方法需要手动关闭连接对象。</strong>
        /// </summary>
        /// <param name="ccp">连接对象关闭操作。</param>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        public IDataReader ExecuteReader(
            out ConnectionCloseOperate ccp,
            string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                // 暴露一个关闭操作给外部，通过外部关闭当前连接。
                ccp = new ConnectionCloseOperate(connection);
                return connection.ExecuteReader(sql, param, Transaction, commandTimeout ?? DefaultWriteTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 执行选择单个值的参数化sql。
        /// </summary>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回第一个单元格值。</returns>
        public object ExecuteScalar(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar(sql, param, Transaction, commandTimeout ?? DefaultWriteTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行选择单个值的参数化sql。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回第一个单元格值。</returns>
        public T ExecuteScalar<T>(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar<T>(sql, param, Transaction, commandTimeout ?? DefaultWriteTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行选择单个值的参数化sql。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <param name="command">命令定义。</param>
        /// <returns>返回第一个单元格值。</returns>
        public T ExecuteScalar<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar<T>(ConvertSlimCommandDefinitionWithWriteTimeout(command));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行选择单个值的参数化sql。
        /// </summary>
        /// <param name="command">命令定义。</param>
        /// <returns>返回第一个单元格值。</returns>
        public object ExecuteScalar(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar(ConvertSlimCommandDefinitionWithWriteTimeout(command));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行一个单结果集的查询语句，返回指定类型集合。
        /// </summary>
        /// <param name="type">返回值的类型。</param>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="buffered">是否将结果缓存到内存中。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>
        /// 返回指定类型<param name="type"/>的集合数据（映射方式：列名->成员名，忽略大小写），
        /// 如果<param name="type"/>是基础类型（int、string之类的）就取第一列的数据作为返回。
        /// </returns>
        public IEnumerable<object> Query(
            Type type, string sql, object param = null, bool buffered = true,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query(type, sql, param, Transaction, buffered, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行一个单结果集的查询语句，返回指定类型集合。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="buffered">是否将结果缓存到内存中。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>
        /// 返回指定类型<typeparam name="T"/>的集合数据（映射方式：列名->成员名，忽略大小写），
        /// 如果<ptypeparamaram name="T"/>是基础类型（int、string之类的）就取第一列的数据作为返回。
        /// </returns>
        public IEnumerable<T> Query<T>(
            string sql, object param = null, bool buffered = true,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<T>(sql, param, Transaction, buffered, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

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
        public IEnumerable<TReturn> Query<TReturn>(
            string sql, Type[] types, Func<object[], TReturn> map,
            object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<TReturn>(sql, types, map, param, Transaction, buffered, splitOn, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

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
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
            string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map,
            object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
                    sql, map, param, Transaction, buffered, splitOn, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行一个单结果集的查询语句，将指定的映射类型置换成返回类型。
        /// </summary>
        /// <typeparam name="TFirst">映射类型1。</typeparam>
        /// <typeparam name="TSecond">映射类型2。</typeparam>
        /// <typeparam name="TThird">映射类型3。</typeparam>
        /// <typeparam name="TFourth">映射类型4。</typeparam>
        /// <typeparam name="TFifth">映射类型5。</typeparam>
        /// <typeparam name="TSixth">映射类型6。</typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql">执行语句。</param>
        /// <param name="map">把映射类型置换成返回类型的委托。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="buffered">是否将结果缓存到内存中。</param>
        /// <param name="splitOn">映射类型之间的分隔字段，缺省值Id。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回经<param name="map"/>处理的<typeparam name="TReturn"/></returns>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
            string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object param = null,
            bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
                    sql, map, param, Transaction, buffered, splitOn, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

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
        public IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map,
            object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<TFirst, TSecond, TReturn>(
                    sql, map, param, Transaction, buffered, splitOn, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行一个单结果集的查询语句，将指定的映射类型置换成返回类型。
        /// </summary>
        /// <typeparam name="TFirst">映射类型1。</typeparam>
        /// <typeparam name="TSecond">映射类型2。</typeparam>
        /// <typeparam name="TThird">映射类型3。</typeparam>
        /// <typeparam name="TFourth">映射类型4。</typeparam>
        /// <typeparam name="TFifth">映射类型5。</typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql">执行语句。</param>
        /// <param name="map">把映射类型置换成返回类型的委托。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="buffered">是否将结果缓存到内存中。</param>
        /// <param name="splitOn">映射类型之间的分隔字段，缺省值Id。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回经<param name="map"/>处理的<typeparam name="TReturn"/></returns>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
            string sql,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null, bool buffered = true,
            string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
                    sql, map, param, Transaction, buffered, splitOn, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行一个单结果集的查询语句，将指定的映射类型置换成返回类型。
        /// </summary>
        /// <typeparam name="TFirst">映射类型1。</typeparam>
        /// <typeparam name="TSecond">映射类型2。</typeparam>
        /// <typeparam name="TThird">映射类型3。</typeparam>
        /// <typeparam name="TFourth">映射类型4。</typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql">执行语句。</param>
        /// <param name="map">把映射类型置换成返回类型的委托。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="buffered">是否将结果缓存到内存中。</param>
        /// <param name="splitOn">映射类型之间的分隔字段，缺省值Id。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回经<param name="map"/>处理的<typeparam name="TReturn"/></returns>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(
            string sql,
            Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, bool buffered = true,
            string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<TFirst, TSecond, TThird, TFourth, TReturn>(
                    sql, map, param, Transaction, buffered, splitOn, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行一个单结果集的查询语句，返回动态类型集合。
        /// </summary>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="buffered">是否将结果缓存到内存中。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回动态类型集合，每一行可以通过 *dynamic* 语法访问成员，也可以通过转成 IDictionary[string,object]访问</returns>
        public IEnumerable<dynamic> Query(string sql, object param = null, bool buffered = true,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query(sql, param, Transaction, buffered, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行一个单结果集的查询语句，将指定的映射类型置换成返回类型。
        /// </summary>
        /// <typeparam name="TFirst">映射类型1。</typeparam>
        /// <typeparam name="TSecond">映射类型2。</typeparam>
        /// <typeparam name="TThird">映射类型3。</typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql">执行语句。</param>
        /// <param name="map">把映射类型置换成返回类型的委托。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="buffered">是否将结果缓存到内存中。</param>
        /// <param name="splitOn">映射类型之间的分隔字段，缺省值Id。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回经<param name="map"/>处理的<typeparam name="TReturn"/></returns>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string sql,
            Func<TFirst, TSecond, TThird, TReturn> map, object param = null, bool buffered = true,
            string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<TFirst, TSecond, TThird, TReturn>(
                    sql, map, param, Transaction, buffered, splitOn, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行一个单结果集的查询语句，返回指定类型集合。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <param name="command">命令定义。</param>
        /// <returns>
        /// 返回指定类型<typeparam name="T"/>的集合数据（映射方式：列名->成员名，忽略大小写），
        /// 如果<ptypeparamaram name="T"/>是基础类型（int、string之类的）就取第一列的数据作为返回。
        /// </returns>
        public IEnumerable<T> Query<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<T>(ConvertSlimCommandDefinitionWithReadTimeout(command));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行，如果没有数据则抛出异常。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <param name="command">命令定义。</param>
        /// <returns>
        /// 返回指定类型<typeparam name="T"/>数据（映射方式：列名->成员名，忽略大小写），
        /// 如果<ptypeparamaram name="T"/>是基础类型（int、string之类的）就取第一个单元格的数据作为返回。
        /// </returns>
        public T QueryFirst<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirst<T>(ConvertSlimCommandDefinitionWithReadTimeout(command));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

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
        public object QueryFirst(Type type, string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirst(type, sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

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
        public T QueryFirst<T>(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirst<T>(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行，如果没有数据则抛出异常。
        /// </summary>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回动态类型数据，可以通过 *dynamic* 语法访问成员，也可以通过转成 IDictionary[string,object]访问。</returns>
        public dynamic QueryFirst(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirst(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

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
        public T QueryFirstOrDefault<T>(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault<T>(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行，如果没有数据则取默认值。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <param name="command">命令定义。</param>
        /// <returns>
        /// 返回指定类型<typeparam name="T"/>数据（映射方式：列名->成员名，忽略大小写），
        /// 如果<ptypeparamaram name="T"/>是基础类型（int、string之类的）就取第一个单元格的数据作为返回。
        /// </returns>
        public T QueryFirstOrDefault<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault<T>(ConvertSlimCommandDefinitionWithReadTimeout(command));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行，如果没有数据则取默认值。
        /// </summary>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回动态类型数据，可以通过 *dynamic* 语法访问成员，也可以通过转成 IDictionary[string,object]访问。</returns>
        public dynamic QueryFirstOrDefault(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

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
        public object QueryFirstOrDefault(Type type, string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault(type, sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        ///  执行一个多结果集的查询语句, 并通过返回值访问每个结果集。
        /// <strong>该方法需要手动关闭连接对象。</strong>
        /// </summary>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        public GridReaderWapper QueryMultiple(
            string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return new GridReaderWapper(
                    connection.QueryMultiple(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType), connection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 执行一个多结果集的查询语句, 并通过返回值访问每个结果集。
        /// <strong>该方法需要手动关闭连接对象。</strong>
        /// </summary>
        /// <param name="command">命令定义。</param>
        public GridReaderWapper QueryMultiple(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return new GridReaderWapper(connection.QueryMultiple(ConvertSlimCommandDefinitionWithReadTimeout(command)), connection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行。
        /// 异常情况：没有项、有多项。
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
        public object QuerySingle(Type type, string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingle(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行。
        /// 异常情况：没有项、有多项。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <param name="command">命令定义。</param>
        /// <returns>
        /// 返回指定类型<typeparam name="T"/>的数据（映射方式：列名->成员名，忽略大小写），
        /// 如果<ptypeparamaram name="T"/>是基础类型（int、string之类的）就取第一个单元格的数据作为返回。
        /// </returns>
        public T QuerySingle<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingle<T>(ConvertSlimCommandDefinitionWithReadTimeout(command));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行。
        /// 异常情况：没有项、有多项。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>
        /// 返回指定类型<typeparam name="T"/>的数据（映射方式：列名->成员名，忽略大小写），
        /// 如果<ptypeparamaram name="T"/>是基础类型（int、string之类的）就取第一个单元格的数据作为返回。
        /// </returns>
        public T QuerySingle<T>(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingle<T>(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行。
        /// 异常情况：没有项、有多项。
        /// </summary>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回动态类型，可以通过 *dynamic* 语法访问成员，也可以通过转成 IDictionary[string,object]访问。</returns>
        public dynamic QuerySingle(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingle(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行, 没有项就取默认值。
        /// 异常情况：有多项。
        /// </summary>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>返回动态类型，可以通过 *dynamic* 语法访问成员，也可以通过转成 IDictionary[string,object]访问。</returns>
        public dynamic QuerySingleOrDefault(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingleOrDefault(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行, 没有项就取默认值。
        /// 异常情况：有多项。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <param name="command">命令定义。</param>
        /// <returns>
        /// 返回指定类型<typeparam name="T"/>的数据（映射方式：列名->成员名，忽略大小写），
        /// 如果<ptypeparamaram name="T"/>是基础类型（int、string之类的）就取第一个单元格的数据作为返回。
        /// </returns>
        public T QuerySingleOrDefault<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingleOrDefault<T>(ConvertSlimCommandDefinitionWithReadTimeout(command));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行, 没有项就取默认值。
        /// 异常情况：有多项。
        /// </summary>
        /// <typeparam name="T">返回值的类型。</typeparam>
        /// <param name="sql">执行语句。</param>
        /// <param name="param">执行参数。</param>
        /// <param name="commandTimeout">超时时间（秒）。</param>
        /// <param name="commandType">命令类型。</param>
        /// <returns>
        /// 返回指定类型<typeparam name="T"/>的数据（映射方式：列名->成员名，忽略大小写），
        /// 如果<ptypeparamaram name="T"/>是基础类型（int、string之类的）就取第一个单元格的数据作为返回。
        /// </returns>
        public T QuerySingleOrDefault<T>(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingleOrDefault<T>(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// 执行一个单结果集的查询语句, 取结果集的第一行, 没有项就取默认值。
        /// 异常情况：有多项。
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
        public object QuerySingleOrDefault(Type type, string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingleOrDefault(type, sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }
    }
}