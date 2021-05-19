using System;
using System.Collections.Generic;
using System.Linq;
using Utilities;
using Xunit;

namespace PrimitiveTypeTests
{
    /// <summary>
    /// ö�ٲ���.
    /// </summary>
    public class EnumTest
    {
        public enum Severity
        {
            Warning = 1,
            Error = 2,
            Fatal = 3
        }

        public enum Gender
        {
            [Literal("01")]
            Male,
            [Literal("02")]
            Female,
            [Literal("03")]
            Unknown
        }

        /// <summary>
        /// ��������.
        /// </summary>
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

        /// <summary>
        /// ����Ĭ��ֵ.
        /// </summary>
        [Fact]
        public void TestDefaultValue()
        {
            var severity = default(Severity);
            Assert.Equal((Severity)0, severity);

            var gender = default(Gender);
            Assert.Equal(Gender.Male, gender);
        }

        /// <summary>
        /// ����enumתcode
        /// </summary>
        [Fact]
        public void TestEnumeration2Code()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Gender? gender = null;
                EnumerationUtility.Enumeration2Code(gender.Value);
            });

            Gender gender = Gender.Male;
            Assert.Equal("01", EnumerationUtility.Enumeration2Code(gender));
        }
    }
}