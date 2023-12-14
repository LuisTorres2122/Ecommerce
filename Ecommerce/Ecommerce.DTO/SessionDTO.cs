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
        public string Name { get; set; } 
        public string Email { get; set; } 
        public string? Rol { get; set; }

    }
}
