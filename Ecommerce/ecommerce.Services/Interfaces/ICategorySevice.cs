using Ecommerce.DTO;
using Ecommerce.Model;
using Ecommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Services.Interfaces
{
    public interface ICategorySevice
    {
        Task<List<CategotyDTO>> CategoryList(string browse);
        Task<CategotyDTO> GetCategory(int id);
        Task<CategotyDTO> Create(CategotyDTO category);
        Task<bool> Update(CategotyDTO category);
        Task<bool> Delete(int id);
    }
}
