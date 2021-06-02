using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace EntityFrameworkCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 数据库初始化
            Initial();

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

            // 值转换测试
            // ValueConversions.ValueConversionTest.TestConversion();

            // 事务测试
            // Transactions.TransactionTest.TestSaveChanges();

            // 保持程序
            Waiting();
        }

        static void Waiting()
        {
            Console.WriteLine("任意键结束进程...");
            Console.ReadKey();
        }

        static void Initial()
        {
            using var context = new DemoDbContext();
            context.Database.Migrate();
            Console.WriteLine("数据库创建成功...");
        }
    }
}