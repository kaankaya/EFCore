// See https://aka.ms/new-console-template for more information
using EFCore.DatabaseFirstByScaffold.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
using(var _context = new EfcoreDatabaseFirstDbContext())
{
    var products = await _context.Products.ToListAsync();
    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Name} - {p.Price} - {p.Stock}");
    });
}