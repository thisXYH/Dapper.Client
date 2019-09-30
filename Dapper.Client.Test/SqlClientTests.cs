using NUnit.Framework;

namespace Dapper.Client.Test
{
    public class SqlClientTests
    {
        private static SqlDbClient _dbClient;

        /// <summary>
        /// 连接对象
        /// </summary>
        public static SqlDbClient DbClient
        {
            get
            {
                if (_dbClient != null) return _dbClient;
                // 设置测试连接串
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