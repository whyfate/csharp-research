using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFrameworkCoreDemo
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext() { }

        public DemoDbContext(DbContextOptions<DemoDbContext> options)
            : base(options)
        { }

        public virtual DbSet<Relational.Schedule> Schedules { get; set; }
        public virtual DbSet<Relational.Cascades.Parent> Parents { get; set; }

        public virtual DbSet<ValueObject.Order> Orders { get; set; }

        public virtual DbSet<ValueConversions.People> Peoples { get; set; }

        public virtual DbSet<LazyLoad.Blog> Blogs { get; set; }

        public virtual DbSet<LazyLoad.Post> Posts { get; set; }

        public virtual DbSet<Concurrency.ConcurrencyEntity> ConcurrencyEntities { get; set; }

        public virtual DbSet<ChangeKeyType.GuidToStringEntity> GuidToStringEntities { get; set; }

        public virtual DbSet<ChangeKeyType.NumberProvider> NumberProviders { get; set; }

        public virtual DbSet<ChangeKeyType.Number> Numbers { get; set; }

        /// <summary>
        /// 重写SaveChanges.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            Console.WriteLine($"模型修改数：{this.ChangeTracker.Entries().Count()}");

            return base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 配置连接字符串.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=efcore-demo;Trusted_Connection=True;");
                optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder =>
                {
                    builder.AddConsole();
                }));

                // 拦截器
                optionsBuilder.AddInterceptors(new Interceptors.CommandInterceptor());
                optionsBuilder.AddInterceptors(new Interceptors.ConnectionInterceptor());
                optionsBuilder.AddInterceptors(new Interceptors.TransactionInterceptor());

                // 延迟加载
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        /// <summary>
        /// 配置模型.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relational Configuration
            modelBuilder.ApplyConfiguration(new Relational.ParentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new Relational.ScheduleParticipantEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new Relational.Cascades.ParentEntityTypeConfiguration());

            // ValueObject Configuration
            modelBuilder.ApplyConfiguration(new ValueObject.OrderEntityTypeConfiguration());

            // value conversion
            modelBuilder.ApplyConfiguration(new ValueConversions.PersonEntityTypeConfiguration());

            // lazy load
            modelBuilder.ApplyConfiguration(new LazyLoad.BlogEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LazyLoad.PostEntityTypeConfiguration());

            // Concurrency
            modelBuilder.ApplyConfiguration(new Concurrency.ConcurrencyEntityTypeConfiguration());

            // change type 
            modelBuilder.ApplyConfiguration(new ChangeKeyType.GuidToStringEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ChangeKeyType.NumberProviderTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ChangeKeyType.NumberTypeConfiguration());
        }
    }
}
