using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DAL
{
    //Configuration yapmak için Efcore bize 3 tane seçenek sunar
    //Data Annotations Attributes , Fluent Apı,Convensions
    //[Table("ProductTb",Schema ="products")] tablo ismini böyle tanımlıyabiliriz
    public class Product
    {
        public int Id { get; set; }
        //[Column("name2",TypeName ="nvarchar")] column tipleri için
        //[Column("name2",Order = 1)] column tipleri için order ile sıralamasını ayarlıyabiliriz
        //nullable açık ise nullable:False dir.Eğer projenin propertieslerinden kapalı olursa nullable:true olur string ifadeler için
        //[MaxLength(100)]//en fazla 100 karakter al diyoruz
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        //her yapılan bir değişik de yeni migration oluşturmamız gerekiyor senkron olması adına
        //yeni bir sutun ekledik ve yeni bir migration daha oluşturduk
        //çalışma prensibine göre önce addmigrate yaptıgımız da snapshot gidiyor bakıyor kıyaslıyor eksik olanı tespit edip ona göre yeni bir migrate oluşturuyor
        public int Barcode { get; set; }

        //bir product un bir kategorisi olur - CategoryId yazarak ef core otomatik olarak foreign key olarak algıyıor
        public int CategoryId { get; set; }
        //Bu navigation Property dir
        public Category Category { get; set; }

    }
}
