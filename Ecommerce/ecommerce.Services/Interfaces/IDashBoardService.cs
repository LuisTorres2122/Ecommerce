using Ecommerce.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Services.Interfaces
{
    public interface IDashBoardService
    {
        Task<DashBoardDTO> Resume();   
    }
}
