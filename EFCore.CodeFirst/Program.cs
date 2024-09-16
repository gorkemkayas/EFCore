using AutoMapper.Internal.Mappers;
using AutoMapper.QueryableExtensions;
using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using EFCore.CodeFirst.DTOs;
using EFCore.CodeFirst.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Diagnostics;

Initializer.Build();

var dbConnection = new SqlConnection(Initializer.Configuration.GetConnectionString("SqlCon"));
IDbContextTransaction transaction = null;

var _context = new AppDbContext(dbConnection);



    using (transaction = _context.Database.BeginTransaction())
    {
        var category = new Category() { Name = "Phones" };
        _context.Categories.Add(category);
        _context.SaveChanges();

        var product = new Product() { Name = "Iphone 16", Price = 1500, Stock = 200, CategoryId = category.Id, DiscountPrice = 100 };
        _context.Products.Add(product);
        _context.SaveChanges();


        using (var dbContext2 = new AppDbContext(dbConnection))
        {
            dbContext2.Database.UseTransaction(transaction.GetDbTransaction());

            var selectedProduct = dbContext2.Products.First();
            selectedProduct.Stock = 50;

        }
        transaction.Commit();
    }

    _context.Dispose();
    Console.WriteLine("işlem bitti.");

