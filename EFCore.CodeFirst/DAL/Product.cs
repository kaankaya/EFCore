using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DAL
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        //her yapılan bir değişik de yeni migration oluşturmamız gerekiyor senkron olması adına
        //yeni bir sutun ekledik ve yeni bir migration daha oluşturduk
        //çalışma prensibine göre önce addmigrate yaptıgımız da snapshot gidiyor bakıyor kıyaslıyor eksik olanı tespit edip ona göre yeni bir migrate oluşturuyor
        public DateTime? CreatedDate { get; set; }
        public int Barcode { get; set; }
    }
}
