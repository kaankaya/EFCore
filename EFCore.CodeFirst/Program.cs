// See https://aka.ms/new-console-template for more information
using EFCore.CodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
//unchanged 
//ilk listeleme yaptıgımız da veritabanından gelen verileri unchanged olarak atar default olarak
//değişilik yaparsak modified
//memoryde track etmeyi bir datayı okumaya çalışırsak detached verir.yani henüz memoryde değil
//update methodu kullanımı track edilmeyen datalar için kullanılır direk ıd sini vererek
//örnegğin ID=5, NAME="DEFTER" PRİCE=500 STOCK=500 BARCODE=500
//EFCORE tarafından track edilmeden datayı güncellemek için _context.update(new product{ıd,name,price,stock,barcode});
//track edildiginde gerek yok
Initializer.Build();
using (var _context = new AppDbContext())
{
    //var products = await _context.Products.ToListAsync(); //git Products tablosu ile haberleş ve ToList ile verilerin hepsini çek
    //products.ForEach(p =>
    //{
    //    //her bir nesneni state yansıt
    //    var state = _context.Entry(p).State;
    //    Console.WriteLine($"{p.Id} - {p.Name} - {p.Price} - {p.Stock} - state: {state}"); //p tablomdaki verilere denk gelir ve sırayla foreach olarak işlemleri listeler
    //});

    //var newProduct = new Product { Name = "Kalemm 200", Price = 200, Stock = 100, Barcode = 333 };

    var product = await _context.Products.FirstAsync(); //contexte product git ilk datayı ver
    Console.WriteLine($"ilk state:{_context.Entry(product).State}");
    _context.Remove(product); //silmek için

    //await _context.AddAsync(newProduct);
    Console.WriteLine($"son state:{_context.Entry(product).State}");

    await _context.SaveChangesAsync();
    Console.WriteLine($"state after save changes state:{_context.Entry(product).State}");
}
