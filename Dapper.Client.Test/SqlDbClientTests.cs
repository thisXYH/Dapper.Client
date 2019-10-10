using NUnit.Framework;

namespace Dapper.Client.Test
{
    public class SqlDbClientTests
    {
        /// <summary>
        /// sql客户端。
        /// </summary>
        private IDbClient _sqlDbClient;

        [SetUp]
        public void Setup()
        {
            // 获取一个sql客户端。
            _sqlDbClient = DbClientFactory.CreateDbClient(DbClientType.SqlServer, "Data Source=.;Initial Catalog=DapperClient_Db;User ID=sa;Password=123", null, null);
        }

        [Test]
        public void Test1()
        {
            const string sql =
                "INSERT Person(Name,Age,Birthday,Height,Weight,InsertTime) VALUES(@Name,@Age,@Birthday,@Height,@Weight,GETDATE())";
            _sqlDbClient.Execute(sql, new
            {
                Name = 1
            });
            Assert.Pass();
        }
    }
}