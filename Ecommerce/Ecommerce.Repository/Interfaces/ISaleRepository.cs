using Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Interfaces
{
    public interface ISaleRepository: IRepository<Sale>
    {
        Task<Sale> Register(Sale sale);
    }
}
