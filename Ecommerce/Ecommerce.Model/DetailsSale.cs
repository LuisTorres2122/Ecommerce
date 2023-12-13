using System;
using System.Collections.Generic;

namespace Ecommerce.Model
{
    public partial class DetailsSale
    {
        public int IdDetailSale { get; set; }
        public int? IdSale { get; set; }
        public int? IdProduct { get; set; }
        public int QuantityProduct { get; set; }
        public decimal? TotalProduct { get; set; }

        public virtual Product? IdProductNavigation { get; set; }
        public virtual Sale? IdSaleNavigation { get; set; }
    }
}
