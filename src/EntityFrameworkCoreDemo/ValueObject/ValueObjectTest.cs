﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.ValueObject
{
    public class ValueObjectTest
    {
        public static void Test()
        {
            using var context = new DemoDbContext();
            context.Database.EnsureCreated();
            context.Orders.Add(new Order
            {
                Id = Guid.NewGuid().ToString(),
                OrderNo = Guid.NewGuid().ToString(),
                OrderDate = DateTime.Now,
                Address = new Address
                {
                    ZipCode = "001",
                    Province = "SC",
                    City = "CD",
                    County = "GX",
                    Street = "GD",
                    Detail = "haha"
                },
                Items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        ProduceId="1",
                        ProduceName="C#",
                        Price=100
                    }
                }
            });

            context.SaveChanges();

            Console.WriteLine(context.Orders.Where(o => o.Items.First(i => i.ProduceId == "1") != null).First().Address);
        }
    }
}
