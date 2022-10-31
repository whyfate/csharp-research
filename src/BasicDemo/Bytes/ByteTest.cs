using BasicDemo.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDemo.Bytes;

public static class ByteTest
{
    [Command]
    public static void TestReference()
    {
        var buffer = new byte[] { 1 };
        Modify(buffer);

        Console.WriteLine(buffer[0]);
    }

    private static void Modify(byte[] buffer)
    {
        buffer[0] = 2;
    }
}
