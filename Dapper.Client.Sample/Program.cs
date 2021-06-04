using System;

namespace Dapper.Client.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = Db.TestDb.Scalar<string>("select 'hello, world'");
            Console.WriteLine(str);

            // 事务使用
            using (var tran = Db.TestDb.CreateTransaction())
            {
                Console.WriteLine(tran.Scalar<string>("select 'use transaction'"));
                
                // 可以有事务，也可以无事务的方法
                TransactionPost(tran);

                // 一定要使用事务的方法
                TransactionPost2(tran);

                tran.Commit();

            } // 未提交，默认Rollback()

        }

        // 事务传递
        static void TransactionPost(IDbClient db)
        {
            Console.WriteLine(db.Get<string>("select 'IDbClient'"));
        }

        // 事务传递
        static void TransactionPost2(ITransactionKeeper tran)
        {
            Console.WriteLine(tran.Get<string>("select 'ITransactionKeeper'"));
        }

    }
}
