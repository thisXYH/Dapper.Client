/*
using System.Data;
using System.Data.Common;

namespace Dapper.Client
{
    /// <summary>
    /// MSSQL Client.
    /// </summary>
    public class SqlDbClient : AbstractDbClient
    {
        /// <summary>
        /// 使用连接字符串初始化<see cref="SqlDbClient"/>的新实例。
        /// </summary>
        /// <param name="connectionString">连接字符串。</param>
        public SqlDbClient(string connectionString)
        {
            ArgAssert.NotNullOrEmptyOrWhitespace(connectionString, nameof(connectionString));
            ConnectionString = connectionString;
        }

        /// <summary>
        /// 事务对象，直接通过客户端直接调用的时候为null。
        /// </summary>
        protected override IDbTransaction Transaction => null;

        /// <summary>
        /// 获取当前实例所使用的数据库连接字符串。
        /// </summary>
        public override string ConnectionString { get; }

        /// <summary>
        /// 获取当前实例所使用的<see cref="DbProviderFactory"/>实例。
        /// </summary>
        protected override DbProviderFactory Factory => SqlClientFactory.Instance;
    }

    //public class OracleDbClient : AbstractDbClient
    //{
    //    public OracleDbClient(string connectionString)
    //    {
    //        ArgAssert.NotNullOrEmptyOrWhitespace(connectionString, nameof(connectionString));
    //        ConnectionString = connectionString;
    //    }

    //    protected override IDbTransaction Transaction { get; } = null;
    //    public override string ConnectionString { get; }
    //    protected override DbProviderFactory Factory { get; } = OracleClientFactory.Instance;
    //}

    public class MySqlDbClient : AbstractDbClient
    {
        public MySqlDbClient(string connectionString)
        {
            ArgAssert.NotNullOrEmptyOrWhitespace(connectionString, nameof(connectionString));
            ConnectionString = connectionString;
        }

        protected override IDbTransaction Transaction { get; } = null;
        public override string ConnectionString { get; }
        protected override DbProviderFactory Factory { get; } = MySqlClientFactory.Instance;
    }
}
*/