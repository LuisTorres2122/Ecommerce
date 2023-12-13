using System;
using System.Collections.Generic;

namespace Ecommerce.Model
{
    public partial class Sale
    {
        public Sale()
        {
            DetailsSales = new HashSet<DetailsSale>();
        }

        public int IdSale { get; set; }
        public int? IdUser { get; set; }
        public decimal TotalSale { get; set; }
        public DateTime? CreatedDateSale { get; set; }

        public virtual User? IdUserNavigation { get; set; }
        public virtual ICollection<DetailsSale> DetailsSales { get; set; }
    }
}
