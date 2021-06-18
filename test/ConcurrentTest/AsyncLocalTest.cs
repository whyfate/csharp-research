using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ConcurrentTest
{
    public class AsyncLocalTest
    {
        static AsyncLocal<int> asyncLocal = new AsyncLocal<int>();

        [Fact]
        public void Test1()
        {
            Parallel.For(0, 10, i =>
            {
                asyncLocal.Value = i;

                Thread.Sleep(50);

                Assert.Equal(i, asyncLocal.Value);
            });
        }

        [Fact]
        public void Test2()
        {
            for (int i = 0; i < 10; i++)
            {
                var j = i;
                Task.Run(() =>
                {
                    asyncLocal.Value = j;

                    Task.Delay(10);

                    Assert.Equal(j, asyncLocal.Value);
                });
            }
        }


        [Fact]
        public void TestScope()
        {
            Task.Run(async () =>
            {
                await Task.Run(() =>
                {
                    asyncLocal.Value = 10;
                });
                
                Assert.NotEqual(10, asyncLocal.Value);
            });
        }

        static int _i;

        [Fact]
        public void TestScope2()
        {
            Task.Run(async () =>
            {
                await Task.Run(() =>
                {
                    _i = 10;
                });

                Assert.Equal(10, _i);
            });
        }
    }
}
