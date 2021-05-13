using System;
using System.Linq;


namespace EntityFrameworkCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 根据子表查询
            // Relational.RelationalTest.TestSubSearch();
            // 根据子表多条件查询
            // Relational.RelationalTest.TestMultiSubSearch();
            // 根据子表多条件全等
            // Relational.RelationalTest.TestMultiSubSearchEqual();
            // 值对象配置测试
            ValueObject.ValueObjectTest.Test();

            Console.ReadLine();
        }
    }
}