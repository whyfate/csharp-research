using EntityFrameworkCoreDemo.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.Transactions
{
    public static class SaveChangesOverrideTest
    {
        public static async Task Test()
        {
            using (var context = new DemoDbContext())
            {
                var trans = await context.Database.BeginTransactionAsync();

                context.Orders.Add(new Order
                {
                    Id = Guid.NewGuid().ToString(),
                    OrderDate = DateTime.Now,
                    OrderNo = "1",
                    Items = new List<OrderItem>
                        {
                            new OrderItem
                            {
                                Price = 1,
                                ProduceId = "1",
                                ProduceName = ".NET"
                            }
                        }
                });

                await context.SaveChangesAsync();

                context.Orders.Add(new Order
                {
                    Id = Guid.NewGuid().ToString(),
                    OrderDate = DateTime.Now,
                    OrderNo = "1",
                    Items = new List<OrderItem>
                        {
                            new OrderItem
                            {
                                Price = 1,
                                ProduceId = "1",
                                ProduceName = ".NET"
                            }
                        }
                });

                await context.SaveChangesAsync();

                await trans.CommitAsync();
            }
        }
    }
}
