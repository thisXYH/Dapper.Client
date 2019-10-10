using NUnit.Framework;

namespace Dapper.Client.Test
{
    public class MySqlDbClientTests
    {
        /// <summary>
        /// MySql客户端。
        /// </summary>
        private IDbClient _mySqlDbClient;

        [SetUp]
        public void Setup()
        {
            // 获取一个MySql客户端。
            //_mySqlDbClient = DbClientFactory.CreateDbClient(DbClientType.MySql, "", null, null);
        }

        [Test]
        public void Test1()
        {
            //var id = _mySqlDbClient.QueryFirstOrDefault<int>("sql");
            //Assert.AreNotEqual(id, 0);
        }
    }
}
