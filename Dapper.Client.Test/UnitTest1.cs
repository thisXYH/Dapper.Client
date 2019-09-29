using NUnit.Framework;
using Microsoft.Data.SqlClient;
using Dapper;

namespace Dapper.Client.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            SqlConnection conn = new SqlConnection();
        }
    }
}