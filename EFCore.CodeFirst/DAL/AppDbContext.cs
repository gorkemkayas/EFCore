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
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<ProductFeature> ProductFeatures { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }

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

            modelBuilder.Entity<Manager>().OwnsOne(x => x.Person, p=>
            {
                p.Property(x => x.FirstName).HasColumnName("First Name");
                p.Property(x => x.LastName).HasColumnName("Last Name");
                p.Property(x => x.Age).HasColumnName("Age");

            });

            modelBuilder.Entity<Employee>().OwnsOne(x => x.Person, p =>
            {
                p.Property(x => x.FirstName).HasColumnName("First Name");
                p.Property(x => x.LastName).HasColumnName("Last Name");
                p.Property(x => x.Age).HasColumnName("Age");

            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
