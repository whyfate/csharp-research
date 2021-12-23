using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 数据库初始化
            await Initial();

            try
            {
                await ExecuteAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            // 保持程序
            Waiting();
        }

        static async Task ExecuteAsync()
        {
            // basic test
            // await Basic.BasicTest.TestUpdateAsync();
            // await Basic.BasicTest.TestUpdate2Async();
            // await Basic.BasicTest.TestUpdate3Async();

            // 根据子表查询
            // Relational.RelationalTest.TestSubSearch();

            // 根据子表多条件查询
            // Relational.RelationalTest.TestMultiSubSearch();

            // 根据子表多条件全等
            // Relational.RelationalTest.TestMultiSubSearchEqual();

            // 根据子表包含查询
            // Relational.RelationalTest.TestSubSearchContains();

            // 值对象配置测试
            // ValueObject.ValueObjectTest.Test();
            await ValueObject.ValueObjectTest.TestNullVOAsync();

            // 值转换测试
            // ValueConversions.ValueConversionTest.TestConversion();

            // 事务测试
            // await Transactions.TransactionTest.TestSaveChanges();

            // 事务测试 SaveChanges and Transaction
            //await Transactions.TransactionTest.TestSaveChangeAndTransaction();

            // SaveChanges:事务提交
            // await Interceptors.TransactionInterceptorTest.TestSaveChanges();

            // Transaction Commit 比 SaveChanges 多了个 CreatedSavepointAsync
            // await Interceptors.TransactionInterceptorTest.TestTransaction();

            // Tracking Test
            // await Tracking.TrackingTest.Test();

            // Tracking Performance
            // await Tracking.TrackingTest.Performance();

            // override SaveChanges
            // await Transactions.SaveChangesOverrideTest.Test();

            // lazy load
            // await LazyLoad.LazyLoadTest.TestAsync();
        }

        static void Waiting()
        {
            Console.WriteLine("任意键结束进程...");
            Console.ReadKey();
        }

        static async Task Initial()
        {
            using var context = new DemoDbContext();
            await context.Database.MigrateAsync();
            Console.WriteLine("数据库创建成功...");
        }
    }
}