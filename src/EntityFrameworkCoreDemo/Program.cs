using EntityFrameworkCoreDemo.Relational;
using System;
using System.Linq;


namespace EntityFrameworkCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 根据子表查询
            // RelationalTest.TestSubSearch();
            // 根据子表多条件查询
            RelationalTest.TestBothSubSearch();


            Console.ReadLine();
        }
    }
}
