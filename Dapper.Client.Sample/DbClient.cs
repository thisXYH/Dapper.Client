using System;
using System.Data;
using System.Data.Common;

namespace Dapper.Client.Sample
{
    public static class Db
    {
        public static IDbClient TestDb =>
            DbClientFactory.CreateDbClient(DbClientType.MySql, "ConnectionString");
    }

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
        protected override DbProviderFactory Factory => System.Data.SqlClient.SqlClientFactory.Instance;
    }

    /// <summary>
    /// MSSQL Client.
    /// </summary>
    public class MysqlDbClient : AbstractDbClient
    {
        /// <summary>
        /// 使用连接字符串初始化<see cref="MysqlDbClient"/>的新实例。
        /// </summary>
        /// <param name="connectionString">连接字符串。</param>
        public MysqlDbClient(string connectionString)
        {
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
        protected override DbProviderFactory Factory => MySql.Data.MySqlClient.MySqlClientFactory.Instance;
    }

    /// <summary>
    /// <see cref="IDbClient"/>的工程对象。
    /// </summary>
    public static class DbClientFactory
    {
        public static IDbClient CreateDbClient(DbClientType type, string connectionString, int? defaultReadTimeout = null, int? defaultWriteTimeout = null)
        {
            switch (type)
            {
                case DbClientType.SqlServer:
                    return new SqlDbClient(connectionString) { DefaultReadTimeout = defaultReadTimeout, DefaultWriteTimeout = defaultWriteTimeout };
                case DbClientType.MySql:
                    return new MysqlDbClient(connectionString) { DefaultReadTimeout = defaultReadTimeout, DefaultWriteTimeout = defaultWriteTimeout };
                case DbClientType.Oracle:
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }

    /// <summary>
    /// 数据库类型。
    /// </summary>
    public enum DbClientType
    {
        SqlServer = 1,

        MySql = 2,

        Oracle = 3
    }
}