using NUnit.Framework;

namespace Dapper.Client.Test
{
    public class SqlClientTests
    {
        /// <summary>
        /// 初始化连接对象。
        /// </summary>
        private IDbClient _dbClientl;

        [SetUp]
        public void Setup()
        {
            _dbClientl = DbClientFactory.CreateDbClient(DbClientType.SqlServer, "", null);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}