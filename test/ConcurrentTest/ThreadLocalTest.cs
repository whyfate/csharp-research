using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ConcurrentTest
{
    public class ThreadLocalTest
    {
        static ThreadLocal<int> threadLocal = new ThreadLocal<int>();

        [Fact]
        public void Test1()
        {
            Parallel.For(0, 10, i =>
            {
                threadLocal.Value = i;

                Thread.Sleep(50);

                Assert.Equal(i, threadLocal.Value);
            });
        }

        [Fact]
        public async Task Test2()
        {
            for (int i = 0; i < 10; i++)
            {
                var j = i;
                
                threadLocal.Value = j;

                await Task.Run(async() =>
                {
                    await Task.Yield();

                    // fail,Use AsyncLocal instead.
                    // Assert.Equal(j, threadLocal.Value);
                });
            }
        }
    }
}
