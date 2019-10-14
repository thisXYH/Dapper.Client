using System;
using System.Data;
using System.Data.Common;

namespace Dapper.Client
{
    /// <summary>
    /// 数据库链接关闭操作。
    /// </summary>
    public class ConnectionCloseOperate : IDisposable
    {
        /// <summary>
        /// 当前持有的链接对象。
        /// </summary>
        private readonly DbConnection _connection;

        internal ConnectionCloseOperate(DbConnection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// 释放资源。
        /// </summary>
        public void Dispose()
        {
            Done();
        }

        /// <summary>
        /// 关闭链接。
        /// </summary>
        public void Done()
        {
            if (_connection.State != ConnectionState.Closed)
                _connection.Close();
        }
    }
}
