using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo.LazyLoad
{
    internal class LazyLoadTest
    {
        public static async Task TestAsync()
        {
            var id = Guid.NewGuid().ToString();
            using (var context = new DemoDbContext())
            {
                context.Blogs.Add(new Blog
                {
                    Id = id,
                    Name = "xiaoming",
                    Posts = new List<Post>
                {
                    new Post
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title ="test 1",
                        Content ="test 1"
                    },
                    new Post
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title ="test 2",
                        Content ="test 2"
                    }
                }
                });

                await context.SaveChangesAsync();
            }

            using (var context = new DemoDbContext())
            {
                var blog = await context.Blogs.FirstAsync(b => b.Id == id);
                Console.WriteLine(blog.Posts.Any());
            }
        }
    }
}
