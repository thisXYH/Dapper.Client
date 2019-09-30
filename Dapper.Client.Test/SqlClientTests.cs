using NUnit.Framework;

namespace Dapper.Client.Test
{
    public class SqlClientTests
    {
        private static SqlDbClient _dbClient;

        /// <summary>
        /// ���Ӷ���
        /// </summary>
        public static SqlDbClient DbClient
        {
            get
            {
                if (_dbClient != null) return _dbClient;
                // ���ò������Ӵ�
                _dbClient = new SqlDbClient("") {DefaultTimeout = 5};
                return _dbClient;
            }
        }


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}