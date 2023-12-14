using System;
using System.Collections.Generic;

namespace Ecommerce.Model
{
    public partial class User
    {
        public User()
        {
            Sales = new HashSet<Sale>();
        }

        public int IdUser { get; set; }
        public string NameUser { get; set; } 
        public string EmailUser { get; set; } 
        public string PasswordUser { get; set; }
        public string? RolUser { get; set; }
        public DateTime? CreatedDateUser { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
