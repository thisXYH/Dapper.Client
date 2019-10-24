using System;
using System.Data;

namespace Dapper.Client
{
    /// <summary>
    /// <see cref="IDataReader"/>的实现类，释放、关闭时也释放、关闭对应的链接对象。
    /// </summary>
    public sealed class DataReaderWrapper : IDataReader
    {
        /// <summary>
        /// 当前内部的DataReader对象。
        /// </summary>
        private readonly IDataReader _dataReader;

        /// <summary>
        /// 当前DataReader使用的连接对象。
        /// </summary>
        private IDbConnection _connection;

        /// <summary>
        /// Dispose 方法是否已经执行过。
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// 连接对象是否已经关闭, 默认值false。
        /// </summary>
        private bool _isConnectionClosed;

        /// <summary>
        /// 连接对象是否已经关闭, 默认值false。
        /// </summary>
        public bool IsConnectionClosed => _isConnectionClosed;

        internal DataReaderWrapper(IDataReader reader, IDbConnection connection)
        {
            ArgAssert.NotNull(reader, nameof(reader));
            ArgAssert.NotNull(connection, nameof(connection));

            _dataReader = reader;
            _connection = connection;
        }

        /// <summary>
        /// 关闭链接。 
        /// </summary>
        private void CloseConnection()
        {
            if (_isConnectionClosed || _connection == null || _connection.State == ConnectionState.Closed) return;

            _connection.Close();
            _connection = null;
            _isConnectionClosed = true;
        }

        /// <summary>
        /// 释放对象。
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
                return;

            _disposed = true;

            _dataReader.Dispose();
            CloseConnection();

            GC.SuppressFinalize(this);
        }

        ~DataReaderWrapper()
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
            // 这里只能先释放掉DataReader对象。
            try
            {
                _dataReader.Dispose();
            }
            catch
            {
                // 忽略异常，否则在GC线程内抛出异常会导致整个程序崩溃。
            }
        }

        public void Close()
        {
            _dataReader.Close();
            CloseConnection();
        }

        public string GetName(int i)
        {
            return _dataReader.GetName(i);
        }

        public string GetDataTypeName(int i)
        {
            return _dataReader.GetDataTypeName(i);
        }

        public Type GetFieldType(int i)
        {
            return _dataReader.GetFieldType(i);
        }

        public object GetValue(int i)
        {
            return _dataReader.GetValue(i);
        }

        public int GetValues(object[] values)
        {
            return _dataReader.GetValues(values);
        }

        public int GetOrdinal(string name)
        {
            return _dataReader.GetOrdinal(name);
        }

        public bool GetBoolean(int i)
        {
            return _dataReader.GetBoolean(i);
        }

        public byte GetByte(int i)
        {
            return _dataReader.GetByte(i);
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            return _dataReader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
        }

        public char GetChar(int i)
        {
            return _dataReader.GetChar(i);
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            return _dataReader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
        }

        public Guid GetGuid(int i)
        {
            return _dataReader.GetGuid(i);
        }

        public short GetInt16(int i)
        {
            return _dataReader.GetInt16(i);
        }

        public int GetInt32(int i)
        {
            return _dataReader.GetInt32(i);
        }

        public long GetInt64(int i)
        {
            return _dataReader.GetInt64(i);
        }

        public float GetFloat(int i)
        {
            return _dataReader.GetFloat(i);
        }

        public double GetDouble(int i)
        {
            return _dataReader.GetDouble(i);
        }

        public string GetString(int i)
        {
            return _dataReader.GetString(i);
        }

        public decimal GetDecimal(int i)
        {
            return _dataReader.GetDecimal(i);
        }

        public DateTime GetDateTime(int i)
        {
            return _dataReader.GetDateTime(i);
        }

        public IDataReader GetData(int i)
        {
            return _dataReader.GetData(i);
        }

        // ReSharper disable once InconsistentNaming
        public bool IsDBNull(int i)
        {
            return _dataReader.IsDBNull(i);
        }

        public int FieldCount => _dataReader.FieldCount;

        public object this[int i] => _dataReader[i];

        public object this[string name] => _dataReader[name];

        public DataTable GetSchemaTable()
        {
            return _dataReader.GetSchemaTable();
        }

        public bool NextResult()
        {
            return _dataReader.NextResult();
        }

        public bool Read()
        {
            return _dataReader.Read();
        }

        public int Depth => _dataReader.Depth;
        public bool IsClosed => _dataReader.IsClosed;
        public int RecordsAffected => _dataReader.RecordsAffected;
    }
}
