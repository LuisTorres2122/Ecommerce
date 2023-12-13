using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class DetailsSaleDTO
    {
        public int Id { get; set; } 
        public int? IdProduct { get; set; }
        public int Quantity { get; set; }
        public decimal? Total { get; set; }
    }
}
