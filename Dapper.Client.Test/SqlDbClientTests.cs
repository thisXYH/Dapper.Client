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
            _sqlDbClient = DbClientFactory.CreateDbClient(DbClientType.SqlServer, "", null, null);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}