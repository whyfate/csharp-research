using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PrimitiveTypeTests
{
    public class EnumTest
    {
        public enum Severity
        {
            Warning = 1,
            Error = 2,
            Fatal = 3
        }

        [Fact]
        public void TestSort()
        {
            var list = new List<Severity>
            {
                Severity.Warning,
                Severity.Warning,
                Severity.Warning,
                Severity.Error,
                Severity.Warning,
                Severity.Warning
            };

            Assert.Equal(Severity.Error, list.OrderByDescending(l => l).First());
        }
    }
}