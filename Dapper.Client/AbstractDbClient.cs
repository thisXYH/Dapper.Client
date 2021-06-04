using System;
using System.Data.Common;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dapper.Client
{
    /// <summary>
    /// <see cref="IDbClient"/>的基本实现。
    /// </summary>
    public abstract partial class AbstractDbClient : IDbClient
    {

        /// <summary>
        /// 获取或设置默认的<strong>读取操作</strong>命令执行超时时间（秒）。
        /// 当访问数据库的方法没有指定命令执行的超时时间（即<see cref="DbCommand.CommandTimeout"/>）时，使用此超时时间。
        /// 各方法通常有 commandTimeout 参数用于指定超时时间，当值为null时即套用此属性的值作为超时时间。
        /// 初始值为null（不限制）。
        /// </summary>
        public virtual int? DefaultReadTimeout { get; set; }

        /// <summary>
        /// 获取或设置默认的<strong>写入操作</strong>命令执行超时时间（秒）。
        /// 当访问数据库的方法没有指定命令执行的超时时间（即<see cref="DbCommand.CommandTimeout"/>）时，使用此超时时间。
        /// 各方法通常有 commandTimeout 参数用于指定超时时间，当值为null时即套用此属性的值作为超时时间。
        /// 初始值为null（不限制）。
        /// </summary>
        public virtual int? DefaultWriteTimeout { get; set; }

        /// <summary>
        /// 获取当前实例所使用的事务对象。
        /// </summary>
        protected abstract IDbTransaction Transaction { get; }

        /// <summary>
        /// 获取当前实例所使用的数据库连接字符串。
        /// </summary>
        public abstract string ConnectionString { get; }

        /// <summary>
        /// 获取当前实例所使用的<see cref="DbProviderFactory"/>实例。
        /// </summary>
        /// <value></value>
        protected abstract DbProviderFactory Factory { get; }

        /// <summary>
        /// 创建一个事务持有者实例，通过该实例执行的命令都在一个事务中。
        /// </summary>
        /// <returns></returns>
        public virtual ITransactionKeeper CreateTransaction()
        {
            return new ThreadLocalTransactionKeeper(Factory, ConnectionString, DefaultReadTimeout, DefaultWriteTimeout);
        }

        /// <summary>
        /// 把<see cref="SlimCommandDefinition"/>转成<see cref="CommandDefinition"/>。
        /// 其中使用<see cref="DefaultReadTimeout"/>做超时时间的缺省值。
        /// </summary>
        protected CommandDefinition ConvertSlimCommandDefinitionWithReadTimeout(
            SlimCommandDefinition slimCommandDefinition)
        {
            return new CommandDefinition(
                slimCommandDefinition.CommandText,
                slimCommandDefinition.Parameters,
                Transaction,
                slimCommandDefinition.CommandTimeout ?? DefaultReadTimeout,
                slimCommandDefinition.CommandType,
                slimCommandDefinition.Flags,
                slimCommandDefinition.CancellationToken);
        }

        /// <summary>
        /// 把<see cref="SlimCommandDefinition"/>转成<see cref="CommandDefinition"/>。
        /// 其中使用<see cref="DefaultWriteTimeout"/>做超时时间的缺省值。
        /// </summary>
        protected CommandDefinition ConvertSlimCommandDefinitionWithWriteTimeout(
            SlimCommandDefinition slimCommandDefinition)
        {
            return new CommandDefinition(
                slimCommandDefinition.CommandText,
                slimCommandDefinition.Parameters,
                Transaction,
                slimCommandDefinition.CommandTimeout ?? DefaultWriteTimeout,
                slimCommandDefinition.CommandType,
                slimCommandDefinition.Flags,
                slimCommandDefinition.CancellationToken);
        }

        /// <summary>
        /// 创建一个连接对象。
        /// </summary>
        protected virtual DbConnection CreateConnection()
        {
            var connection = Factory.CreateConnection();

            if (connection == null)
                throw new NotSupportedException("获取数据库连接失败。");

            connection.ConnectionString = ConnectionString;
            return connection;
        }

        /// <summary>
        /// 打开连接。
        /// </summary>
        /// <param name="connection">连接对象。</param>
        protected virtual void OpenConnection(DbConnection connection)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
        }

        /// <summary>
        /// 打开连接。
        /// </summary>
        /// <param name="connection">连接对象。</param>
        protected virtual async Task OpenConnectionAsync(DbConnection connection)
        {
            if (connection.State != ConnectionState.Open)
                await connection.OpenAsync();
        }

        /// <summary>
        /// 创建并打开一个连接对象。
        /// </summary>
        private DbConnection CreateAndOpenConnection()
        {
            var connection = CreateConnection();
            OpenConnection(connection);

            return connection;
        }

        /// <summary>
        /// 创建并打开一个连接对象。
        /// </summary>
        private async Task<DbConnection> CreateAndOpenConnectionAsync()
        {
            var connection = CreateConnection();
            await OpenConnectionAsync(connection);
            return connection;
        }

        /// <summary>
        /// 关闭连接。
        /// </summary>
        /// <param name="connection"></param>
        protected virtual void CloseConnection(DbConnection connection)
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }

        private IEnumerable<IDataRecord> YieldRows(DbConnection connection, DbDataReader reader)
        {
            try
            {
                while (reader.Read())
                {
                    yield return reader;
                }
            }
            finally
            {
                if (!reader.IsClosed)
                    reader.Close();

                if (connection != null)
                    CloseConnection(connection);
            }
        }
    }
}