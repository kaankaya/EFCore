﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DAL
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //her kategorinin birden fazla products olabilir
        //one to many - isimlendirmeler önemlidir
        public List<Product> Products { get; set; }
    }
}
