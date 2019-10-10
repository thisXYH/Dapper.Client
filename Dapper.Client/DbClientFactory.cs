using System;

namespace Dapper.Client
{
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
                    return new MySqlDbClient(connectionString) { DefaultReadTimeout = defaultReadTimeout, DefaultWriteTimeout = defaultWriteTimeout };
                case DbClientType.Oracle:
                    return new OracleDbClient(connectionString) { DefaultReadTimeout = defaultReadTimeout, DefaultWriteTimeout = defaultWriteTimeout };
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
        SqlServer = 0,

        MySql = 1,

        Oracle = 2
    }
}
