using EFCore.CodeFirst;
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

Initializer.Build();

using (var _context = new AppDbContext())
{

    //var persons = _context.People.AsNoTracking().ToList().Where(x => FormatPhone(x.Phone) == "5438726177");
    //var person = _context.People.ToList().Select(x => new { PersonName = x.Name , PersonPhone = FormatPhone(x.Phone) } );


    //_context.People.Add(new() { Name = "Görkem", Phone = "05438726177" });
    //_context.People.Add(new() { Name = "Mehmet", Phone = "03354587352" });

    //var category = new Category() { Name = "Pencils 1" };

    //category.Products.Add(new() { Name = "Pencil 1", Price = 100, Stock = 200, Barcode = 123, ProductFeature = new ProductFeature() { Color = "Red", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "Pencil 2", Price = 200, Stock = 200, Barcode = 124, ProductFeature = new ProductFeature() { Color = "Green", Height = 200, Width = 100 } });
    //category.Products.Add(new() { Name = "Pencil 3", Price = 300, Stock = 200, Barcode = 125, ProductFeature = new ProductFeature() { Color = "Blue", Height = 200, Width = 100 } });

    //_context.Categories.Add(category);
    //_context.SaveChanges();



    // 2'li join

    //var result = _context.Categories.Join(_context.Products,x => x.Id, y=> y.CategoryId, (c,p) => c).ToList();

    //var result = (from c in _context.Categories
    //              join p in _context.Products on c.Id equals p.CategoryId
    //              select new
    //              {
    //                  CategoryName = c.Name,
    //                  ProductName = p.Name,
    //                  ProductPrice = p.Price,

    //              }
    //             ).ToList();



    // 3'lü join

    //var result2 = (from c in _context.Categories
    //              join p in _context.Products on c.Id equals p.CategoryId
    //              join pf in _context.ProductFeatures on p.Id equals pf.Id
    //              select new
    //              {
    //                  CategoryName = c.Name,
    //                  ProductName = p.Name,
    //                  ProductFeatureColor = pf.Color
    //              }).ToList();


    // left join

    //var result = await (from p in _context.Products
    //             join pf in _context.ProductFeatures on p.Id equals pf.Id into pflist
    //             from pf in pflist.DefaultIfEmpty()
    //             select new {p, pf}).ToListAsync();


    //var products = await _context.ProductEssentials.FromSqlRaw("select Name, Price From products").ToListAsync();

    //var productsWithFeatue = await _context.ProductWithFeatures.FromSqlRaw("SELECT p.Id, p.Name, p.Price, pf.Color, pf.Height FROM Products p\r\ninner join ProductFeatures pf on p.Id = pf.Id").ToListAsync();

    //var product = await _context.ProductFulls.ToListAsync();

    //var product = await _context.Products.ToListAsync();

    //product.ForEach(x =>
    //{
    //    Console.WriteLine($"{x.Id} {x.Name} {x.CreatedDate} {x.Barcode}");
    //});
    
    var product = await _context.GetProductWithFeatures(5).ToListAsync();

    //var categories = await _context.Categories.Select(x => new
    //{
    //    CategoryName = x.Name,
    //    ProductCount = _context.GetProductCount(x.Id)
    //}).ToListAsync();

    int categoryId = 5;
    var productCount = _context.ProductCount.FromSqlInterpolated($"select dbo.fc_get_product_count({categoryId}) as Count").First().Count;

    Console.WriteLine("işlem bitti.");
}

string FormatPhone(string phone)
{
    return phone.Substring(1, phone.Length - 1);
}