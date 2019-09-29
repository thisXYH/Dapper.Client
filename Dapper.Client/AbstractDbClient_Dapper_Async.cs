using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace Dapper.Client
{
    public abstract partial class AbstractDbClient
    {
        public async Task<int> ExecuteAsync(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteAsync(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }


        public async Task<IDataReader> ExecuteReaderAsync(CommandDefinition command, CommandBehavior commandBehavior)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteReaderAsync(command, commandBehavior);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }
        public async Task<IDataReader> ExecuteReaderAsync(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteReaderAsync(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }
        public async Task<IDataReader> ExecuteReaderAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteReaderAsync(sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<object> ExecuteScalarAsync(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteScalarAsync(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteScalarAsync<T>(sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<object> ExecuteScalarAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteScalarAsync(sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteScalarAsync<T>(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(CommandDefinition command, Func<TFirst, TSecond, TReturn> map, string splitOn = "Id")
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TReturn>(command, map, splitOn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<IEnumerable<dynamic>> QueryAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync(sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<IEnumerable<dynamic>> QueryAsync(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(CommandDefinition command, Func<TFirst, TSecond, TThird, TReturn> map, string splitOn = "Id")
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TReturn>(command, map, splitOn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(CommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, string splitOn = "Id")
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(command, map, splitOn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<IEnumerable<object>> QueryAsync(Type type, CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync(type, command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(CommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, string splitOn = "Id")
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(command, map, splitOn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(CommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, string splitOn = "Id")
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(command, map, splitOn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<TReturn>(string sql, Type[] types, Func<object[], TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TReturn>(sql, types, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<IEnumerable<object>> QueryAsync(Type type, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync(type, sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(CommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, string splitOn = "Id")
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(command, map, splitOn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<T>(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<dynamic> QueryFirstAsync(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstAsync(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<T> QueryFirstAsync<T>(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstAsync<T>(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<dynamic> QueryFirstAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstAsync(sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<object> QueryFirstAsync(Type type, CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstAsync(type, command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<T> QueryFirstAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstAsync<T>(sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<object> QueryFirstAsync(Type type, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstAsync(type, sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<dynamic> QueryFirstOrDefaultAsync(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstOrDefaultAsync(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<dynamic> QueryFirstOrDefaultAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstOrDefaultAsync(sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<object> QueryFirstOrDefaultAsync(Type type, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstOrDefaultAsync(type, sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstOrDefaultAsync<T>(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<object> QueryFirstOrDefaultAsync(Type type, CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstOrDefaultAsync(type, command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<SqlMapper.GridReader> QueryMultipleAsync(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryMultipleAsync(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryMultipleAsync(sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<dynamic> QuerySingleAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleAsync(sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<object> QuerySingleAsync(Type type, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleAsync(type, sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleAsync<T>(sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<object> QuerySingleAsync(Type type, CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleAsync(type, command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<T> QuerySingleAsync<T>(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleAsync<T>(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<dynamic> QuerySingleAsync(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleAsync(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<object> QuerySingleOrDefaultAsync(Type type, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleOrDefaultAsync(type, sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<object> QuerySingleOrDefaultAsync(Type type, CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleOrDefaultAsync(type, command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<dynamic> QuerySingleOrDefaultAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleOrDefaultAsync(sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<dynamic> QuerySingleOrDefaultAsync(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleOrDefaultAsync(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        public async Task<T> QuerySingleOrDefaultAsync<T>(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleOrDefaultAsync<T>(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }
    }
}