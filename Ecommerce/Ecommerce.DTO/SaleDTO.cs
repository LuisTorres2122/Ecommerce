using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class SaleDTO
    {
        public int Id { get; set; }
        public int? IdUser { get; set; }
        public decimal Total { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual ICollection<DetailsSaleDTO> DetailsSales { get; set; } = new List<DetailsSaleDTO>();
    }
}
