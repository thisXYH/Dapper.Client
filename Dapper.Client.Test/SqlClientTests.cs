using NUnit.Framework;

namespace Dapper.Client.Test
{
    public class SqlClientTests
    {
        /// <summary>
        /// ��ʼ�����Ӷ���
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