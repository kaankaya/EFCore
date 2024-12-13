// See https://aka.ms/new-console-template for more information
using EFCore.DatabaseFirst.DAL;
using Microsoft.EntityFrameworkCore;
DbContextInitializer.Build();
//nesne örneğini alıyoruz
//using ifade si kullanıyoruz çünkü bu işlem bitince memoryden dispose olsun diye
//memory de context tutmak mantıklı değil.scope bittiği an memorden uçar
using (var _context = new AppDbContext())
{
    var products = await _context.Products.ToListAsync(); //git Products tablosu ile haberleş ve ToList ile verilerin hepsini çek
    products.ForEach(p =>
    {
    Console.WriteLine($"{p.Id} - {p.Name} - {p.Price} - {p.Stock}"); //p tablomdaki verilere denk gelir ve sırayla foreach olarak işlemleri listeler
    });
}
