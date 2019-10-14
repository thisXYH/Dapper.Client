using System;
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
            const string sql =
                "INSERT Person(Name,Age,Birthday,Height,Weight,InsertTime) output inserted.Id VALUES (@Name,@Age,@Birthday,@Height,@Weight,GETDATE())";
            int id = 0;
            using (var tran = _sqlDbClient.CreateTransaction())
            {
                id = tran.ExecuteScalar<int>(sql, new
                {
                    Name = "极致啊",
                    Age = 24,
                    Birthday = (DateTime?)null,
                    Height = 183.5,
                    Weight = (float?)null
                });

                Assert.AreNotEqual(0, id);

                /*
                 * 事务在最外层做提交、 回滚。
                 * 子事务的提交，不能影响到最外层事务，
                 * 但是回滚应该要影响到最外层事务，
                 * 这里的影响方式通过抛异常的方式来实现，直接使用Rollback无效。
                 */
                using (var tran2 = tran.CreateTransaction())
                {
                    tran2.Execute("update Person set Weight = @weight where id = @id", new { id = id, weight = 150 });
                    tran2.Commit(); //这里其实不是真的提交。
                }

                var person = tran.QueryFirstOrDefault<Person>("select * from person where id = @id", new { id = id });

                Assert.AreEqual(150, person.Weight);

                // 这里不提交 直接回滚
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
                    Name = "极致啊",
                    Age = 24,
                    Birthday = (DateTime?)null,
                    Height = 183.5,
                    Weight = (float?)null
                });

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
        public void GridReader()
        {
            const string sql =
                "INSERT Person(Name,Age,Birthday,Height,Weight,InsertTime) output inserted.Id VALUES (@Name,@Age,@Birthday,@Height,@Weight,GETDATE())";
            _sqlDbClient.ExecuteScalar<int>(sql, new
            {
                Name = "极致啊",
                Age = 24,
                Birthday = (DateTime?)null,
                Height = 183.5,
                Weight = (float?)null
            });

            //这里的连接关闭由外界控制。
            var grid = _sqlDbClient.QueryMultiple(new SlimCommandDefinition(
                "select * from person;select * from person;"),out var ccp);

            var person1 = grid.Read<Person>();
            var person2 = grid.Read<Person>();

            ccp.Done();

            Assert.IsTrue(grid.IsConsumed);
        }
    }
}