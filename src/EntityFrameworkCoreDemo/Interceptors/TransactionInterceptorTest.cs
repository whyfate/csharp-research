using EntityFrameworkCoreDemo.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.Interceptors
{
    public static class TransactionInterceptorTest
    {
        /// <summary>
        /// 事务提交.
        /// </summary>
        public static async Task TestSaveChanges()
        {
            using var context = new DemoDbContext();
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

            Console.WriteLine($"-----------{nameof(TestSaveChanges)} finish-----------");
        }

        public static async Task TestTransaction()
        {
            using var context = new DemoDbContext();
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
            await trans.CommitAsync();

            Console.WriteLine($"-----------{nameof(TestSaveChanges)} finish-----------");
        }
    }
}
