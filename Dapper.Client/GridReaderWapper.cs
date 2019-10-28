using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Dapper.Client
{
    /// <summary>
    /// 对<see cref="GridReader"/>的包装类，添加关闭连接对象的方法。
    /// </summary>
    public sealed class GridReaderWapper : IDisposable
    {
        /// <summary>
        /// 当前持有的GridReader对象。
        /// </summary>
        private readonly GridReader _gridReader;

        /// <summary>
        /// 当前GridReader对象使用的连接对象。
        /// </summary>
        private DbConnection _connection;

        /// <summary>
        /// 当前连接对象是否开启了事务。
        /// </summary>
        private readonly bool _inTransaction;

        /// <summary>
        /// Dispose 方法是否已经执行过。
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// 连接对象是否已经关闭, 默认值false。
        /// </summary>
        private bool _isConnectionClosed;

        /// <summary>
        /// 创建<see cref="GridReaderWapper"/>新实例。
        /// </summary>
        /// <param name="gridReader">被包装的<see cref="IDataReader"/>对象。</param>
        /// <param name="connection"><see cref="IDataReader"/>对象使用的<see cref="IDbConnection"/>连接对象。</param>
        /// <param name="inTransaction">当前连接对象是否开启了事务。</param>
        internal GridReaderWapper(GridReader gridReader, DbConnection connection, bool inTransaction)
        {
            ArgAssert.NotNull(gridReader, nameof(gridReader));
            ArgAssert.NotNull(connection, nameof(connection));

            _gridReader = gridReader;
            _connection = connection;
            _inTransaction = inTransaction;
        }

        public IDbCommand Command
        {
            get => _gridReader.Command;
            set => _gridReader.Command = value;
        }

        /// <summary>
        /// 是否已读取完，当读取完时连接对象会自动关闭。
        /// <strong>开启事务的情况下不自动关闭</strong>
        /// </summary>
        public bool IsConsumed => _gridReader.IsConsumed;

        public void Dispose()
        {
            if (_disposed)
                return;
            _disposed = true;

            _gridReader.Dispose();
            CloseConnection();
            GC.SuppressFinalize(this);
        }

        ~GridReaderWapper()
        {
            if (_disposed)
                return;

            // 参考：
            // https://msdn.microsoft.com/en-us/library/system.data.common.dbconnection.close.aspx
            // -----
            // Do not call Close or Dispose on a Connection, a DataReader, or any other managed object 
            // in the Finalize method of your class. In a finalizer, you should only release unmanaged 
            // resources that your class owns directly.
            // -----
            // Finalize 中不能调用 DbConnection.Close，否则会出现异常：
            //     InvalidOperationException: Internal .Net Framework Data Provider error 1.
            // 所以仅在从 Dispose 方法进入时关闭连接。但 DbConnection 自身的释放可能不会很及时，
            // 这里只能先释放掉GridReader对象。
            try
            {
                _gridReader.Dispose();
            }
            catch
            {
                // 忽略异常，否则在GC线程内抛出异常会导致整个程序崩溃。
            }
        }

        /// <summary>
        /// 当 <see cref="IsConsumed"/> = true时关闭连接。
        /// </summary>
        private void CheckAndCloseConnection()
        {
            if (!_gridReader.IsConsumed) return;

            CloseConnection();
        }

        /// <summary>
        /// 关闭链接。 
        /// </summary>
        private void CloseConnection()
        {
            if (_inTransaction || _isConnectionClosed || _connection == null || _connection.State == ConnectionState.Closed) return;

            _isConnectionClosed = true;
            _connection.Close();
            _connection = null;
        }

        public IEnumerable<TReturn> Read<TReturn>(Type[] types, Func<object[], TReturn> map, string splitOn = "id", bool buffered = true)
        {
            var temp = _gridReader.Read(types, map, splitOn, buffered);
            CheckAndCloseConnection();
            return temp;
        }

        public IEnumerable<TReturn> Read<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> func, string splitOn = "id", bool buffered = true)
        {
            var temp = _gridReader.Read(func, splitOn, buffered);
            CheckAndCloseConnection();
            return temp;
        }

        public IEnumerable<TReturn> Read<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> func, string splitOn = "id", bool buffered = true)
        {
            var temp = _gridReader.Read(func, splitOn, buffered);
            CheckAndCloseConnection();
            return temp;
        }

        public IEnumerable<TReturn> Read<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> func, string splitOn = "id", bool buffered = true)
        {
            var temp = _gridReader.Read(func, splitOn, buffered);
            CheckAndCloseConnection();
            return temp;
        }

        public IEnumerable<TReturn> Read<TFirst, TSecond, TThird, TFourth, TReturn>(Func<TFirst, TSecond, TThird, TFourth, TReturn> func, string splitOn = "id", bool buffered = true)
        {
            var temp = _gridReader.Read(func, splitOn, buffered);
            CheckAndCloseConnection();
            return temp;
        }

        public IEnumerable<TReturn> Read<TFirst, TSecond, TThird, TReturn>(Func<TFirst, TSecond, TThird, TReturn> func, string splitOn = "id", bool buffered = true)
        {
            var temp = _gridReader.Read(func, splitOn, buffered);
            CheckAndCloseConnection();
            return temp;
        }

        public IEnumerable<TReturn> Read<TFirst, TSecond, TReturn>(Func<TFirst, TSecond, TReturn> func, string splitOn = "id", bool buffered = true)
        {
            var temp = _gridReader.Read(func, splitOn, buffered);
            CheckAndCloseConnection();
            return temp;
        }

        public IEnumerable<object> Read(Type type, bool buffered = true)
        {
            var temp = _gridReader.Read(type, buffered);
            CheckAndCloseConnection();
            return temp;
        }

        public IEnumerable<T> Read<T>(bool buffered = true)
        {
            var temp = _gridReader.Read<T>(buffered);
            CheckAndCloseConnection();
            return temp;
        }

        public IEnumerable<dynamic> Read(bool buffered = true)
        {
            var temp = _gridReader.Read(buffered);
            CheckAndCloseConnection();
            return temp;
        }

        public async Task<IEnumerable<dynamic>> ReadAsync(bool buffered = true)
        {
            var temp = await _gridReader.ReadAsync(buffered);
            CheckAndCloseConnection();
            return temp;
        }

        public async Task<IEnumerable<object>> ReadAsync(Type type, bool buffered = true)
        {
            var temp = await _gridReader.ReadAsync(type, buffered);
            CheckAndCloseConnection();
            return temp;
        }

        public async Task<IEnumerable<T>> ReadAsync<T>(bool buffered = true)
        {
            var temp = await _gridReader.ReadAsync<T>(buffered);
            CheckAndCloseConnection();
            return temp;
        }

        public T ReadFirst<T>()
        {
            var temp = _gridReader.ReadFirst<T>();
            CheckAndCloseConnection();
            return temp;
        }

        public object ReadFirst(Type type)
        {
            var temp = _gridReader.ReadFirst(type);
            CheckAndCloseConnection();
            return temp;
        }

        public dynamic ReadFirst()
        {
            var temp = _gridReader.ReadFirst();
            CheckAndCloseConnection();
            return temp;
        }

        public async Task<T> ReadFirstAsync<T>()
        {
            var temp = await _gridReader.ReadFirstAsync<T>();
            CheckAndCloseConnection();
            return temp;
        }

        public async Task<object> ReadFirstAsync(Type type)
        {
            var temp = await _gridReader.ReadFirstAsync(type);
            CheckAndCloseConnection();
            return temp;
        }

        public async Task<dynamic> ReadFirstAsync()
        {
            var temp = await _gridReader.ReadFirstAsync();
            CheckAndCloseConnection();
            return temp;
        }

        public T ReadFirstOrDefault<T>()
        {
            var temp = _gridReader.ReadFirstOrDefault<T>();
            CheckAndCloseConnection();
            return temp;
        }

        public object ReadFirstOrDefault(Type type)
        {
            var temp = _gridReader.ReadFirstOrDefault(type);
            CheckAndCloseConnection();
            return temp;
        }

        public dynamic ReadFirstOrDefault()
        {
            var temp = _gridReader.ReadFirstOrDefault();
            CheckAndCloseConnection();
            return temp;
        }

        public async Task<T> ReadFirstOrDefaultAsync<T>()
        {
            var temp = await _gridReader.ReadFirstOrDefaultAsync<T>();
            CheckAndCloseConnection();
            return temp;
        }

        public async Task<dynamic> ReadFirstOrDefaultAsync()
        {
            var temp = await _gridReader.ReadFirstOrDefaultAsync();
            CheckAndCloseConnection();
            return temp;
        }

        public async Task<object> ReadFirstOrDefaultAsync(Type type)
        {
            var temp = await _gridReader.ReadFirstOrDefaultAsync(type);
            CheckAndCloseConnection();
            return temp;
        }

        public dynamic ReadSingle()
        {
            var temp = _gridReader.ReadSingle();
            CheckAndCloseConnection();
            return temp;
        }

        public object ReadSingle(Type type)
        {
            var temp = _gridReader.ReadSingle(type);
            CheckAndCloseConnection();
            return temp;
        }

        public T ReadSingle<T>()
        {
            var temp = _gridReader.ReadSingle<T>();
            CheckAndCloseConnection();
            return temp;
        }

        public async Task<T> ReadSingleAsync<T>()
        {
            var temp = await _gridReader.ReadSingleAsync<T>();
            CheckAndCloseConnection();
            return temp;
        }

        public async Task<dynamic> ReadSingleAsync()
        {
            var temp = await _gridReader.ReadSingleAsync();
            CheckAndCloseConnection();
            return temp;
        }

        public async Task<object> ReadSingleAsync(Type type)
        {
            var temp = await _gridReader.ReadSingleAsync(type);
            CheckAndCloseConnection();
            return temp;
        }

        public dynamic ReadSingleOrDefault()
        {
            var temp = _gridReader.ReadSingleOrDefault();
            CheckAndCloseConnection();
            return temp;
        }

        public object ReadSingleOrDefault(Type type)
        {
            var temp = _gridReader.ReadSingleOrDefault(type);
            CheckAndCloseConnection();
            return temp;
        }

        public T ReadSingleOrDefault<T>()
        {
            var temp = _gridReader.ReadSingleOrDefault<T>();
            CheckAndCloseConnection();
            return temp;
        }

        public async Task<object> ReadSingleOrDefaultAsync(Type type)
        {
            var temp = await _gridReader.ReadSingleOrDefaultAsync(type);
            CheckAndCloseConnection();
            return temp;
        }

        public async Task<dynamic> ReadSingleOrDefaultAsync()
        {
            var temp = await _gridReader.ReadSingleOrDefaultAsync();
            CheckAndCloseConnection();
            return temp;
        }

        public async Task<T> ReadSingleOrDefaultAsync<T>()
        {
            var temp = await _gridReader.ReadSingleOrDefaultAsync<T>();
            CheckAndCloseConnection();
            return temp;
        }
    }
}
