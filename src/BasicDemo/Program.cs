using BasicDemo.Commands;
using System;

CommandLineTest.Initial();
Console.WriteLine("please input your command:-?, -h, --help  Show help and usage information");
var txt =  Console.ReadLine();
while (txt!="exit")
{
    await CommandLineTest.InvokeAsync(txt);

    txt = Console.ReadLine();
}