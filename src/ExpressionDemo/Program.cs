using System;


namespace ExpressionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // ExpressionVisitorTest.Test();
            ExpressionTest.Test();

            var txt = Console.ReadLine();
            while (txt != "exit")
            {
                txt = Console.ReadLine();
            }
        }
    }
}
