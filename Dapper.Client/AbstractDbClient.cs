using System;
using System.Data.Common;
using System.Data;
using System.Threading.Tasks;

namespace Dapper.Client
{
    /// <summary>
    /// <see cref="IDbClient"/>的基本实现。
    /// 这是一个抽象类。
    /// </summary>
    public abstract partial class AbstractDbClient : IDbClient
    {

        /// <summary>
        /// 获取或设置默认的命令执行超时时间。当访问数据库的方法没有指定命令执行的超时时间（即
        /// <see cref="DbCommand.CommandTimeout"/>）时，使用此超时时间。各方法通常有 timeout 参数用于指定超时
        /// 时间，当值为0时即套用此属性的值作为超时时间。
        /// 单位为秒，初始值为0（不限制）。
        /// </summary>
        public virtual int? DefaultTimeout { get; set; } = 0;

        /// <summary>
        /// 由于Dapper扩展了<see cref="IDbConnection"/>接口，
        /// 扩展方法参数都包含了Transaction，所以在AbstractDbClient中添加该字段，
        /// 理论上当未调用过<see cref="CreateTransaction"/>时都为null。
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

        public virtual ITransactionKeeper CreateTransaction()
        {
            return new ThreadLocalTransactionKeeper(Factory, ConnectionString, DefaultTimeout);
        }

        /// <summary>
        /// 把<see cref="slimCommandDefinition"/>转成<see cref="CommandDefinition"/>。
        /// </summary>
        /// <param name="slimCommandDefinition"></param>
        /// <returns></returns>
        protected CommandDefinition ConvertSlimCommandDefinition(SlimCommandDefinition slimCommandDefinition)
        {
            return new CommandDefinition(
                slimCommandDefinition.CommandText,
                slimCommandDefinition.Parameters,
                Transaction,
                DefaultTimeout,
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
        /// 创建并打开一个连接对象。
        /// </summary>
        private DbConnection CreateAndOpenConnection()
        {
            var connection = CreateConnection();
            OpenConnection(connection);

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
        private async Task<DbConnection> CreateAndOpenConnectionAsync()
        {
            var connection = CreateConnection();
            await OpenConnectionAsync(connection);
            return connection;
        }
    }
}