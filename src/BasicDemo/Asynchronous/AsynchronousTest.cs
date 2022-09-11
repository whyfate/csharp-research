using BasicDemo.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDemo.Asynchronous
{
    internal class AsynchronousTest
    {
        [Command]
        public static void TestScope()
        {
            for (int i = 0; i < 30; i++)
            {
                Task.Run(async () =>
                {
                    await Task.Run(() =>
                    {
                        System.Threading.Thread.Sleep(500);
                        Console.WriteLine(i);
                    });
                }).ConfigureAwait(false).GetAwaiter().GetResult();
            }
        }

        [Command]
        public static void TestException()
        {
            Task.Run(() =>
            {

                try
                {
                    Parallel.For(0, 10, async i =>
                    {
                        await Task.Delay(1);

                        throw new Exception("test");
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }

        [Command]
        public static void TestException2()
        {
            Task.Run(async () =>
            {

                try
                {
                    var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                    await Parallel.ForEachAsync(list, async (i, cancellationToken) =>
                    {
                        await Task.Delay(1);

                        throw new Exception("ex");
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }
    }
}
