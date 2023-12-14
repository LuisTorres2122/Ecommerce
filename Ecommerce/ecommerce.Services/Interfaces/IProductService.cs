using Ecommerce.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDTO>> ProductList(string browse);
        Task<List<ProductDTO>> Catalog(string category, string browse);
        Task<ProductDTO> GetProduct(int id);
        Task<ProductDTO> Create(ProductDTO user);
        Task<bool> Update(ProductDTO user);
        Task<bool> Delete(int id);
    }
}
