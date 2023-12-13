using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class LoginDTO
    {

        [Required(ErrorMessage = "Ingrese correo"), EmailAddress(ErrorMessage = "No es un email valido")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese contraseña")]
        public string Password { get; set; } = null!;
     
    } 
}
