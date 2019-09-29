using System;
using System.Data.Common;
using System.Data;
using System.Threading.Tasks;

namespace Dapper.Client
{
    public abstract partial class AbstractDbClient
    {

        /// <summary>
        /// 获取或设置默认的命令执行超时时间。当访问数据库的方法没有指定命令执行的超时时间（即
        /// <see cref="DbCommand.CommandTimeout"/>）时，使用此超时时间。各方法通常有 timeout 参数用于指定超时
        /// 时间，当值为0时即套用此属性的值作为超时时间。
        /// 单位为秒，初始值为0（不限制）。
        /// </summary>
        public virtual int DefaultTimeout { get; set; } = 0;

        /// <summary>
        /// 获取当前实例所使用的数据库连接字符串。
        /// </summary>
        public abstract string ConnectionString { get; }

        /// <summary>
        /// 获取当前实例所使用的<see cref="DbProviderFactory"/>实例。
        /// </summary>
        /// <value></value>
        protected abstract DbProviderFactory Factory { get; }

        public ITransactionKeeper CreateTransaction()
        {
            throw new NotImplementedException();
        }

        protected virtual DbConnection CreateConnection()
        {
            var connection = Factory.CreateConnection();

            if (connection == null)
                throw new NotSupportedException("获取数据库连接失败。");

            connection.ConnectionString = ConnectionString;
            return connection;
        }

        protected virtual void OpenConnection(DbConnection connection)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
        }

        private DbConnection CreateAndOpenConnection()
        {
            var connection = CreateConnection();
            OpenConnection(connection);

            return connection;
        }

        protected virtual void CloseConnection(DbConnection connection)
        {
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }

        protected virtual async Task OpenConnectionAsync(DbConnection connection)
        {
            if (connection.State != ConnectionState.Open)
                await connection.OpenAsync();
        }
        
        private async Task<DbConnection> CreateAndOpenConnectionAsync()
        {
            var connection = CreateConnection();
            await OpenConnectionAsync(connection);
            return connection;
        }
    }
}