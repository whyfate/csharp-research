using EntityFrameworkCoreDemo.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.Transactions
{
    public class TransactionTest
    {
        public static async Task TestSaveChanges()
        {
            // 添加一条数据
            using (var context = new DemoDbContext())
            {
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
            }
        }

        public static async Task TestSaveChangeAndTransaction()
        {
            using (var context = new DemoDbContext())
            {
                var trans = await context.Database.BeginTransactionAsync();

                try
                {
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
                                ProduceId = "2",
                                ProduceName = "Java"
                            }
                        }
                    });

                    await context.SaveChangesAsync();

                    await trans.CommitAsync();
                }
                catch
                {
                    await trans.RollbackAsync();
                }
            }
        }
    }
}
