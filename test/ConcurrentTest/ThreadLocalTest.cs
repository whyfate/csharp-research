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
    }
}
