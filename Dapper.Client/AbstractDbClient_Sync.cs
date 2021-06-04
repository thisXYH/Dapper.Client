using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Dapper.Client
{
    public abstract partial class AbstractDbClient
    {
        ///<inheritdoc/> 
        public int Execute(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Execute(sql, param, Transaction, commandTimeout ?? DefaultWriteTimeout, commandType);
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        ///<inheritdoc/> 
        public object Scalar(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        ///<inheritdoc/> 
        public T Scalar<T>(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar<T>(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        ///<inheritdoc/> 
        public IEnumerable<object> List(
            Type type, string sql, object param = null, bool buffered = true,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query(type, sql, param, Transaction, buffered, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        ///<inheritdoc/> 
        public IEnumerable<T> List<T>(
            string sql, object param = null, bool buffered = true,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<T>(sql, param, Transaction, buffered, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        ///<inheritdoc/> 
        public T Get<T>(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault<T>(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        ///<inheritdoc/> 
        public dynamic Get(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        ///<inheritdoc/>
        public IEnumerable<IDataRecord> Records(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            DbDataReader reader = null;
            try
            {
                connection = CreateAndOpenConnection();
                reader = (DbDataReader)connection.ExecuteReader(
                    sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
                return YieldRows(connection, reader);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                if (connection != null)
                    CloseConnection(connection);
            }
        }

        ///<inheritdoc/> 
        public object Get(Type type, string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault(type, sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        ///<inheritdoc/> 
        public GridReaderWapper QueryMultiple(
            string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return new GridReaderWapper(
                    connection.QueryMultiple(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType),
                    connection, Transaction != null);
            }
            catch (Exception)
            {
                if (connection != null)
                    CloseConnection(connection);

                throw;
            }
        }

    }
}