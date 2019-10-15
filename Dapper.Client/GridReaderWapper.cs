using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Dapper.Client
{
    /// <summary>
    /// 对<see cref="GridReader"/>的包装类，添加关闭连接对象的方法。
    /// </summary>
    public class GridReaderWapper : IDisposable
    {
        private readonly GridReader _gridReader;
        private IDbConnection _connection;

        internal GridReaderWapper(GridReader gridReader, IDbConnection connection)
        {
            _gridReader = gridReader;
            _connection = connection;
        }

        public IDbCommand Command
        {
            get => _gridReader.Command;
            set => _gridReader.Command = value;
        }

        public bool IsConsumed => _gridReader.IsConsumed;

        public IDbConnection Connection => _connection;

        public void Dispose()
        {
            _gridReader.Dispose();

            CloseConnection();
        }

        /// <summary>
        /// 当 <see cref="IsConsumed"/> = true时关闭连接。
        /// </summary>
        private void CloseConnectionThenIsConsumedIsTrue()
        {
            if (IsConsumed)
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// 关闭链接。 
        /// </summary>
        private void CloseConnection()
        {
            if (_connection != null && _connection.State != ConnectionState.Closed)
            {
                _connection.Close();
                _connection = null;
            }
        }

        public IEnumerable<TReturn> Read<TReturn>(Type[] types, Func<object[], TReturn> map, string splitOn = "id", bool buffered = true)
        {
            var temp = _gridReader.Read(types, map, splitOn, buffered);
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public IEnumerable<TReturn> Read<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> func, string splitOn = "id", bool buffered = true)
        {
            var temp = _gridReader.Read(func, splitOn, buffered);
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public IEnumerable<TReturn> Read<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> func, string splitOn = "id", bool buffered = true)
        {
            var temp = _gridReader.Read(func, splitOn, buffered);
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public IEnumerable<TReturn> Read<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> func, string splitOn = "id", bool buffered = true)
        {
            var temp = _gridReader.Read(func, splitOn, buffered);
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public IEnumerable<TReturn> Read<TFirst, TSecond, TThird, TFourth, TReturn>(Func<TFirst, TSecond, TThird, TFourth, TReturn> func, string splitOn = "id", bool buffered = true)
        {
            var temp = _gridReader.Read(func, splitOn, buffered);
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public IEnumerable<TReturn> Read<TFirst, TSecond, TThird, TReturn>(Func<TFirst, TSecond, TThird, TReturn> func, string splitOn = "id", bool buffered = true)
        {
            var temp = _gridReader.Read(func, splitOn, buffered);
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public IEnumerable<TReturn> Read<TFirst, TSecond, TReturn>(Func<TFirst, TSecond, TReturn> func, string splitOn = "id", bool buffered = true)
        {
            var temp = _gridReader.Read(func, splitOn, buffered);
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public IEnumerable<object> Read(Type type, bool buffered = true)
        {
            var temp = _gridReader.Read(type, buffered);
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public IEnumerable<T> Read<T>(bool buffered = true)
        {
            var temp = _gridReader.Read<T>(buffered);
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public IEnumerable<dynamic> Read(bool buffered = true)
        {
            var temp = _gridReader.Read(buffered);
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public async Task<IEnumerable<dynamic>> ReadAsync(bool buffered = true)
        {
            var temp = await _gridReader.ReadAsync(buffered);
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public async Task<IEnumerable<object>> ReadAsync(Type type, bool buffered = true)
        {
            var temp = await _gridReader.ReadAsync(type, buffered);
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public async Task<IEnumerable<T>> ReadAsync<T>(bool buffered = true)
        {
            var temp = await _gridReader.ReadAsync<T>(buffered);
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public T ReadFirst<T>()
        {
            var temp = _gridReader.ReadFirst<T>();
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public object ReadFirst(Type type)
        {
            var temp = _gridReader.ReadFirst(type);
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public dynamic ReadFirst()
        {
            var temp = _gridReader.ReadFirst();
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public async Task<T> ReadFirstAsync<T>()
        {
            var temp = await _gridReader.ReadFirstAsync<T>();
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public async Task<object> ReadFirstAsync(Type type)
        {
            var temp = await _gridReader.ReadFirstAsync(type);
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public async Task<dynamic> ReadFirstAsync()
        {
            var temp = await _gridReader.ReadFirstAsync();
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public T ReadFirstOrDefault<T>()
        {
            var temp = _gridReader.ReadFirstOrDefault<T>();
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public object ReadFirstOrDefault(Type type)
        {
            var temp = _gridReader.ReadFirstOrDefault(type);
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public dynamic ReadFirstOrDefault()
        {
            var temp = _gridReader.ReadFirstOrDefault();
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public async Task<T> ReadFirstOrDefaultAsync<T>()
        {
            var temp = await _gridReader.ReadFirstOrDefaultAsync<T>();
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public async Task<dynamic> ReadFirstOrDefaultAsync()
        {
            var temp = await _gridReader.ReadFirstOrDefaultAsync();
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public async Task<object> ReadFirstOrDefaultAsync(Type type)
        {
            var temp = await _gridReader.ReadFirstOrDefaultAsync(type);
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public dynamic ReadSingle()
        {
            var temp = _gridReader.ReadSingle();
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public object ReadSingle(Type type)
        {
            var temp = _gridReader.ReadSingle(type);
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public T ReadSingle<T>()
        {
            var temp = _gridReader.ReadSingle<T>();
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public async Task<T> ReadSingleAsync<T>()
        {
            var temp = await _gridReader.ReadSingleAsync<T>();
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public async Task<dynamic> ReadSingleAsync()
        {
            var temp = await _gridReader.ReadSingleAsync();
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public async Task<object> ReadSingleAsync(Type type)
        {
            var temp = await _gridReader.ReadSingleAsync(type);
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public dynamic ReadSingleOrDefault()
        {
            var temp = _gridReader.ReadSingleOrDefault();
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public object ReadSingleOrDefault(Type type)
        {
            var temp = _gridReader.ReadSingleOrDefault(type);
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public T ReadSingleOrDefault<T>()
        {
            var temp = _gridReader.ReadSingleOrDefault<T>();
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public async Task<object> ReadSingleOrDefaultAsync(Type type)
        {
            var temp = await _gridReader.ReadSingleOrDefaultAsync(type);
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public async Task<dynamic> ReadSingleOrDefaultAsync()
        {
            var temp = await _gridReader.ReadSingleOrDefaultAsync();
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }

        public async Task<T> ReadSingleOrDefaultAsync<T>()
        {
            var temp = await _gridReader.ReadSingleOrDefaultAsync<T>();
            CloseConnectionThenIsConsumedIsTrue();
            return temp;
        }
    }
}
