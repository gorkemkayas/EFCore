using EFCore.DatabaseFirstByScaffold.Models;
using Microsoft.EntityFrameworkCore;

using ( var context = new EfcoreDatabaseFirstDbContext())
{
    var products = await context.Products.ToListAsync();

    products.ForEach(p => Console.WriteLine($"{p.Id} : {p.Name} - {p.Price}"));
}