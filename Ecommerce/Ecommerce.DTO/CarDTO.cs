﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class CarDTO
    {
        public ProductDTO? Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal  Total { get; set; }

    }
}
