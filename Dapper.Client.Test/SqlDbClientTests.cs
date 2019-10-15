using System;
using System.Runtime.InteropServices;
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
            const string sql =
                "INSERT Person(Name,Age,Birthday,Height,Weight,InsertTime) output inserted.Id VALUES (@Name,@Age,@Birthday,@Height,@Weight,GETDATE())";
            int id = 0;
            using (var tran = _sqlDbClient.CreateTransaction())
            {
                id = tran.ExecuteScalar<int>(sql, new
                {
                    Name = "���°�",
                    Age = 24,
                    Birthday = (DateTime?)null,
                    Height = 183.5,
                    Weight = (float?)null
                });

                Assert.AreNotEqual(0, id);

                /*
                 * ��������������ύ�� �ع���
                 * ��������ύ������Ӱ�쵽���������
                 * ���ǻع�Ӧ��ҪӰ�쵽���������
                 * �����Ӱ�췽ʽͨ�����쳣�ķ�ʽ��ʵ�֣�ֱ��ʹ��Rollback��Ч��
                 */
                using (var tran2 = tran.CreateTransaction())
                {
                    tran2.Execute("update Person set Weight = @weight where id = @id", new { id = id, weight = 150 });
                    tran2.Commit(); //������ʵ��������ύ��
                }

                var person = tran.QueryFirstOrDefault<Person>("select * from person where id = @id", new { id = id });

                Assert.AreEqual(150, person.Weight);

                // ���ﲻ�ύ ֱ�ӻع�
            }

            var person2 = _sqlDbClient.QueryFirstOrDefault<Person>("select * from person where id = @id", new { id = id });

            Assert.IsNull(person2);
        }

        [Test]
        public void TransactionCommit()
        {
            const string sql =
                "INSERT Person(Name,Age,Birthday,Height,Weight,InsertTime) output inserted.Id VALUES (@Name,@Age,@Birthday,@Height,@Weight,GETDATE())";
            int id = 0;
            using (var tran = _sqlDbClient.CreateTransaction())
            {
                id = tran.ExecuteScalar<int>(sql, new
                {
                    Name = "���°�",
                    Age = 24,
                    Birthday = (DateTime?)null,
                    Height = 183.5,
                    Weight = (float?)null
                });

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
            const string sql =
                "INSERT Person(Name,Age,Birthday,Height,Weight,InsertTime) output inserted.Id VALUES (@Name,@Age,@Birthday,@Height,@Weight,GETDATE())";
            _sqlDbClient.ExecuteScalar<int>(sql, new
            {
                Name = "���°�",
                Age = 24,
                Birthday = (DateTime?)null,
                Height = 183.5,
                Weight = (float?)null
            });

            // ����ȡ�����һ���������ʱ�� �������ӹرմ��롣
            var grid = _sqlDbClient.QueryMultiple(new SlimCommandDefinition("select * from person;select * from person;"));

            var person1 = await grid.ReadAsync<Person>();
            var person2 = grid.Read<Person>();

            Assert.IsNull(grid.Connection);

            Assert.IsTrue(grid.IsConsumed);
        }

        [Test]
        public async Task GridReaderWapperUsing()
        {
            const string sql =
                "INSERT Person(Name,Age,Birthday,Height,Weight,InsertTime) output inserted.Id VALUES (@Name,@Age,@Birthday,@Height,@Weight,GETDATE())";
            _sqlDbClient.ExecuteScalar<int>(sql, new
            {
                Name = "���°�",
                Age = 24,
                Birthday = (DateTime?)null,
                Height = 183.5,
                Weight = (float?)null
            });

            // ��û�ж�ȡ�����һ���������ʱ��ͨ��Dispose �������ӹرմ��롣
            GridReaderWapper grid;
            using (grid = _sqlDbClient.QueryMultiple(new SlimCommandDefinition("select * from person;select * from person;")))
            {
                var person1 = await grid.ReadAsync<Person>();

                // ����һ�������û����
            }

            Assert.IsNull(grid.Connection);

            // �������һ���������
            Assert.IsFalse(grid.IsConsumed);
        }
    }
}