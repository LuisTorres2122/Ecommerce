using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Interfaces
{
    public interface IProducService
    {
        Task<ResponseDTO<List<ProductDTO>>> ProductList(string browse);
        Task<ResponseDTO<List<ProductDTO>>> Catalog(string category, string browse);
        Task<ResponseDTO<ProductDTO>> GetProduct(int id);
        Task<ResponseDTO<ProductDTO>> Create(ProductDTO user);
        Task<ResponseDTO<bool>> Update(ProductDTO user);
        Task<ResponseDTO<bool>> Delete(int id);
    }
}
