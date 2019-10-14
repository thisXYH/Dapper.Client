namespace Dapper.Client
{
    /// <summary>
    /// 定义数据库访问客户端。
    /// </summary>
    public partial interface IDbClient
    {
        /// <summary>
        /// 获取当前实例所使用的数据库连接字符串。
        /// </summary>
        string ConnectionString { get; }

        /// <summary>
        /// 创建一个事务持有者实例，通过该实例执行的命令都在一个事务中。
        /// </summary>
        /// <returns></returns>
        ITransactionKeeper CreateTransaction();
    }
}