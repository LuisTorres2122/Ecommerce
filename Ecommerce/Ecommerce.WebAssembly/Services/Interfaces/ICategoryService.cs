using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ResponseDTO<List<CategotyDTO>>> CategoryList(string browse);
        Task<ResponseDTO<CategotyDTO>> GetCategory(int id);
        Task<ResponseDTO<CategotyDTO>> Create(CategotyDTO category);
        Task<ResponseDTO<bool>> Update(CategotyDTO category);
        Task<ResponseDTO<bool>> Delete(int id);
    }
}
