using System;
using System.Collections.Generic;

namespace Ecommerce.Model
{
    public partial class Product
    {
        public Product()
        {
            DetailsSales = new HashSet<DetailsSale>();
        }

        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public string DescriptionProduct { get; set; } 
        public int? IdCategory { get; set; }
        public decimal PriceProduct { get; set; }
        public decimal? OfferPriceProduct { get; set; }
        public int QuantityProduct { get; set; }
        public string? ImageProduct { get; set; }
        public DateTime? CreatedDateProduct { get; set; }

        public virtual Category? IdCategoryNavigation { get; set; }
        public virtual ICollection<DetailsSale> DetailsSales { get; set; }
    }
}
