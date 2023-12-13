using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class SessionDTO
    {
        public int Id { get; set; }      
        public string Name { get; set; } = null!;  
        public string Email { get; set; } = null!;
        public string? Rol { get; set; }

    }
}
