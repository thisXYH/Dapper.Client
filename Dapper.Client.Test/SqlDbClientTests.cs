using System;
using System.Data;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Dapper.Client.Test
{
    public class SqlDbClientTests
    {
        /// <summary>
        /// sql�ͻ��ˡ�
        /// </summary>
        private IDbClient _sqlDbClient;

        private const string ConnectionString =
            "Data Source=.;Initial Catalog=DapperClient_Db;User ID=sa;Password=123";

        [SetUp]
        public void Setup()
        {
            // ��ȡһ��sql�ͻ��ˡ�
            _sqlDbClient = DbClientFactory.CreateDbClient(DbClientType.SqlServer, ConnectionString, 5, 5);
        }

        [Test]
        public void TransactionRollback()
        {
            int id;
            using (var tran = _sqlDbClient.CreateTransaction())
            {
                id = AddPerson(tran);

                Assert.AreNotEqual(0, id);

                /*
                 * ��������������ύ�� �ع���
                 * ��������ύ������Ӱ�쵽���������
                 * ���ǻع�Ӧ��ҪӰ�쵽���������
                 * �����Ӱ�췽ʽͨ�����쳣�ķ�ʽ��ʵ�֣�ֱ��ʹ��Rollback��Ч��
                 */
                using (var tran2 = tran.CreateTransaction())
                {
                    tran2.Execute("update Person set Weight = @weight where id = @id", new { id, weight = 150 });
                    tran2.Commit(); //������ʵ��������ύ��
                }

                var person = tran.QueryFirstOrDefault<Person>("select * from person where id = @id", new { id });

                Assert.AreEqual(150, person.Weight);

                // ���ﲻ�ύ ֱ�ӻع�
            }

            var person2 = _sqlDbClient.QueryFirstOrDefault<Person>("select * from person where id = @id", new { id });

            Assert.IsNull(person2);
        }

        [Test]
        public void TransactionCommit()
        {
            int id;
            using (var tran = _sqlDbClient.CreateTransaction())
            {
                id = AddPerson(tran);

                Assert.AreNotEqual(0, id);

                /*
                * ��������������ύ�� �ع���
                * ��������ύ������Ӱ�쵽���������
                * ���ǻع�Ӧ��ҪӰ�쵽���������
                * �����Ӱ�췽ʽͨ�����쳣�ķ�ʽ��ʵ�֣�ֱ��ʹ��Rollback��Ч��
                */
                using (var tran2 = tran.CreateTransaction())
                {
                    tran2.Execute("update Person set Weight = @weight where id = @id", new { id, weight = 150 });
                    tran2.Commit(); //������ʵ��������ύ��
                }

                var person = tran.QueryFirstOrDefault<Person>("select * from person where id = @id", new { id });

                Assert.AreEqual(150, person.Weight);

                tran.Commit();//�ύ��
            }

            var person2 = _sqlDbClient.QueryFirstOrDefault<Person>("select * from person where id = @id", new { id });

            Assert.IsNotNull(person2);
            Assert.AreEqual(150, person2.Weight);
        }

        [Test]
        public async Task GridReaderWapper()
        {
            AddPerson(_sqlDbClient);

            // ����ȡ�����һ���������ʱ�� �������ӹرմ��롣
            var grid = _sqlDbClient.QueryMultiple(new SlimCommandDefinition("select * from person;select * from person;"));

            await grid.ReadAsync<Person>();
            grid.Read<Person>();

            Assert.IsTrue(grid.IsConnectionClosed);
            Assert.IsTrue(grid.IsConsumed);
        }

        [Test]
        public async Task GridReaderWapperUsing()
        {
            AddPerson(_sqlDbClient);

            // ��û�ж�ȡ�����һ���������ʱ��ͨ��Dispose �������ӹرմ��롣
            GridReaderWapper grid;
            using (grid = _sqlDbClient.QueryMultiple(new SlimCommandDefinition("select * from person;select * from person;")))
            {
                await grid.ReadAsync<Person>();

                // ����һ�������û����
            }

            // �������һ�������, ������������grid �ͷŶ��ͷš�
            Assert.IsFalse(grid.IsConsumed);
            Assert.IsTrue(grid.IsConnectionClosed);
        }

        [Test]
        public void DataReaderWapper()
        {
            AddPerson(_sqlDbClient);

            using var reader = _sqlDbClient.ExecuteReader("select * from person");

            reader.Close();

            //���� reader �ر� connection Ҳ�رա�
            Assert.IsTrue(reader.IsClosed);
            Assert.IsTrue(((DataReaderWrapper)reader).IsConnectionClosed);
        }

        [Test]
        public void DataReaderWapperUsing()
        {
            AddPerson(_sqlDbClient);

            IDataReader reader;
            using (reader = _sqlDbClient.ExecuteReader("select * from person"))
            {
                while (reader.Read())
                {
                    Assert.Greater(reader.GetInt32(0), 0);
                }
            }

            //���� reader �ͷ� connection Ҳ�ͷš�
            Assert.IsTrue(reader.IsClosed);
            Assert.IsTrue(((DataReaderWrapper)reader).IsConnectionClosed);
        }


        /// <summary>
        /// ����person ����ID��
        /// </summary>
        private static int AddPerson(IDbClient db)
        {
            const string sql =
                "INSERT Person(Name,Age,Birthday,Height,Weight,InsertTime) output inserted.Id VALUES (@Name,@Age,@Birthday,@Height,@Weight,GETDATE())";

            return db.ExecuteScalar<int>(sql, new
            {
                Name = "���°�",
                Age = 24,
                Birthday = (DateTime?)null,
                Height = 183.5,
                Weight = (float?)null
            });
        }
    }
}