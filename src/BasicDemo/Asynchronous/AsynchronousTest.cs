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
    }
}
