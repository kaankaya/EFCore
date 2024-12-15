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
    //First(x=>x.Id == 100) ıd si 100 eşit olanı bul yoksa hata fırlat
    //FirstOrDefault(x=>x.Id == 100) yoksa geriye null döner. bunun ek olarak null oldugunda değer verebiliyoruz FirstOrDefault(x=>x.Id == 100,new Product(){Id=1,Name="kalem1});
    //SingleAsync(x=>x.Id > 10) 10 den birden fazla var ise hata atar,Şartı sağlayan tekbir data olursa alır single yoksa hatayı fırlatır
    //Where(x=>x.Id > 10).ToListAsync() where de içeri deki şartı sağlayan değerleri bir liste olarak geri döner
    //Where(x=>x.Id > 10 && x.Name = "kalem 10").ToListAsync() eğer birden fazla data ya göre listelemek istersek de bu şekilde yazmamız gerekiyor
    //FirstAsync(10) tek data için olur ve ilk gelen olur.ilgili datayı bulamaz ise null döner ama mutlaka hata dönsün derseniz null olmasın derseniz Single() kullanılması gerekiyor

    var products = await _context.Products.FirstAsync(x=>x.Id == 10);

    //products.ForEach(p =>
    //{

    //});










    //AsNoTracking(); gelen data efcore tarafından track edilmemesini sağlıyor.Ram daha düzgün oluyor.
    //Ekranda aldıgımız datayı direk listeleme yapıyorsak kullanmalıyız.çünkü herhangi bir değişiklik yapmıyacak performans açısından önemli
    //tolist direk çağırmak çok bestpractic değil 1 milyon data geldiğinde sorun oluşabilir.SAyfalama yaparak parça parça çıkarabilirisz
    //var products = await _context.Products.AsNoTracking().ToListAsync(); //git Products tablosu ile haberleş ve ToList ile verilerin hepsini çek

    //products.ForEach(p =>
    //{
    //    //p.Stock += 100;
    //    //her bir nesneni state yansıt
    //    //var state = _context.Entry(p).State;
    //    Console.WriteLine($"{p.Id} - {p.Name} - {p.Price} - {p.Stock} "); //p tablomdaki verilere denk gelir ve sırayla foreach olarak işlemleri listeler
    //});
    //buradaki e memory de track edilen her bir dataya denk geliyor


    //_context.Products.Add(new Product { Name = "Kalem7", Price = 300, Stock = 200, Barcode = 697});
    //_context.Products.Add(new Product { Name = "Kalem8", Price = 300, Stock = 200, Barcode = 697});
    //_context.Products.Add(new Product { Name = "Kalem9", Price = 300, Stock = 200, Barcode = 697});
   //_context.ContextId Birden fazla context imiz var ise id ile müdahale edebiliriz loglama için
   //_context.Database ile istersek transction yönetimi istersek ham sql istersek migrate vb birden fazla işlemleri yönetebiliriz Soyutlanan tüm süreçlere erişebiliriz



    //_context.SaveChanges();




    //var newProduct = new Product { Name = "Kalemm 200", Price = 200, Stock = 100, Barcode = 333 };

    //var product = await _context.Products.FirstAsync(); //contexte product git ilk datayı ver
    //Console.WriteLine($"ilk state:{_context.Entry(product).State}");
    //_context.Remove(product); //silmek için

    ////await _context.AddAsync(newProduct);
    //Console.WriteLine($"son state:{_context.Entry(product).State}");

    //await _context.SaveChangesAsync();
    //Console.WriteLine($"state after save changes state:{_context.Entry(product).State}");
}
