using BasicDemo.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDemo.Enums;

internal class EnumTest
{
    [Command("enum-test-unkown-value")]
    internal static void TestUnkownValue()
    {
        Gender gender = Gender.Unknow;
        if(Enum.TryParse("UnknowValue",out Gender result))
        {
            gender = result;
        }

        Console.WriteLine(gender);
    }

    [Command("enum-test-default-value")]
    internal static void TestDefaultValue()
    {
        var enumDefaultValue = new EnumDefaultValue();
        Console.WriteLine(enumDefaultValue.Gender);
    }

    public class EnumDefaultValue
    {
        public Gender Gender { get; set; }
    }
}
