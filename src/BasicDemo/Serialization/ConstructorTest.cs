using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDemo.Serialization;

internal class ConstructorTest
{
    internal static void Test()
    {
        var entity = new Entity("张三");
        entity.Id = "1";

        var jsonString = System.Text.Json.JsonSerializer.Serialize(entity);

        var cloneEntity = System.Text.Json.JsonSerializer.Deserialize<Entity>(jsonString);
        Console.WriteLine(cloneEntity.ToString());
    }
}

public class Entity
{
    public Entity(string name)
    {
        this.Name = name;
    }

    public string Id { get; set; }

    public string Name { get; set; }

    public override string ToString()
    {
        return $"Id:{Id},Name:{Name}";
    }
}
