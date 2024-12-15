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
