﻿using System;

namespace Dapper.Client
{
    /// <summary>
    /// <see cref="IDbClient"/>的工程对象。
    /// </summary>
    public static class DbClientFactory
    {
        public static IDbClient CreateDbClient(DbClientType type, string connectionString, int? defaultTimeout)
        {
            switch (type)
            {
                case DbClientType.SqlServer:
                    return new SqlDbClient(connectionString) { DefaultTimeout = defaultTimeout };
                case DbClientType.MySql:
                    throw new NotImplementedException();
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

        MySql = 1
    }
}
