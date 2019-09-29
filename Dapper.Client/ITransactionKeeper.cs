using System;

namespace Dapper.Client
{
    /// <summary>
    /// 定义数据库事务容器。
    /// </summary>
    public interface ITransactionKeeper : IDbClient, IDisposable
    {
        void Commit();

        void Rollback();
    }
}