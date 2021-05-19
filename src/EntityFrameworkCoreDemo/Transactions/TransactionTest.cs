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
        public static void TestSaveChanges()
        {
            // 添加一条数据
            string existsId = null;
            using (var context = new DemoDbContext())
            {
                var existsOrder = context.Orders.FirstOrDefault();
                if (existsOrder != null)
                {
                    existsId = existsOrder.Id;
                }
                else
                {
                    existsId = "1";
                    context.Orders.Add(new Order
                    {
                        Id = existsId,
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

                    context.SaveChanges();
                }
            }

            var notExistsId = Guid.NewGuid().ToString();
            using (var context = new DemoDbContext())
            {
                context.Orders.Add(new Order
                {
                    Id = notExistsId,
                    OrderDate = DateTime.Now,
                    OrderNo = "2",
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

                context.Orders.Add(new Order
                {
                    Id = existsId,
                    OrderDate = DateTime.Now,
                    OrderNo = "2",
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

                try
                {
                    context.SaveChanges();
                }
                catch
                {
                }
            }

            using (var context = new DemoDbContext())
            {
                Console.WriteLine(context.Orders.Where(o => o.Id == notExistsId).Count());
            }
        }
    }
}
