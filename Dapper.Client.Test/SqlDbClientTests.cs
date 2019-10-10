using NUnit.Framework;

namespace Dapper.Client.Test
{
    public class SqlDbClientTests
    {
        /// <summary>
        /// sql�ͻ��ˡ�
        /// </summary>
        private IDbClient _sqlDbClient;

        [SetUp]
        public void Setup()
        {
            // ��ȡһ��sql�ͻ��ˡ�
            _sqlDbClient = DbClientFactory.CreateDbClient(DbClientType.SqlServer, "Data Source=.;Initial Catalog=DapperClient_Db;User ID=sa;Password=123", null, null);
        }

        [Test]
        public void Test1()
        {
            const string sql =
                "INSERT Person(Name,Age,Birthday,Height,Weight,InsertTime) VALUES(N'',0,GETDATE(),0.0,0.0,GETDATE())";
            _sqlDbClient.Execute("");
            Assert.Pass();
        }
    }
}