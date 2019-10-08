using System;
using System.Data;
using System.Data.Common;
using System.Transactions;

namespace Dapper.Client
{
    /// <summary>
    /// 使用MSDTC进行的分布式事务控制，参考文档：
    /// https://docs.microsoft.com/zh-cn/dotnet/api/system.transactions.transactionscope?view=netframework-4.8
    /// https://www.cnblogs.com/jianxuanbing/p/7242254.html
    /// </summary>
    public sealed class TransactionScopeTransactionKeeper : AbstractDbClient, ITransactionKeeper
    {
        private readonly TransactionScope _tran;
        private bool _transactionCompleted;
        private bool _disposed;

        protected override IDbTransaction Transaction => null;
        public override string ConnectionString { get; }
        protected override DbProviderFactory Factory { get; }

        public TransactionScopeTransactionKeeper(
            DbProviderFactory dbProviderFactory, string connectionString, int? commandReadTimeout = null,
            int? commandWriteTimeout = null)
        {
            ArgAssert.NotNull(dbProviderFactory, nameof(dbProviderFactory));
            ArgAssert.NotNullOrEmptyOrWhitespace(connectionString, nameof(connectionString));

            Factory = dbProviderFactory;
            ConnectionString = connectionString;
            DefaultReadTimeout = commandReadTimeout;
            DefaultWriteTimeout = commandWriteTimeout;

            // 鉴于应用场景，直接开启事务控制（不过数据库连接还没初始化）
            _tran = new TransactionScope();
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            _tran.Dispose();
            _disposed = true;
        }

        public void Commit()
        {
            ValidateStatus();

            _tran.Complete();
            _transactionCompleted = true;
        }

        public void Rollback()
        {
            Dispose();
        }

        /// <inheritdoc cref="IDbClient.CreateTransaction"/>
        public override ITransactionKeeper CreateTransaction()
        {
            ValidateStatus();
            return this;
        }

        /// <inheritdoc cref="AbstractDbClient.CreateConnection"/>
        protected override DbConnection CreateConnection()
        {
            ValidateStatus();
            return base.CreateConnection();
        }

        private void ValidateStatus()
        {
            if (_transactionCompleted)
                throw new InvalidOperationException("The transaction was finished.");

            if (_disposed)
                throw new ObjectDisposedException(GetType().Name);
        }
    }
}
