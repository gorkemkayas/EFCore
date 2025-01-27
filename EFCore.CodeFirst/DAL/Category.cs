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
        public String Name { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
