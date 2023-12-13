using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class UserDTO
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Ingrese su nombre completo")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese correo"), EmailAddress(ErrorMessage ="No es un email valido")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese contraseña")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Confirmación contraseña")]
        public string ConfirmPassword { get; set; } = null!;
        public string? Rol { get; set; }

    }
}
