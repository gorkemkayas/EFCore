using EFCore.CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Fluent API ile yapılan tanımlamalar Data Annotation'u ezer, yani daha önceliklidir.

namespace EFCore.CodeFirst.DAL
{
    public class AppDbContext :DbContext
    {

        //public DbSet<Person> People { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        //public DbSet<ProductEssential> ProductEssentials { get; set; }

        public DbSet<ProductFull> ProductFulls { get; set; }

        public DbSet<ProductCount> ProductCount { get; set; }

        //public DbSet<ProductFulled> ProductFullss { get; set; }

        //public DbSet<Student> Students { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }


        public IQueryable<ProductWithFeature> GetProductWithFeatures(int categoryId)
        {
            return FromExpression(() => GetProductWithFeatures(categoryId));
        }

        public int GetProductCount(int categoryId)
        {
            throw new NotSupportedException();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();

            //.LogTo(Console.WriteLine,LogLevel.Information)
            //.UseLazyLoadingProxies()
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //// TPT
            //modelBuilder.Entity<BasePerson>().ToTable("Persons");
            //modelBuilder.Entity<Employee>().ToTable("Employees");
            //modelBuilder.Entity<Manager>().ToTable("Managers");

            //modelBuilder.Entity<Product>().HasIndex(x => x.Name).IncludeProperties(x => new {x.Price, x.Stock});

            //modelBuilder.Entity<Product>().ToTable(x => x.HasCheckConstraint("PriceDiscountCheck", "[Price]>[DiscountPrice]"));

            //modelBuilder.Entity<ProductEssential>().HasNoKey().ToSqlQuery("select Name,Price From Products");
            //modelBuilder.Entity<ProductEssential>().ToTable(nameof(ProductEssentials), t => t.ExcludeFromMigrations());

            //modelBuilder.Entity<ProductWithFeature>().HasNoKey();
            //modelBuilder.Entity<ProductWithFeature>().ToTable(nameof(ProductWithFeatures), t => t.ExcludeFromMigrations());


            //modelBuilder.Entity<ProductFulled>().HasNoKey().ToTable(nameof(ProductFulls), x => x.ExcludeFromMigrations()).ToView("ProductwithFeatures");



            modelBuilder.Entity<Product>().Property(x => x.isDeleted).HasDefaultValue(false);
            //modelBuilder.Entity<Product>().HasQueryFilter(x => !x.isDeleted);

            modelBuilder.Entity<ProductFull>().ToFunction("fc_product_full").ToTable(nameof(ProductFulls), x => x.ExcludeFromMigrations());


            modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(GetProductWithFeatures), new[] {typeof(int)})!).HasName("fc_product_full_with_parameters");

            modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(GetProductCount), new[] { typeof(int) })!).HasName("dbo.fc_get_product_count");

            modelBuilder.Entity<ProductCount>().HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }
}
