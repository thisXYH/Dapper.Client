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
        /// ִ��ѡ�񵥸�ֵ�Ĳ�����sql��
        /// </summary>
        /// <typeparam name="T">����ֵ�����͡�</typeparam>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ص�һ����Ԫ��ֵ��</returns>
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

        /// <summary>
        /// ִ��ѡ�񵥸�ֵ�Ĳ�����sql��
        /// </summary>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ص�һ����Ԫ��ֵ��</returns>
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ���, ȡ������ĵ�һ�У����û��������ȡĬ��ֵ��
        /// </summary>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ض�̬�������ݣ�����ͨ�� *dynamic* �﷨���ʳ�Ա��Ҳ����ͨ��ת�� IDictionary[string,object]���ʡ�</returns>
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