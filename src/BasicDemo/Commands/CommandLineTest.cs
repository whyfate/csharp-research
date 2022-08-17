using BasicDemo.Enums;
using BasicDemo.KeyWords;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BasicDemo.Commands;

internal class CommandLineTest
{
    private static RootCommand root;
    private static List<string> commandKeys = new List<string>();

    internal static void Initial()
    {
        if (root != null)
        {
            return;
        }

        root = new RootCommand("command line");

        var types = Assembly.GetExecutingAssembly().DefinedTypes.OrderBy(t => t.Name);
        foreach (var typeInfo in types)
        {
            var methods = typeInfo.GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public).ToList();
            foreach (var method in methods)
            {
                var command = method.GetCustomAttribute<CommandAttribute>();
                if (command != null)
                {
                    var key = string.IsNullOrWhiteSpace(command.Key) ? $"{typeInfo.Name}.{method.Name}" : command.Key;
                    if (!commandKeys.Contains(key))
                    {
                        commandKeys.Add(key);
                    }
                    else
                    {
                        throw new Exception($"command name [{key}] conflict");
                    }

                    var description = string.IsNullOrWhiteSpace(command.Description) ? $"exec {typeInfo.Name}.{method.Name}()." : command.Description;

                    var cmd = new Command(key, description);
                    cmd.SetHandler(() =>
                    {
                        var obj = method.Invoke(null, null);
                        if (obj != null && obj is Task)
                        {
                            ((Task)obj).ConfigureAwait(false).GetAwaiter().GetResult();
                        }
                    });

                    root.Add(cmd);
                }
            }
        }
    }

    internal static async Task InvokeAsync(string commandLine)
    {
        if (root == null)
        {
            Initial();
        }

        await root.InvokeAsync(commandLine);
    }
}
