using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Dapper.Client
{
    /// <summary>
    /// <see cref="IDbClient"/>�Ļ���ʵ�֡�
    /// ����һ�������ࡣ
    /// </summary>
    public abstract partial class AbstractDbClient
    {
        /// <summary>
        /// ִ�в�����sql��
        /// </summary>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>������Ӱ��������</returns>
        public int Execute(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Execute(sql, param, Transaction, commandTimeout ?? DefaultWriteTimeout, commandType);
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

        /// <summary>
        /// ִ�в�����sql��
        /// </summary>
        /// <param name="command">����塣</param>
        /// <returns>������Ӱ��������</returns>
        public int Execute(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Execute(ConvertSlimCommandDefinitionWithWriteTimeout(command));
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

        /// <summary>
        /// ִ�в�����sql������<see cref="System.Data.IDataReader" />.
        /// <strong>�÷�����Ҫ�ֶ��ر����Ӷ���</strong>
        /// </summary>
        /// <param name="ccp">���Ӷ���رղ�����</param>
        /// <param name="command">����塣</param>
        /// <param name="commandBehavior">������Ϊ��</param>
        public IDataReader ExecuteReader(
            out ConnectionCloseOperate ccp, SlimCommandDefinition command, CommandBehavior commandBehavior)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                // ��¶һ���رղ������ⲿ��ͨ���ⲿ�رյ�ǰ���ӡ�
                ccp = new ConnectionCloseOperate(connection);
                return connection.ExecuteReader(ConvertSlimCommandDefinitionWithWriteTimeout(command), commandBehavior);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ִ�в�����sql������<see cref="System.Data.IDataReader" />.
        /// <strong>�÷�����Ҫ�ֶ��ر����Ӷ���</strong>
        /// </summary>
        /// <param name="ccp">���Ӷ���رղ�����</param>
        /// <param name="command">����塣</param>
        public IDataReader ExecuteReader(out ConnectionCloseOperate ccp, SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                // ��¶һ���رղ������ⲿ��ͨ���ⲿ�رյ�ǰ���ӡ�
                ccp = new ConnectionCloseOperate(connection);
                return connection.ExecuteReader(ConvertSlimCommandDefinitionWithWriteTimeout(command));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ִ�в�����sql������<see cref="System.Data.IDataReader" />.
        /// <strong>�÷�����Ҫ�ֶ��ر����Ӷ���</strong>
        /// </summary>
        /// <param name="ccp">���Ӷ���رղ�����</param>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        public IDataReader ExecuteReader(
            out ConnectionCloseOperate ccp,
            string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                // ��¶һ���رղ������ⲿ��ͨ���ⲿ�رյ�ǰ���ӡ�
                ccp = new ConnectionCloseOperate(connection);
                return connection.ExecuteReader(sql, param, Transaction, commandTimeout ?? DefaultWriteTimeout, commandType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ִ��ѡ�񵥸�ֵ�Ĳ�����sql��
        /// </summary>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ص�һ����Ԫ��ֵ��</returns>
        public object ExecuteScalar(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar(sql, param, Transaction, commandTimeout ?? DefaultWriteTimeout, commandType);
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

        /// <summary>
        /// ִ��ѡ�񵥸�ֵ�Ĳ�����sql��
        /// </summary>
        /// <typeparam name="T">����ֵ�����͡�</typeparam>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ص�һ����Ԫ��ֵ��</returns>
        public T ExecuteScalar<T>(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar<T>(sql, param, Transaction, commandTimeout ?? DefaultWriteTimeout, commandType);
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

        /// <summary>
        /// ִ��ѡ�񵥸�ֵ�Ĳ�����sql��
        /// </summary>
        /// <typeparam name="T">����ֵ�����͡�</typeparam>
        /// <param name="command">����塣</param>
        /// <returns>���ص�һ����Ԫ��ֵ��</returns>
        public T ExecuteScalar<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar<T>(ConvertSlimCommandDefinitionWithWriteTimeout(command));
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

        /// <summary>
        /// ִ��ѡ�񵥸�ֵ�Ĳ�����sql��
        /// </summary>
        /// <param name="command">����塣</param>
        /// <returns>���ص�һ����Ԫ��ֵ��</returns>
        public object ExecuteScalar(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar(ConvertSlimCommandDefinitionWithWriteTimeout(command));
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ��䣬����ָ�����ͼ��ϡ�
        /// </summary>
        /// <param name="type">����ֵ�����͡�</param>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="buffered">�Ƿ񽫽�����浽�ڴ��С�</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>
        /// ����ָ������<param name="type"/>�ļ������ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<param name="type"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ�е�������Ϊ���ء�
        /// </returns>
        public IEnumerable<object> Query(
            Type type, string sql, object param = null, bool buffered = true,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query(type, sql, param, Transaction, buffered, commandTimeout ?? DefaultReadTimeout, commandType);
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ��䣬����ָ�����ͼ��ϡ�
        /// </summary>
        /// <typeparam name="T">����ֵ�����͡�</typeparam>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="buffered">�Ƿ񽫽�����浽�ڴ��С�</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>
        /// ����ָ������<typeparam name="T"/>�ļ������ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<ptypeparamaram name="T"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ�е�������Ϊ���ء�
        /// </returns>
        public IEnumerable<T> Query<T>(
            string sql, object param = null, bool buffered = true,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<T>(sql, param, Transaction, buffered, commandTimeout ?? DefaultReadTimeout, commandType);
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ��䣬��ָ����ӳ�������û��ɷ������͡�
        /// </summary>
        /// <typeparam name="TReturn">����ֵ�����͡�</typeparam>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="types">ӳ�����͡�</param>
        /// <param name="map">��ӳ�������û��ɷ������͵�ί�С�</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="buffered">�Ƿ񽫽�����浽�ڴ��С�</param>
        /// <param name="splitOn">ӳ������֮��ķָ��ֶΣ�ȱʡֵId��</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ؾ�<param name="map"/>�����<typeparam name="TReturn"/></returns>
        public IEnumerable<TReturn> Query<TReturn>(
            string sql, Type[] types, Func<object[], TReturn> map,
            object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<TReturn>(sql, types, map, param, Transaction, buffered, splitOn, commandTimeout ?? DefaultReadTimeout, commandType);
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ��䣬��ָ����ӳ�������û��ɷ������͡�
        /// </summary>
        /// <typeparam name="TFirst">ӳ������1��</typeparam>
        /// <typeparam name="TSecond">ӳ������2��</typeparam>
        /// <typeparam name="TThird">ӳ������3��</typeparam>
        /// <typeparam name="TFourth">ӳ������4��</typeparam>
        /// <typeparam name="TFifth">ӳ������5��</typeparam>
        /// <typeparam name="TSixth">ӳ������6��</typeparam>
        /// <typeparam name="TSeventh">ӳ������7��</typeparam>
        /// <typeparam name="TReturn">����ֵ���͡�</typeparam>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="map">��ӳ�������û��ɷ������͵�ί�С�</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="buffered">�Ƿ񽫽�����浽�ڴ��С�</param>
        /// <param name="splitOn">ӳ������֮��ķָ��ֶΣ�ȱʡֵId��</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ؾ�<param name="map"/>�����<typeparam name="TReturn"/></returns>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
            string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map,
            object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
                    sql, map, param, Transaction, buffered, splitOn, commandTimeout ?? DefaultReadTimeout, commandType);
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ��䣬��ָ����ӳ�������û��ɷ������͡�
        /// </summary>
        /// <typeparam name="TFirst">ӳ������1��</typeparam>
        /// <typeparam name="TSecond">ӳ������2��</typeparam>
        /// <typeparam name="TThird">ӳ������3��</typeparam>
        /// <typeparam name="TFourth">ӳ������4��</typeparam>
        /// <typeparam name="TFifth">ӳ������5��</typeparam>
        /// <typeparam name="TSixth">ӳ������6��</typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="map">��ӳ�������û��ɷ������͵�ί�С�</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="buffered">�Ƿ񽫽�����浽�ڴ��С�</param>
        /// <param name="splitOn">ӳ������֮��ķָ��ֶΣ�ȱʡֵId��</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ؾ�<param name="map"/>�����<typeparam name="TReturn"/></returns>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
            string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object param = null,
            bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
                    sql, map, param, Transaction, buffered, splitOn, commandTimeout ?? DefaultReadTimeout, commandType);
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ��䣬��ָ����ӳ�������û��ɷ������͡�
        /// </summary>
        /// <typeparam name="TFirst">ӳ������1��</typeparam>
        /// <typeparam name="TSecond">ӳ������2��</typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="map">��ӳ�������û��ɷ������͵�ί�С�</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="buffered">�Ƿ񽫽�����浽�ڴ��С�</param>
        /// <param name="splitOn">ӳ������֮��ķָ��ֶΣ�ȱʡֵId��</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ؾ�<param name="map"/>�����<typeparam name="TReturn"/></returns>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map,
            object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<TFirst, TSecond, TReturn>(
                    sql, map, param, Transaction, buffered, splitOn, commandTimeout ?? DefaultReadTimeout, commandType);
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ��䣬��ָ����ӳ�������û��ɷ������͡�
        /// </summary>
        /// <typeparam name="TFirst">ӳ������1��</typeparam>
        /// <typeparam name="TSecond">ӳ������2��</typeparam>
        /// <typeparam name="TThird">ӳ������3��</typeparam>
        /// <typeparam name="TFourth">ӳ������4��</typeparam>
        /// <typeparam name="TFifth">ӳ������5��</typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="map">��ӳ�������û��ɷ������͵�ί�С�</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="buffered">�Ƿ񽫽�����浽�ڴ��С�</param>
        /// <param name="splitOn">ӳ������֮��ķָ��ֶΣ�ȱʡֵId��</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ؾ�<param name="map"/>�����<typeparam name="TReturn"/></returns>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
            string sql,
            Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null, bool buffered = true,
            string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
                    sql, map, param, Transaction, buffered, splitOn, commandTimeout ?? DefaultReadTimeout, commandType);
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ��䣬��ָ����ӳ�������û��ɷ������͡�
        /// </summary>
        /// <typeparam name="TFirst">ӳ������1��</typeparam>
        /// <typeparam name="TSecond">ӳ������2��</typeparam>
        /// <typeparam name="TThird">ӳ������3��</typeparam>
        /// <typeparam name="TFourth">ӳ������4��</typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="map">��ӳ�������û��ɷ������͵�ί�С�</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="buffered">�Ƿ񽫽�����浽�ڴ��С�</param>
        /// <param name="splitOn">ӳ������֮��ķָ��ֶΣ�ȱʡֵId��</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ؾ�<param name="map"/>�����<typeparam name="TReturn"/></returns>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(
            string sql,
            Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, bool buffered = true,
            string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<TFirst, TSecond, TThird, TFourth, TReturn>(
                    sql, map, param, Transaction, buffered, splitOn, commandTimeout ?? DefaultReadTimeout, commandType);
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ��䣬���ض�̬���ͼ��ϡ�
        /// </summary>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="buffered">�Ƿ񽫽�����浽�ڴ��С�</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ض�̬���ͼ��ϣ�ÿһ�п���ͨ�� *dynamic* �﷨���ʳ�Ա��Ҳ����ͨ��ת�� IDictionary[string,object]����</returns>
        public IEnumerable<dynamic> Query(string sql, object param = null, bool buffered = true,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query(sql, param, Transaction, buffered, commandTimeout ?? DefaultReadTimeout, commandType);
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ��䣬��ָ����ӳ�������û��ɷ������͡�
        /// </summary>
        /// <typeparam name="TFirst">ӳ������1��</typeparam>
        /// <typeparam name="TSecond">ӳ������2��</typeparam>
        /// <typeparam name="TThird">ӳ������3��</typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="map">��ӳ�������û��ɷ������͵�ί�С�</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="buffered">�Ƿ񽫽�����浽�ڴ��С�</param>
        /// <param name="splitOn">ӳ������֮��ķָ��ֶΣ�ȱʡֵId��</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ؾ�<param name="map"/>�����<typeparam name="TReturn"/></returns>
        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string sql,
            Func<TFirst, TSecond, TThird, TReturn> map, object param = null, bool buffered = true,
            string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<TFirst, TSecond, TThird, TReturn>(
                    sql, map, param, Transaction, buffered, splitOn, commandTimeout ?? DefaultReadTimeout, commandType);
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ��䣬����ָ�����ͼ��ϡ�
        /// </summary>
        /// <typeparam name="T">����ֵ�����͡�</typeparam>
        /// <param name="command">����塣</param>
        /// <returns>
        /// ����ָ������<typeparam name="T"/>�ļ������ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<ptypeparamaram name="T"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ�е�������Ϊ���ء�
        /// </returns>
        public IEnumerable<T> Query<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.Query<T>(ConvertSlimCommandDefinitionWithReadTimeout(command));
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ���, ȡ������ĵ�һ�У����û���������׳��쳣��
        /// </summary>
        /// <typeparam name="T">����ֵ�����͡�</typeparam>
        /// <param name="command">����塣</param>
        /// <returns>
        /// ����ָ������<typeparam name="T"/>���ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<ptypeparamaram name="T"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ����Ԫ���������Ϊ���ء�
        /// </returns>
        public T QueryFirst<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirst<T>(ConvertSlimCommandDefinitionWithReadTimeout(command));
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ���, ȡ������ĵ�һ�У����û���������׳��쳣��
        /// </summary>
        /// <param name="type">����ֵ�����͡�</param>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>
        /// ����ָ������<param name="type"/>�����ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<param name="type"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ����Ԫ���������Ϊ���ء�
        /// </returns>
        public object QueryFirst(Type type, string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirst(type, sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ���, ȡ������ĵ�һ�У����û���������׳��쳣��
        /// </summary>
        /// <typeparam name="T">����ֵ�����͡�</typeparam>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>
        /// ����ָ������<typeparam name="T"/>���ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<ptypeparamaram name="T"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ����Ԫ���������Ϊ���ء�
        /// </returns>
        public T QueryFirst<T>(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirst<T>(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ���, ȡ������ĵ�һ�У����û���������׳��쳣��
        /// </summary>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ض�̬�������ݣ�����ͨ�� *dynamic* �﷨���ʳ�Ա��Ҳ����ͨ��ת�� IDictionary[string,object]���ʡ�</returns>
        public dynamic QueryFirst(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirst(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ���, ȡ������ĵ�һ�У����û��������ȡĬ��ֵ��
        /// </summary>
        /// <typeparam name="T">����ֵ�����͡�</typeparam>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>
        /// ����ָ������<typeparam name="T"/>���ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<ptypeparamaram name="T"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ����Ԫ���������Ϊ���ء�
        /// </returns>
        public T QueryFirstOrDefault<T>(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault<T>(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ���, ȡ������ĵ�һ�У����û��������ȡĬ��ֵ��
        /// </summary>
        /// <typeparam name="T">����ֵ�����͡�</typeparam>
        /// <param name="command">����塣</param>
        /// <returns>
        /// ����ָ������<typeparam name="T"/>���ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<ptypeparamaram name="T"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ����Ԫ���������Ϊ���ء�
        /// </returns>
        public T QueryFirstOrDefault<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault<T>(ConvertSlimCommandDefinitionWithReadTimeout(command));
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ���, ȡ������ĵ�һ�У����û��������ȡĬ��ֵ��
        /// </summary>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ض�̬�������ݣ�����ͨ�� *dynamic* �﷨���ʳ�Ա��Ҳ����ͨ��ת�� IDictionary[string,object]���ʡ�</returns>
        public dynamic QueryFirstOrDefault(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ���, ȡ������ĵ�һ�У����û��������ȡĬ��ֵ��
        /// </summary>
        /// <param name="type">����ֵ�����͡�</param>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>
        /// ����ָ������<param name="type"/>�����ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<param name="type"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ����Ԫ���������Ϊ���ء�
        /// </returns>
        public object QueryFirstOrDefault(Type type, string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QueryFirstOrDefault(type, sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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

        /// <summary>
        ///  ִ��һ���������Ĳ�ѯ���, ��ͨ������ֵ����ÿ���������
        /// <strong>�÷�����Ҫ�ֶ��ر����Ӷ���</strong>
        /// </summary>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        public GridReaderWapper QueryMultiple(
            string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return new GridReaderWapper(
                    connection.QueryMultiple(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType), connection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ִ��һ���������Ĳ�ѯ���, ��ͨ������ֵ����ÿ���������
        /// <strong>�÷�����Ҫ�ֶ��ر����Ӷ���</strong>
        /// </summary>
        /// <param name="command">����塣</param>
        public GridReaderWapper QueryMultiple(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return new GridReaderWapper(connection.QueryMultiple(ConvertSlimCommandDefinitionWithReadTimeout(command)), connection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ���, ȡ������ĵ�һ�С�
        /// �쳣�����û����ж��
        /// </summary>
        /// <param name="type">����ֵ�����͡�</param>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>
        /// ����ָ������<param name="type"/>�����ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<param name="type"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ����Ԫ���������Ϊ���ء�
        /// </returns>
        public object QuerySingle(Type type, string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingle(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ���, ȡ������ĵ�һ�С�
        /// �쳣�����û����ж��
        /// </summary>
        /// <typeparam name="T">����ֵ�����͡�</typeparam>
        /// <param name="command">����塣</param>
        /// <returns>
        /// ����ָ������<typeparam name="T"/>�����ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<ptypeparamaram name="T"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ����Ԫ���������Ϊ���ء�
        /// </returns>
        public T QuerySingle<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingle<T>(ConvertSlimCommandDefinitionWithReadTimeout(command));
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ���, ȡ������ĵ�һ�С�
        /// �쳣�����û����ж��
        /// </summary>
        /// <typeparam name="T">����ֵ�����͡�</typeparam>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>
        /// ����ָ������<typeparam name="T"/>�����ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<ptypeparamaram name="T"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ����Ԫ���������Ϊ���ء�
        /// </returns>
        public T QuerySingle<T>(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingle<T>(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ���, ȡ������ĵ�һ�С�
        /// �쳣�����û����ж��
        /// </summary>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ض�̬���ͣ�����ͨ�� *dynamic* �﷨���ʳ�Ա��Ҳ����ͨ��ת�� IDictionary[string,object]���ʡ�</returns>
        public dynamic QuerySingle(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingle(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ���, ȡ������ĵ�һ��, û�����ȡĬ��ֵ��
        /// �쳣������ж��
        /// </summary>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ض�̬���ͣ�����ͨ�� *dynamic* �﷨���ʳ�Ա��Ҳ����ͨ��ת�� IDictionary[string,object]���ʡ�</returns>
        public dynamic QuerySingleOrDefault(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingleOrDefault(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ���, ȡ������ĵ�һ��, û�����ȡĬ��ֵ��
        /// �쳣������ж��
        /// </summary>
        /// <typeparam name="T">����ֵ�����͡�</typeparam>
        /// <param name="command">����塣</param>
        /// <returns>
        /// ����ָ������<typeparam name="T"/>�����ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<ptypeparamaram name="T"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ����Ԫ���������Ϊ���ء�
        /// </returns>
        public T QuerySingleOrDefault<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingleOrDefault<T>(ConvertSlimCommandDefinitionWithReadTimeout(command));
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ���, ȡ������ĵ�һ��, û�����ȡĬ��ֵ��
        /// �쳣������ж��
        /// </summary>
        /// <typeparam name="T">����ֵ�����͡�</typeparam>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>
        /// ����ָ������<typeparam name="T"/>�����ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<ptypeparamaram name="T"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ����Ԫ���������Ϊ���ء�
        /// </returns>
        public T QuerySingleOrDefault<T>(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingleOrDefault<T>(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ���, ȡ������ĵ�һ��, û�����ȡĬ��ֵ��
        /// �쳣������ж��
        /// </summary>
        /// <param name="type">����ֵ�����͡�</param>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>
        /// ����ָ������<param name="type"/>�����ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<param name="type"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ����Ԫ���������Ϊ���ء�
        /// </returns>
        public object QuerySingleOrDefault(Type type, string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.QuerySingleOrDefault(type, sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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