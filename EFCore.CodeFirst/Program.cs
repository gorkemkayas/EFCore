using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

Initializer.Build();

using (var _context = new AppDbContext())
{
    var category = await _context.Categories.FirstAsync();

    Console.WriteLine("\n\nLazy Loading veritabanı sorgusu ekleniyor... \n\n");

    var products = category.Products;

    
}