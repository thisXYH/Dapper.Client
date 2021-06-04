using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace Dapper.Client
{
    public abstract partial class AbstractDbClient
    {
        ///<inheritdoc/> 
        public async Task<int> ExecuteAsync(
            string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteAsync(sql, param, Transaction, commandTimeout ?? DefaultWriteTimeout, commandType);
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        ///<inheritdoc/> 
        public async Task<T> ScalarAsync<T>(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteScalarAsync<T>(sql, param, Transaction, commandTimeout ?? DefaultWriteTimeout, commandType);
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        ///<inheritdoc/> 
        public async Task<object> ScalarAsync(
            string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteScalarAsync(sql, param, Transaction, commandTimeout ?? DefaultWriteTimeout, commandType);
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        ///<inheritdoc/> 
        public async Task<IEnumerable<T>> ListAsync<T>(
            string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<T>(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        ///<inheritdoc/> 
        public async Task<IEnumerable<object>> ListAsync(Type type, string sql, object param = null,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync(type, sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        ///<inheritdoc/> 
        public async Task<dynamic> GetAsync(
            string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstOrDefaultAsync(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        ///<inheritdoc/> 
        public async Task<T> GetAsync<T>(
            string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstOrDefaultAsync<T>(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        ///<inheritdoc/> 
        public async Task<object> GetAsync(
            Type type, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstOrDefaultAsync(type, sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<IDataRecord>> RecordsAsync(
            string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            DbDataReader reader = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                reader = await connection.ExecuteReaderAsync(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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
        public async Task<GridReaderWapper> QueryMultipleAsync(
            string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return new GridReaderWapper(
                    await connection.QueryMultipleAsync(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType),
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