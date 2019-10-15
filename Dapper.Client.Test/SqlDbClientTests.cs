using System;
using System.Data;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Dapper.Client.Test
{
    public class SqlDbClientTests
    {
        /// <summary>
        /// sql客户端。
        /// </summary>
        private IDbClient _sqlDbClient;

        private const string ConnectionString =
            "Data Source=.;Initial Catalog=DapperClient_Db;User ID=sa;Password=123";

        [SetUp]
        public void Setup()
        {
            // 获取一个sql客户端。
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
                 * 事务在最外层做提交、 回滚。
                 * 子事务的提交，不能影响到最外层事务，
                 * 但是回滚应该要影响到最外层事务，
                 * 这里的影响方式通过抛异常的方式来实现，直接使用Rollback无效。
                 */
                using (var tran2 = tran.CreateTransaction())
                {
                    tran2.Execute("update Person set Weight = @weight where id = @id", new { id, weight = 150 });
                    tran2.Commit(); //这里其实不是真的提交。
                }

                var person = tran.QueryFirstOrDefault<Person>("select * from person where id = @id", new { id });

                Assert.AreEqual(150, person.Weight);

                // 这里不提交 直接回滚
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
                * 事务在最外层做提交、 回滚。
                * 子事务的提交，不能影响到最外层事务，
                * 但是回滚应该要影响到最外层事务，
                * 这里的影响方式通过抛异常的方式来实现，直接使用Rollback无效。
                */
                using (var tran2 = tran.CreateTransaction())
                {
                    tran2.Execute("update Person set Weight = @weight where id = @id", new { id, weight = 150 });
                    tran2.Commit(); //这里其实不是真的提交。
                }

                var person = tran.QueryFirstOrDefault<Person>("select * from person where id = @id", new { id });

                Assert.AreEqual(150, person.Weight);

                tran.Commit();//提交。
            }

            var person2 = _sqlDbClient.QueryFirstOrDefault<Person>("select * from person where id = @id", new { id });

            Assert.IsNotNull(person2);
            Assert.AreEqual(150, person2.Weight);
        }

        [Test]
        public async Task GridReaderWapper()
        {
            AddPerson(_sqlDbClient);

            // 当读取到最后一个结果集的时候 触发连接关闭代码。
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

            // 当没有读取到最后一个结果集的时候，通过Dispose 触发连接关闭代码。
            GridReaderWapper grid;
            using (grid = _sqlDbClient.QueryMultiple(new SlimCommandDefinition("select * from person;select * from person;")))
            {
                await grid.ReadAsync<Person>();

                // 还有一个结果集没读。
            }

            // 不是最后一个结果集, 但是连接随着grid 释放而释放。
            Assert.IsFalse(grid.IsConsumed);
            Assert.IsTrue(grid.IsConnectionClosed);
        }

        [Test]
        public void DataReaderWapper()
        {
            AddPerson(_sqlDbClient);

            using var reader = _sqlDbClient.ExecuteReader("select * from person");

            reader.Close();

            //随着 reader 关闭 connection 也关闭。
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

            //随着 reader 释放 connection 也释放。
            Assert.IsTrue(reader.IsClosed);
            Assert.IsTrue(((DataReaderWrapper)reader).IsConnectionClosed);
        }


        /// <summary>
        /// 新增person 返回ID。
        /// </summary>
        private static int AddPerson(IDbClient db)
        {
            const string sql =
                "INSERT Person(Name,Age,Birthday,Height,Weight,InsertTime) output inserted.Id VALUES (@Name,@Age,@Birthday,@Height,@Weight,GETDATE())";

            return db.ExecuteScalar<int>(sql, new
            {
                Name = "极致啊",
                Age = 24,
                Birthday = (DateTime?)null,
                Height = 183.5,
                Weight = (float?)null
            });
        }
    }
}