# Dapper.Client
基于Daaper的简单ADO.NET访问数据的客户端。

## 使用方式
````csharp
    // 使用工厂方法拿到 dbclient，可直接实现一个单例使用。
    var dbClient1 = DbClientFactory.CreateDbClient(DbClientType.SqlServer, "connectionString", null, null);

    // 或者 直接手动实例化 拿到 dbclient，可直接实现一个单例使用。
    IDbClient dbClient2 = new SqlClient("connectionString")
        {
            DefaultReadTimeout = null,
            DefaultWriteTimeout = null
        }

    /*
    拿到client之后，client提供了对Dapper接口的封装，
    方法签名基本一致，只有两个地方有区别
    1. 方法签名中的 IDbTransaction 参数被移除了，使用封装的ITransactionKeeper进行操作, 稍后介绍。
    2. 方法签名中的 commandTimeout 参数如果为null时，根据操作的性质（写入|读取）使用client的默认超时时间。
    3. 因为1、2点 所以方法签名中的CommandDefinition 变更为 SlimCommandDefinition。
    */ 
    _dbClient1.Query<string>("sql");

    /*
    事务的使用方式：
    通过client.CreateTransaction()方法获取到ITransactionKeeper，
    其中ITransactionKeeper：IDbClient 所以也提供一样的方法可直接调用。
    注意点：
        1. using 之前如果没有 Commit|Rollback，将自动Rollback
        2. 当tran 再次调用CreateTransaction 时，还是返回原来的 tran，
        但是嵌套层级+1，只能由最外层（嵌套层级为0的）的tran来Commit|Rollback
        3. 基于第二点，建议使用函数式的变成方式来编写事务相关的方法，
        根据方法的业务传入ITransactionKeeper|IDbclient的参数。
    */
    using (var tran = _dbClientl.CreateTransaction())
    {
        tran.Query<int?>("sql");

        tran.Commit();
    }
````