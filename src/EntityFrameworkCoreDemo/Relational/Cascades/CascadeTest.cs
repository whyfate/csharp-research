using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.Relational.Cascades
{
    internal class CascadeTest
    {
        public static async Task TestQueryAsync()
        {
            var id = Guid.NewGuid().ToString();
            using (var context = new DemoDbContext())
            {
                context.Parents.Add(new Parent
                {
                    Id = id,
                    Name = "p",
                    Children = new List<Child>
                    {
                        new Child
                        {
                            Name ="c",
                            Grands = new List<Grand>
                            {
                                new Grand
                                {
                                    Name="g",
                                }
                            }
                        }
                    }
                });

                await context.SaveChangesAsync();
            }

            using (var context = new DemoDbContext())
            {
                var p = await context.Parents.Where(p => p.Id == id).FirstAsync();
                Console.WriteLine(p.Children.First().Grands.First().Name);
            }
        }

        public static async Task TestUpdateAsync()
        {
            var id = Guid.NewGuid().ToString();
            using (var context = new DemoDbContext())
            {
                context.Parents.Add(new Parent
                {
                    Id = id,
                    Name = "p",
                    Title = "p",
                    Children = new List<Child>
                    {
                        new Child
                        {
                            Name ="c",
                            Title = "c",
                            Grands = new List<Grand>
                            {
                                new Grand
                                {
                                    Name="g",
                                    Code = "g",
                                }
                            }
                        }
                    }
                });

                await context.SaveChangesAsync();
            }

            using (var context = new DemoDbContext())
            {
                var parent = new Parent
                {
                    Id = id,
                    Name = "u-p",
                    Children = new List<Child>
                    {
                        new Child
                        {
                            Name ="u-c",
                            Grands = new List<Grand>
                            {
                                new Grand
                                {
                                    Name="u-g",
                                }
                            }
                        }
                    }
                };

                // 级联的实体是追加数据，不是全部重新替换
                context.Parents.Add(parent).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }

            using (var context = new DemoDbContext())
            {
                var p = await context.Parents.Where(p => p.Id == id).FirstAsync();
                Console.WriteLine(p.ToString());
            }
        }
    }
}
