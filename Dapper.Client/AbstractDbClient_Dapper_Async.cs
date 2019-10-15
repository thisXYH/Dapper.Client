using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace Dapper.Client
{
    public abstract partial class AbstractDbClient
    {
        /// <summary>
        /// ִ�в�����sql��
        /// </summary>
        /// <param name="command">����塣</param>
        /// <returns>������Ӱ��������</returns>
        public async Task<int> ExecuteAsync(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteAsync(ConvertSlimCommandDefinitionWithWriteTimeout(command));
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
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>������Ӱ��������</returns>
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

        /// <summary>
        /// ִ�в�����sql������<see cref="System.Data.IDataReader" />.
        /// </summary>
        /// <param name="command">����塣</param>
        /// <param name="commandBehavior">������Ϊ��</param>
        public async Task<IDataReader> ExecuteReaderAsync(SlimCommandDefinition command, CommandBehavior commandBehavior)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return new DataReaderWrapper(
                    await connection.ExecuteReaderAsync(ConvertSlimCommandDefinitionWithReadTimeout(command),
                        commandBehavior), connection);
            }
            catch (Exception)
            {
                if (connection != null)
                    CloseConnection(connection);

                throw;
            }
        }

        /// <summary>
        /// ִ�в�����sql������<see cref="System.Data.IDataReader" />.
        /// </summary>
        /// <param name="command">����塣</param>
        public async Task<IDataReader> ExecuteReaderAsync(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return new DataReaderWrapper(
                    await connection.ExecuteReaderAsync(ConvertSlimCommandDefinitionWithReadTimeout(command)), connection);
            }
            catch (Exception)
            {
                if (connection != null)
                    CloseConnection(connection);

                throw;
            }
        }

        /// <summary>
        /// ִ�в�����sql������<see cref="System.Data.IDataReader" />.
        /// </summary>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        public async Task<IDataReader> ExecuteReaderAsync(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return new DataReaderWrapper(
                    await connection.ExecuteReaderAsync(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout), connection);
            }
            catch (Exception)
            {
                if (connection != null)
                    CloseConnection(connection);

                throw;
            }
        }

        /// <summary>
        /// ִ��ѡ�񵥸�ֵ�Ĳ�����sql��
        /// </summary>
        /// <param name="command">����塣</param>
        /// <returns>���ص�һ����Ԫ��ֵ��</returns>
        public async Task<object> ExecuteScalarAsync(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteScalarAsync(ConvertSlimCommandDefinitionWithWriteTimeout(command));
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
        public async Task<T> ExecuteScalarAsync<T>(string sql, object param = null, int? commandTimeout = null,
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

        /// <summary>
        /// ִ��ѡ�񵥸�ֵ�Ĳ�����sql��
        /// </summary>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ص�һ����Ԫ��ֵ��</returns>
        public async Task<object> ExecuteScalarAsync(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
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

        /// <summary>
        /// ִ��ѡ�񵥸�ֵ�Ĳ�����sql��
        /// </summary>
        /// <typeparam name="T">����ֵ�����͡�</typeparam>
        /// <param name="command">����塣</param>
        /// <returns>���ص�һ����Ԫ��ֵ��</returns>
        public async Task<T> ExecuteScalarAsync<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.ExecuteScalarAsync<T>(ConvertSlimCommandDefinitionWithWriteTimeout(command));
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
        /// <typeparam name="TReturn">����ֵ���͡�</typeparam>
        /// <param name="command">����塣</param>
        /// <param name="map">��ӳ�������û��ɷ������͵�ί�С�</param>
        /// <param name="splitOn">ӳ������֮��ķָ��ֶΣ�ȱʡֵId��</param>
        /// <returns>���ؾ�<param name="map"/>�����<typeparam name="TReturn"/></returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(SlimCommandDefinition command, Func<TFirst, TSecond, TReturn> map, string splitOn = "Id")
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TReturn>(ConvertSlimCommandDefinitionWithReadTimeout(command), map, splitOn);
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
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql,
            Func<TFirst, TSecond, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id",
            int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TReturn>(
                    sql, map, param, Transaction, buffered, splitOn, commandTimeout ?? DefaultReadTimeout, commandType);
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
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ض�̬���ͼ��ϣ�ÿһ�п���ͨ�� *dynamic* �﷨���ʳ�Ա��Ҳ����ͨ��ת�� IDictionary[string,object]����</returns>
        public async Task<IEnumerable<dynamic>> QueryAsync(
            string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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
        /// <param name="command">����塣</param>
        /// <returns>���ض�̬���ͼ��ϣ�ÿһ�п���ͨ�� *dynamic* �﷨���ʳ�Ա��Ҳ����ͨ��ת�� IDictionary[string,object]����</returns>
        public async Task<IEnumerable<dynamic>> QueryAsync(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync(ConvertSlimCommandDefinitionWithReadTimeout(command));
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
        /// <typeparam name="TReturn">����ֵ���͡�</typeparam>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="map">��ӳ�������û��ɷ������͵�ί�С�</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="buffered">�Ƿ񽫽�����浽�ڴ��С�</param>
        /// <param name="splitOn">ӳ������֮��ķָ��ֶΣ�ȱʡֵId��</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ؾ�<param name="map"/>�����<typeparam name="TReturn"/></returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(
            string sql,
            Func<TFirst, TSecond, TThird, TReturn> map, object param = null, bool buffered = true,
            string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TReturn>(
                    sql, map, param, Transaction, buffered, splitOn, commandTimeout ?? DefaultReadTimeout, commandType);
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
        /// <typeparam name="TReturn">����ֵ���͡�</typeparam>
        /// <param name="command">����塣</param>
        /// <param name="map">��ӳ�������û��ɷ������͵�ί�С�</param>
        /// <param name="splitOn">ӳ������֮��ķָ��ֶΣ�ȱʡֵId��</param>
        /// <returns>���ؾ�<param name="map"/>�����<typeparam name="TReturn"/></returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(
            SlimCommandDefinition command, Func<TFirst, TSecond, TThird, TReturn> map, string splitOn = "Id")
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TReturn>(ConvertSlimCommandDefinitionWithReadTimeout(command), map, splitOn);
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
        /// <typeparam name="TReturn">����ֵ���͡�</typeparam>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="map">��ӳ�������û��ɷ������͵�ί�С�</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="buffered">�Ƿ񽫽�����浽�ڴ��С�</param>
        /// <param name="splitOn">ӳ������֮��ķָ��ֶΣ�ȱʡֵId��</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ؾ�<param name="map"/>�����<typeparam name="TReturn"/></returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string sql,
            Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, bool buffered = true,
            string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(
                    sql, map, param, Transaction, buffered, splitOn, commandTimeout ?? DefaultReadTimeout, commandType);
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
        /// <typeparam name="TReturn">����ֵ���͡�</typeparam>
        /// <param name="command">����塣</param>
        /// <param name="map">��ӳ�������û��ɷ������͵�ί�С�</param>
        /// <param name="splitOn">ӳ������֮��ķָ��ֶΣ�ȱʡֵId��</param>
        /// <returns>���ؾ�<param name="map"/>�����<typeparam name="TReturn"/></returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(SlimCommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, string splitOn = "Id")
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(ConvertSlimCommandDefinitionWithReadTimeout(command), map, splitOn);
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
        /// <param name="command">����塣</param>
        /// <returns>
        /// ����ָ������<param name="type"/>�ļ������ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<param name="type"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ�е�������Ϊ���ء�
        /// </returns>
        public async Task<IEnumerable<object>> QueryAsync(Type type, SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync(type, ConvertSlimCommandDefinitionWithReadTimeout(command));
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
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>
        /// ����ָ������<typeparam name="T"/>�ļ������ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<ptypeparamaram name="T"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ�е�������Ϊ���ء�
        /// </returns>
        public async Task<IEnumerable<T>> QueryAsync<T>(
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ��䣬��ָ����ӳ�������û��ɷ������͡�
        /// </summary>
        /// <typeparam name="TFirst">ӳ������1��</typeparam>
        /// <typeparam name="TSecond">ӳ������2��</typeparam>
        /// <typeparam name="TThird">ӳ������3��</typeparam>
        /// <typeparam name="TFourth">ӳ������4��</typeparam>
        /// <typeparam name="TFifth">ӳ������5��</typeparam>
        /// <typeparam name="TReturn">����ֵ���͡�</typeparam>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="map">��ӳ�������û��ɷ������͵�ί�С�</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="buffered">�Ƿ񽫽�����浽�ڴ��С�</param>
        /// <param name="splitOn">ӳ������֮��ķָ��ֶΣ�ȱʡֵId��</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ؾ�<param name="map"/>�����<typeparam name="TReturn"/></returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
            string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null,
            bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
                    sql, map, param, Transaction, buffered, splitOn, commandTimeout ?? DefaultReadTimeout, commandType);
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
        /// <typeparam name="TReturn">����ֵ���͡�</typeparam>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="map">��ӳ�������û��ɷ������͵�ί�С�</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="buffered">�Ƿ񽫽�����浽�ڴ��С�</param>
        /// <param name="splitOn">ӳ������֮��ķָ��ֶΣ�ȱʡֵId��</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ؾ�<param name="map"/>�����<typeparam name="TReturn"/></returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
            string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object param = null,
            bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
                    sql, map, param, Transaction, buffered, splitOn, commandTimeout ?? DefaultReadTimeout, commandType);
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
        /// <typeparam name="TReturn">����ֵ���͡�</typeparam>
        /// <param name="command">����塣</param>
        /// <param name="map">��ӳ�������û��ɷ������͵�ί�С�</param>
        /// <param name="splitOn">ӳ������֮��ķָ��ֶΣ�ȱʡֵId��</param>
        /// <returns>���ؾ�<param name="map"/>�����<typeparam name="TReturn"/></returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(SlimCommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, string splitOn = "Id")
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(
                    ConvertSlimCommandDefinitionWithReadTimeout(command), map, splitOn);
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
        public async Task<IEnumerable<TReturn>>
            QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(string sql,
                Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, object param = null,
                bool buffered = true, string splitOn = "Id", int? commandTimeout = null,
                CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
                    sql, map, param, Transaction, buffered, splitOn, commandTimeout ?? DefaultReadTimeout, commandType);
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
        /// <param name="command">����塣</param>
        /// <param name="map">��ӳ�������û��ɷ������͵�ί�С�</param>
        /// <param name="splitOn">ӳ������֮��ķָ��ֶΣ�ȱʡֵId��</param>
        /// <returns>���ؾ�<param name="map"/>�����<typeparam name="TReturn"/></returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
            SlimCommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, string splitOn = "Id")
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(
                    ConvertSlimCommandDefinitionWithReadTimeout(command), map, splitOn);
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
        public async Task<IEnumerable<TReturn>> QueryAsync<TReturn>(string sql, Type[] types,
            Func<object[], TReturn> map, object param = null, bool buffered = true, string splitOn = "Id",
            int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TReturn>(sql, types, map, param, Transaction, buffered, splitOn, commandTimeout ?? DefaultReadTimeout, commandType);
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
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>
        /// ����ָ������<param name="type"/>�ļ������ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<param name="type"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ�е�������Ϊ���ء�
        /// </returns>
        public async Task<IEnumerable<object>> QueryAsync(Type type, string sql, object param = null,
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ��䣬��ָ����ӳ�������û��ɷ������͡�
        /// </summary>
        /// <typeparam name="TFirst">ӳ������1��</typeparam>
        /// <typeparam name="TSecond">ӳ������2��</typeparam>
        /// <typeparam name="TThird">ӳ������3��</typeparam>
        /// <typeparam name="TFourth">ӳ������4��</typeparam>
        /// <typeparam name="TFifth">ӳ������5��</typeparam>
        /// <typeparam name="TReturn">����ֵ���͡�</typeparam>
        /// <param name="command">����塣</param>
        /// <param name="map">��ӳ�������û��ɷ������͵�ί�С�</param>
        /// <param name="splitOn">ӳ������֮��ķָ��ֶΣ�ȱʡֵId��</param>
        /// <returns>���ؾ�<param name="map"/>�����<typeparam name="TReturn"/></returns>
        public async Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
            SlimCommandDefinition command, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, string splitOn = "Id")
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(
                    ConvertSlimCommandDefinitionWithReadTimeout(command), map, splitOn);
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
        public async Task<IEnumerable<T>> QueryAsync<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryAsync<T>(ConvertSlimCommandDefinitionWithReadTimeout(command));
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
        /// <param name="command">ִ����䡣</param>
        /// <returns>���ض�̬�������ݣ�����ͨ�� *dynamic* �﷨���ʳ�Ա��Ҳ����ͨ��ת�� IDictionary[string,object]���ʡ�</returns>
        public async Task<dynamic> QueryFirstAsync(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstAsync(ConvertSlimCommandDefinitionWithReadTimeout(command));
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
        public async Task<T> QueryFirstAsync<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstAsync<T>(ConvertSlimCommandDefinitionWithReadTimeout(command));
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
        public async Task<dynamic> QueryFirstAsync(
            string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstAsync(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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
        /// <param name="command">����塣</param>
        /// <returns>
        /// ����ָ������<param name="type"/>�����ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<param name="type"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ����Ԫ���������Ϊ���ء�
        /// </returns>
        public async Task<object> QueryFirstAsync(Type type, SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstAsync(type, ConvertSlimCommandDefinitionWithReadTimeout(command));
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
        public async Task<T> QueryFirstAsync<T>(
            string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstAsync<T>(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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
        public async Task<object> QueryFirstAsync(
            Type type, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstAsync(type, sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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
        /// <param name="command">����塣</param>
        /// <returns>���ض�̬�������ݣ�����ͨ�� *dynamic* �﷨���ʳ�Ա��Ҳ����ͨ��ת�� IDictionary[string,object]���ʡ�</returns>
        public async Task<dynamic> QueryFirstOrDefaultAsync(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstOrDefaultAsync(ConvertSlimCommandDefinitionWithReadTimeout(command));
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
        public async Task<dynamic> QueryFirstOrDefaultAsync(
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
        public async Task<T> QueryFirstOrDefaultAsync<T>(
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
        public async Task<object> QueryFirstOrDefaultAsync(
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ���, ȡ������ĵ�һ�У����û��������ȡĬ��ֵ��
        /// </summary>
        /// <typeparam name="T">����ֵ�����͡�</typeparam>
        /// <param name="command">����塣</param>
        /// <returns>
        /// ����ָ������<typeparam name="T"/>���ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<ptypeparamaram name="T"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ����Ԫ���������Ϊ���ء�
        /// </returns>
        public async Task<T> QueryFirstOrDefaultAsync<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstOrDefaultAsync<T>(ConvertSlimCommandDefinitionWithReadTimeout(command));
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
        /// <param name="command">����塣</param>
        /// <returns>
        /// ����ָ������<param name="type"/>�����ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<param name="type"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ����Ԫ���������Ϊ���ء�
        /// </returns>
        public async Task<object> QueryFirstOrDefaultAsync(Type type, SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QueryFirstOrDefaultAsync(type, ConvertSlimCommandDefinitionWithReadTimeout(command));
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// ִ��һ���������Ĳ�ѯ���, ��ͨ������ֵ����ÿ���������
        /// </summary>
        /// <param name="command">����塣</param>
        public async Task<GridReaderWapper> QueryMultipleAsync(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return new GridReaderWapper(
                    await connection.QueryMultipleAsync(ConvertSlimCommandDefinitionWithReadTimeout(command)),
                    connection);
            }
            catch (Exception)
            {
                if (connection != null)
                    CloseConnection(connection);

                throw;
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
        public async Task<GridReaderWapper> QueryMultipleAsync(
            string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return new GridReaderWapper(await connection.QueryMultipleAsync(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType), connection);
            }
            catch (Exception)
            {
                if (connection != null)
                    CloseConnection(connection);

                throw;
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
        public async Task<dynamic> QuerySingleAsync(
            string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleAsync(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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
        /// <param name="type">����ֵ�����͡�</param>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>
        /// ����ָ������<param name="type"/>�����ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<param name="type"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ����Ԫ���������Ϊ���ء�
        /// </returns>
        public async Task<object> QuerySingleAsync(
            Type type, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleAsync(type, sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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
        public async Task<T> QuerySingleAsync<T>(
            string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleAsync<T>(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ���, ȡ������ĵ�һ�С�
        /// </summary>
        /// <param name="type">����ֵ�����͡�</param>
        /// <param name="command">�����</param>
        /// <returns>
        /// ����ָ������<param name="type"/>�����ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<param name="type"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ����Ԫ���������Ϊ���ء�
        /// </returns>
        public async Task<object> QuerySingleAsync(Type type, SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleAsync(type, ConvertSlimCommandDefinitionWithReadTimeout(command));
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
        public async Task<T> QuerySingleAsync<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleAsync<T>(ConvertSlimCommandDefinitionWithReadTimeout(command));
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
        /// <param name="command">����塣</param>
        /// <returns>���ض�̬���ͣ�����ͨ�� *dynamic* �﷨���ʳ�Ա��Ҳ����ͨ��ת�� IDictionary[string,object]���ʡ�</returns>
        public async Task<dynamic> QuerySingleAsync(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleAsync(ConvertSlimCommandDefinitionWithReadTimeout(command));
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
        public async Task<object> QuerySingleOrDefaultAsync(
            Type type, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleOrDefaultAsync(type, sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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
        /// <param name="command">����塣</param>
        /// <returns>
        /// ����ָ������<param name="type"/>�����ݣ�ӳ�䷽ʽ������->��Ա�������Դ�Сд����
        /// ���<param name="type"/>�ǻ������ͣ�int��string֮��ģ���ȡ��һ����Ԫ���������Ϊ���ء�
        /// </returns>
        public async Task<object> QuerySingleOrDefaultAsync(Type type, SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleOrDefaultAsync(type, ConvertSlimCommandDefinitionWithReadTimeout(command));
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
        public async Task<dynamic> QuerySingleOrDefaultAsync(
            string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleOrDefaultAsync(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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
        public async Task<T> QuerySingleOrDefaultAsync<T>(
            string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleOrDefaultAsync<T>(sql, param, Transaction, commandTimeout ?? DefaultReadTimeout, commandType);
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
        /// <param name="command">����塣</param>
        /// <returns>���ض�̬���ͣ�����ͨ�� *dynamic* �﷨���ʳ�Ա��Ҳ����ͨ��ת�� IDictionary[string,object]���ʡ�</returns>
        public async Task<dynamic> QuerySingleOrDefaultAsync(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleOrDefaultAsync(ConvertSlimCommandDefinitionWithReadTimeout(command));
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
        public async Task<T> QuerySingleOrDefaultAsync<T>(SlimCommandDefinition command)
        {
            DbConnection connection = null;
            try
            {
                connection = await CreateAndOpenConnectionAsync();
                return await connection.QuerySingleOrDefaultAsync<T>(ConvertSlimCommandDefinitionWithReadTimeout(command));
            }
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }
    }
}