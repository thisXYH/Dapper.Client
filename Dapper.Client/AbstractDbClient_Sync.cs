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
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        ///<inheritdoc/>
        public IEnumerable<IDataRecord> ExecuteReader(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            DbDataReader reader = null;
            try
            {
                connection = CreateAndOpenConnection();
                reader = (DbDataReader)connection.ExecuteReader(
                        sql, param, Transaction, commandTimeout ?? DefaultWriteTimeout, commandType);
                return YieldRows(connection, reader);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                if (connection != null)
                    CloseConnection(connection);
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
        public object Scalar(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar(sql, param, Transaction, commandTimeout ?? DefaultWriteTimeout, commandType);
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
        public T Scalar<T>(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar<T>(sql, param, Transaction, commandTimeout ?? DefaultWriteTimeout, commandType);
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
        public IEnumerable<object> List(
            Type type, string sql, object param = null, bool buffered = true,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query(type, sql, param, Transaction, buffered, commandTimeout ?? DefaultReadTimeout, commandType);
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
        public IEnumerable<T> List<T>(
            string sql, object param = null, bool buffered = true,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<T>(sql, param, Transaction, buffered, commandTimeout ?? DefaultReadTimeout, commandType);
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
        public T Get<T>(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault<T>(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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
        public dynamic Get(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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
        public object Get(Type type, string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault(type, sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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
                    connection.QueryMultiple(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType),
                    connection, Transaction != null);
            }
            catch (Exception)
            {
                if (connection != null)
                    CloseConnection(connection);

                throw;
            }
        }

    }
}