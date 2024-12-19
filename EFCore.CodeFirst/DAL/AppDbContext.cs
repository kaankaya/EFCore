using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("Sqlcon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().ToTable("productTBB", "productsbb");
            modelBuilder.Entity<Product>().Property(x=>x.Name).IsRequired();
            modelBuilder.Entity<Product>().Property(x=>x.Name).HasMaxLength(100); //maksimum yüz karakter al IsFixedLength(); eklersek sabit oluştur yani minumum da en fazla 100 karkater olucak
            //nvarchar -nchar  n uniq oldugunu ifade eder.nchar tipi sabit oldugunu söyler nvarchar da var ifadesi belirli bir uzunlugu ayarlıyabiliriz.sabit değildir.
            //fluent api öncelikle veritabanına yansır sonra data anationlar yansır
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            //CHANGER TRACKER
            ChangeTracker.Entries().ToList().ForEach(e =>
            {
                //entity si product olanları yakala ve p değişkenine ata
                //is kelimesi herhangi bir nesneyi dönüşütürüp dönüştürülmeyeciğini true false döner
                if (e.Entity is Product p)
                {
                    if (e.State == EntityState.Added)
                    {
                        p.CreatedDate = DateTime.Now;
                    }
                    //Console.WriteLine($"{p.Id} - {p.Name} - {p.Price} - {p.Stock} ");
                }
            });
            return base.SaveChanges();
        }
    }
}
