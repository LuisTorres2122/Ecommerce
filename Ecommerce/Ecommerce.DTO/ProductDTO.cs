using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ingrese el nombre del producto")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese la descripción del producto")]
        public string Description { get; set; } = null!;
        public int? IdCategory { get; set; }
        [Required(ErrorMessage = "Ingrese el precio del producto")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Ingrese el precio oferta del producto")]
        public decimal? OfferPrice { get; set; }
        [Required(ErrorMessage = "Ingrese la cantidad del producto")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Ingrese la imagen del producto")]
        public string? Image { get; set; }
        [Required(ErrorMessage = "Ingrese la fecha del producto")]
        public DateTime? CreatedDateProduct { get; set; }
        public virtual CategotyDTO? IdCategoryNavigation { get; set; }
    }
}
