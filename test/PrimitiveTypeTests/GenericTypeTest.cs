using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PrimitiveTypeTests
{
    /// <summary>
    /// 进制转换器测试.
    /// </summary>
    public class GenericTypeTest
    {
        [Fact]
        public void TestPrimitive()
        {
            Assert.True(typeof(short).IsPrimitive);
            Assert.True(typeof(ushort).IsPrimitive);
            Assert.True(typeof(int).IsPrimitive);
            Assert.True(typeof(uint).IsPrimitive);
            Assert.True(typeof(long).IsPrimitive);
            Assert.True(typeof(ulong).IsPrimitive);

            Assert.True(typeof(float).IsPrimitive);
            Assert.True(typeof(double).IsPrimitive);

            Assert.True(typeof(byte).IsPrimitive);
            Assert.True(typeof(char).IsPrimitive);

            Assert.False(typeof(TestEnum).IsPrimitive);
            Assert.False(typeof(string).IsPrimitive);
            Assert.False(typeof(decimal).IsPrimitive);
            Assert.False(typeof(DateTime).IsPrimitive);
        }

        [Fact]
        public void TestValueType()
        {
            Assert.True(typeof(short).IsValueType);
            Assert.True(typeof(ushort).IsValueType);
            Assert.True(typeof(int).IsValueType);
            Assert.True(typeof(uint).IsValueType);
            Assert.True(typeof(long).IsValueType);
            Assert.True(typeof(ulong).IsValueType);

            Assert.True(typeof(float).IsValueType);
            Assert.True(typeof(double).IsValueType);
            Assert.True(typeof(decimal).IsValueType);

            Assert.True(typeof(byte).IsValueType);
            Assert.True(typeof(char).IsValueType);

            Assert.True(typeof(TestEnum).IsValueType);

            Assert.True(typeof(DateTime).IsValueType);


            Assert.False(typeof(string).IsValueType);
        }

        public enum TestEnum
        {
        }
    }
}
