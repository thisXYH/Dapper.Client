using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace Dapper.Client
{
    public abstract partial class AbstractDbClient
    {
        public async Task<int> ExecuteAsync(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteAsync(ConvertSlimCommandDefinition(command));
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

        public async Task<int> ExecuteAsync(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteAsync(sql, param, Transaction, DefaultTimeout, commandType);
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


        public async Task<IDataReader> ExecuteReaderAsync(SlimCommandDefinition command, CommandBehavior commandBehavior)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteReaderAsync(ConvertSlimCommandDefinition(command), commandBehavior);
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
        public async Task<IDataReader> ExecuteReaderAsync(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteReaderAsync(ConvertSlimCommandDefinition(command));
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
        public async Task<IDataReader> ExecuteReaderAsync(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteReaderAsync(sql, param, Transaction, DefaultTimeout, commandType);
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

        public async Task<object> ExecuteScalarAsync(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteScalarAsync(ConvertSlimCommandDefinition(command));
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

        public async Task<T> ExecuteScalarAsync<T>(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteScalarAsync<T>(sql, param, Transaction, DefaultTimeout, commandType);
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

        public async Task<object> ExecuteScalarAsync(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteScalarAsync(sql, param, Transaction, DefaultTimeout, commandType);
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

        public async Task<T> ExecuteScalarAsync<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteScalarAsync<T>(ConvertSlimCommandDefinition(command));
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

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(SlimCommandDefinition command, Func<TFirst, TSecond, TReturn> map, string splitOn = "Id")
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TReturn>(ConvertSlimCommandDefinition(command), map, splitOn);
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

        public async Task<IEnumerable<dynamic>> QueryAsync(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync(sql, param, Transaction, DefaultTimeout, commandType);
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

        public async Task<IEnumerable<dynamic>> QueryAsync(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync(ConvertSlimCommandDefinition(command));
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

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(SlimCommandDefinition command, Func<TFirst, TSecond, TThird, TReturn> map, string splitOn = "Id")
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TReturn>(ConvertSlimCommandDefinition(command), map, splitOn);
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

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(SlimCommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, string splitOn = "Id")
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(ConvertSlimCommandDefinition(command), map, splitOn);
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

        public async Task<IEnumerable<object>> QueryAsync(Type type, SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync(type, ConvertSlimCommandDefinition(command));
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

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<T>(sql, param, Transaction, DefaultTimeout, commandType);
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

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(SlimCommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, string splitOn = "Id")
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(ConvertSlimCommandDefinition(command), map, splitOn);
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

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(SlimCommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, string splitOn = "Id")
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(ConvertSlimCommandDefinition(command), map, splitOn);
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

        public async Task<IEnumerable<object>> QueryAsync(Type type, string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync(type, sql, param, Transaction, DefaultTimeout, commandType);
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

        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(SlimCommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, string splitOn = "Id")
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(ConvertSlimCommandDefinition(command), map, splitOn);
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

        public async Task<IEnumerable<T>> QueryAsync<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<T>(ConvertSlimCommandDefinition(command));
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

        public async Task<dynamic> QueryFirstAsync(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstAsync(ConvertSlimCommandDefinition(command));
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

        public async Task<T> QueryFirstAsync<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstAsync<T>(ConvertSlimCommandDefinition(command));
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

        public async Task<dynamic> QueryFirstAsync(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstAsync(sql, param, Transaction, DefaultTimeout, commandType);
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

        public async Task<object> QueryFirstAsync(Type type, SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstAsync(type, ConvertSlimCommandDefinition(command));
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

        public async Task<T> QueryFirstAsync<T>(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstAsync<T>(sql, param, Transaction, DefaultTimeout, commandType);
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

        public async Task<object> QueryFirstAsync(Type type, string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstAsync(type, sql, param, Transaction, DefaultTimeout, commandType);
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

        public async Task<dynamic> QueryFirstOrDefaultAsync(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstOrDefaultAsync(ConvertSlimCommandDefinition(command));
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

        public async Task<dynamic> QueryFirstOrDefaultAsync(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstOrDefaultAsync(sql, param, Transaction, DefaultTimeout, commandType);
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

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstOrDefaultAsync<T>(sql, param, Transaction, DefaultTimeout, commandType);
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

        public async Task<object> QueryFirstOrDefaultAsync(Type type, string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstOrDefaultAsync(type, sql, param, Transaction, DefaultTimeout, commandType);
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

        public async Task<T> QueryFirstOrDefaultAsync<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstOrDefaultAsync<T>(ConvertSlimCommandDefinition(command));
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

        public async Task<object> QueryFirstOrDefaultAsync(Type type, SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstOrDefaultAsync(type, ConvertSlimCommandDefinition(command));
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

        public async Task<SqlMapper.GridReader> QueryMultipleAsync(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryMultipleAsync(ConvertSlimCommandDefinition(command));
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

        public async Task<SqlMapper.GridReader> QueryMultipleAsync(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryMultipleAsync(sql, param, Transaction, DefaultTimeout, commandType);
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

        public async Task<dynamic> QuerySingleAsync(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleAsync(sql, param, Transaction, DefaultTimeout, commandType);
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

        public async Task<object> QuerySingleAsync(Type type, string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleAsync(type, sql, param, Transaction, DefaultTimeout, commandType);
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

        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleAsync<T>(sql, param, Transaction, DefaultTimeout, commandType);
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

        public async Task<object> QuerySingleAsync(Type type, SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleAsync(type, ConvertSlimCommandDefinition(command));
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

        public async Task<T> QuerySingleAsync<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleAsync<T>(ConvertSlimCommandDefinition(command));
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

        public async Task<dynamic> QuerySingleAsync(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleAsync(ConvertSlimCommandDefinition(command));
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

        public async Task<object> QuerySingleOrDefaultAsync(Type type, string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleOrDefaultAsync(type, sql, param, Transaction, DefaultTimeout, commandType);
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

        public async Task<object> QuerySingleOrDefaultAsync(Type type, SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleOrDefaultAsync(type, ConvertSlimCommandDefinition(command));
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

        public async Task<dynamic> QuerySingleOrDefaultAsync(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleOrDefaultAsync(sql, param, Transaction, DefaultTimeout, commandType);
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

        public async Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleOrDefaultAsync<T>(sql, param, Transaction, DefaultTimeout, commandType);
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

        public async Task<dynamic> QuerySingleOrDefaultAsync(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleOrDefaultAsync(ConvertSlimCommandDefinition(command));
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

        public async Task<T> QuerySingleOrDefaultAsync<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleOrDefaultAsync<T>(ConvertSlimCommandDefinition(command));
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