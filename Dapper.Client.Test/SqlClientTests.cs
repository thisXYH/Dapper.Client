using NUnit.Framework;

namespace Dapper.Client.Test
{
    public class SqlClientTests
    {
        /// <summary>
        /// sql客户端。
        /// </summary>
        private IDbClient _dbClientl;

        [SetUp]
        public void Setup()
        {
            // 获取一个sql客户端。
            _dbClientl = DbClientFactory.CreateDbClient(DbClientType.SqlServer, "", null, null);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}