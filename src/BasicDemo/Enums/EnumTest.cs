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
        if (Enum.TryParse("UnknowValue", out Gender result))
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

    [Command("enum-test-order")]
    internal static void TestOrder()
    {
        var list = new List<EnumOrderClass>();
        for (int i = 0; i < 10; i++)
        {
            var value = Random.Shared.Next(1, 100) % 4;
            Gender gender = (Gender)value;
            list.Add(new EnumOrderClass(gender, value, value.ToString()));
        }

        list.Add(new EnumOrderClass((Gender)4, 4, "4"));

        foreach (var item in list.OrderBy(l => l.Gender))
        {
            System.Console.WriteLine(item);
        }
    }

    internal class EnumDefaultValue
    {
        public Gender Gender { get; set; }
    }

    internal class EnumOrderClass
    {
        public EnumOrderClass(Gender gender, int order, string name)
        {
            Gender = gender;
            Order = order;
            Name = name;
        }

        public Gender Gender { get; set; }

        public int Order { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"Gender:{Gender},Order:{Order},Name:{Name}";
        }
    }
}
