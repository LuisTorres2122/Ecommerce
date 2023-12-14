using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Interfaces
{
    public interface IDashboard
    {
        Task<ResponseDTO<DashBoardDTO>> Resume();
    }
}
