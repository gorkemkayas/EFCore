using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.Models
{
    public class ProductFulled
    {
        public int Id { get; set; }

        [Column("ProductName")]
        public string ProductName { get; set; }
        [Column("CategoryName")]
        public string CategoryName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

    }
}
