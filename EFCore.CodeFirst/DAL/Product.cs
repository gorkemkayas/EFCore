﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.DAL
{
    public class Product
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        [Precision(18,2)]
        public decimal Price { get; set; }

        //public int Kdv { get; set; }
       // public decimal PriceWithKdv { get; set; }
        public int Stock { get; set; }

        public int Barcode { get; set; }

        

        public DateTime CreatedDate { get; set; } =DateTime.Now;

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ProductFeature ProductFeature { get; set; }
    }
}
 