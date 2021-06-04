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
            finally
            {
                if (connection != null)
                    CloseConnection(connection);
            }
        }

        ///<inheritdoc/>
        public IEnumerable<IDataRecord> ExecuteReader(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            DbDataReader reader = null;
            try
            {
                connection = CreateAndOpenConnection();
                reader = (DbDataReader)connection.ExecuteReader(
                        sql, param, Transaction, commandTimeout ?? DefaultWriteTimeout, commandType);
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
        /// ִ��ѡ�񵥸�ֵ�Ĳ�����sql��
        /// </summary>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ص�һ����Ԫ��ֵ��</returns>
        public object Scalar(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar(sql, param, Transaction, commandTimeout ?? DefaultWriteTimeout, commandType);
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
        public T Scalar<T>(string sql, object param = null, int? commandTimeout = null,
            CommandType? commandType = null)
        {
            DbConnection connection = null;
            try
            {
                connection = CreateAndOpenConnection();
                return connection.ExecuteScalar<T>(sql, param, Transaction, commandTimeout ?? DefaultWriteTimeout, commandType);
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

        /// <summary>
        /// ִ��һ����������Ĳ�ѯ���, ȡ������ĵ�һ�У����û��������ȡĬ��ֵ��
        /// </summary>
        /// <param name="sql">ִ����䡣</param>
        /// <param name="param">ִ�в�����</param>
        /// <param name="commandTimeout">��ʱʱ�䣨�룩��</param>
        /// <param name="commandType">�������͡�</param>
        /// <returns>���ض�̬�������ݣ�����ͨ�� *dynamic* �﷨���ʳ�Ա��Ҳ����ͨ��ת�� IDictionary[string,object]���ʡ�</returns>
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