namespace Dapper.Client
{
    /// <summary>
    /// 定义数据库访问客户端。
    /// </summary>
    public partial interface IDbClient
    {
        string ConnectionString { get; }

        ITransactionKeeper CreateTransaction();
    }
}