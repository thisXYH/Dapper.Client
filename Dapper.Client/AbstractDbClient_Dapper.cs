using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace Dapper.Client
{
    public abstract partial class AbstractDbClient : IDbClient
    {
        public int Execute(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Execute(sql, param, transaction, commandTimeout, commandType);
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

        public int Execute(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Execute(command);
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





        public IDataReader ExecuteReader(CommandDefinition command, CommandBehavior commandBehavior)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteReader(command, commandBehavior);
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

        public IDataReader ExecuteReader(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteReader(command);
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

        public IDataReader ExecuteReader(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteReader(sql, param, transaction, commandTimeout, commandType);
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







        public object ExecuteScalar(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar(sql, param, transaction, commandTimeout, commandType);
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

        public T ExecuteScalar<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar<T>(sql, param, transaction, commandTimeout, commandType);
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

        public T ExecuteScalar<T>(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar<T>(command);
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

        public object ExecuteScalar(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar(command);
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



        public IEnumerable<object> Query(Type type, string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query(type, sql, param, transaction, buffered, commandTimeout, commandType);
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

        public IEnumerable<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
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

        public IEnumerable<TReturn> Query<TReturn>(string sql, Type[] types, Func<object[], TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<TReturn>(sql, types, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
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

        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
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

        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
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

        public IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<TFirst, TSecond, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
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

        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
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

        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<TFirst, TSecond, TThird, TFourth, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
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

        public IEnumerable<dynamic> Query(string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query(sql, param, transaction, buffered, commandTimeout, commandType);
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

        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<TFirst, TSecond, TThird, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
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

        public IEnumerable<T> Query<T>(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<T>(command);
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



        public T QueryFirst<T>(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirst<T>(command);
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

        public object QueryFirst(Type type, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirst(type, sql, param, transaction, commandTimeout, commandType);
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

        public T QueryFirst<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirst<T>(sql, param, transaction, commandTimeout, commandType);
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

        public dynamic QueryFirst(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirst(sql, param, transaction, commandTimeout, commandType);
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



        public T QueryFirstOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault<T>(sql, param, transaction, commandTimeout, commandType);
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

        public T QueryFirstOrDefault<T>(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault<T>(command);
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

        public dynamic QueryFirstOrDefault(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault(sql, param, transaction, commandTimeout, commandType);
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

        public object QueryFirstOrDefault(Type type, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault(type, sql, param, transaction, commandTimeout, commandType);
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



        public SqlMapper.GridReader QueryMultiple(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryMultiple(sql, param, transaction, commandTimeout, commandType);
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

        public SqlMapper.GridReader QueryMultiple(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryMultiple(command);
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



        public object QuerySingle(Type type, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingle(sql, param, transaction, commandTimeout, commandType);
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

        public T QuerySingle<T>(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingle<T>(command);
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

        public T QuerySingle<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingle<T>(sql, param, transaction, commandTimeout, commandType);
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

        public dynamic QuerySingle(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingle(sql, param, transaction, commandTimeout, commandType);
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



        public dynamic QuerySingleOrDefault(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingleOrDefault(sql, param, transaction, commandTimeout, commandType);
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

        public T QuerySingleOrDefault<T>(CommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingleOrDefault<T>(command);
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

        public T QuerySingleOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingleOrDefault<T>(sql, param, transaction, commandTimeout, commandType);
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

        public object QuerySingleOrDefault(Type type, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingleOrDefault(type, sql, param, transaction, commandTimeout, commandType);
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