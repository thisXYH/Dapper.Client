using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace Dapper.Client
{
    public abstract partial class AbstractDbClient
    {
        public int Execute(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Execute(sql, param, Transaction, DefaultTimeout, commandType);
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

        public int Execute(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Execute(ConvertSlimCommandDefinition(command, Transaction, DefaultTimeout));
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





        public IDataReader ExecuteReader(SlimCommandDefinition command, CommandBehavior commandBehavior)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteReader(ConvertSlimCommandDefinition(command, Transaction, DefaultTimeout), commandBehavior);
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

        public IDataReader ExecuteReader(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteReader(ConvertSlimCommandDefinition(command, Transaction, DefaultTimeout));
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

        public IDataReader ExecuteReader(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteReader(sql, param, Transaction, DefaultTimeout, commandType);
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







        public object ExecuteScalar(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar(sql, param, Transaction, DefaultTimeout, commandType);
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

        public T ExecuteScalar<T>(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar<T>(sql, param, Transaction, DefaultTimeout, commandType);
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

        public T ExecuteScalar<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar<T>(ConvertSlimCommandDefinition(command, Transaction, DefaultTimeout));
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

        public object ExecuteScalar(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar(ConvertSlimCommandDefinition(command, Transaction, DefaultTimeout));
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

        public IEnumerable<T> Query<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<T>(ConvertSlimCommandDefinition(command, Transaction, DefaultTimeout));
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



        public T QueryFirst<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirst<T>(ConvertSlimCommandDefinition(command, Transaction, DefaultTimeout));
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

        public object QueryFirst(Type type, string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirst(type, sql, param, Transaction, DefaultTimeout, commandType);
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

        public T QueryFirst<T>(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirst<T>(sql, param, Transaction, DefaultTimeout, commandType);
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

        public dynamic QueryFirst(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirst(sql, param, Transaction, DefaultTimeout, commandType);
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



        public T QueryFirstOrDefault<T>(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault<T>(sql, param, Transaction, DefaultTimeout, commandType);
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

        public T QueryFirstOrDefault<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault<T>(ConvertSlimCommandDefinition(command, Transaction, DefaultTimeout));
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

        public dynamic QueryFirstOrDefault(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault(sql, param, Transaction, DefaultTimeout, commandType);
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

        public object QueryFirstOrDefault(Type type, string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault(type, sql, param, Transaction, DefaultTimeout, commandType);
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



        public SqlMapper.GridReader QueryMultiple(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryMultiple(sql, param, Transaction, DefaultTimeout, commandType);
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

        public SqlMapper.GridReader QueryMultiple(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryMultiple(ConvertSlimCommandDefinition(command, Transaction, DefaultTimeout));
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



        public object QuerySingle(Type type, string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingle(sql, param, Transaction, DefaultTimeout, commandType);
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

        public T QuerySingle<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingle<T>(ConvertSlimCommandDefinition(command, Transaction, DefaultTimeout));
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

        public T QuerySingle<T>(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingle<T>(sql, param, Transaction, DefaultTimeout, commandType);
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

        public dynamic QuerySingle(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingle(sql, param, Transaction, DefaultTimeout, commandType);
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



        public dynamic QuerySingleOrDefault(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingleOrDefault(sql, param, Transaction, DefaultTimeout, commandType);
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

        public T QuerySingleOrDefault<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingleOrDefault<T>(ConvertSlimCommandDefinition(command, Transaction, DefaultTimeout));
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

        public T QuerySingleOrDefault<T>(string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingleOrDefault<T>(sql, param, Transaction, DefaultTimeout, commandType);
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

        public object QuerySingleOrDefault(Type type, string sql, object param = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingleOrDefault(type, sql, param, Transaction, DefaultTimeout, commandType);
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