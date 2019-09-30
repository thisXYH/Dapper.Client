using System.Data;
using System.Data.Common;

#if NET461
using System.Data.SqlClient;
#elif NETSTANDARD2_0
using Microsoft.Data.SqlClient;
#endif

namespace Dapper.Client
{
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
        /// 事务对象，默认通过客户端直接调用的时候为null。
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
}