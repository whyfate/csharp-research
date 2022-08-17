using BasicDemo.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDemo.KeyWords
{
    internal class UsingDemo
    {
        [Command]
        internal static void TestScope()
        {
            using var test = new UsingTest();
            Console.WriteLine("---start---");
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("---for---");
            }

            var w = true;
            while (w)
            {
                Console.WriteLine("---while---");
                w = false;
            }
            Console.WriteLine("---end---");
        }

        [Command]
        internal static void TestScope2()
        {
            using (var test = new UsingTest())
            {
                Console.WriteLine("---start---");
            }
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("---for---");
            }

            var w = true;
            while (w)
            {
                Console.WriteLine("---while---");
                w = false;
            }
            Console.WriteLine("---end---");
        }

        class UsingTest : IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("---dispose---");
            }
        }
    }
}
