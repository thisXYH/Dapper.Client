using NUnit.Framework;

namespace Dapper.Client.Test
{
    public class SqlClientTests
    {
        /// <summary>
        /// sql�ͻ��ˡ�
        /// </summary>
        private IDbClient _dbClientl;

        [SetUp]
        public void Setup()
        {
            // ��ȡһ��sql�ͻ��ˡ�
            _dbClientl = DbClientFactory.CreateDbClient(DbClientType.SqlServer, "", null, null);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}