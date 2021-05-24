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
    public class HexConverterTest
    {
        [Fact]
        public void Binary2Hex()
        {
            var buffer = Encoding.UTF8.GetBytes("A");
            var hexString = buffer.Select(b => Convert.ToString(b, 16));
            Assert.Equal("41", hexString.First());
        }
    }
}
