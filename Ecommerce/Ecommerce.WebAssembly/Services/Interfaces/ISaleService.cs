using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Interfaces
{
    public interface ISaleService
    {
        Task<ResponseDTO<SaleDTO>> Register(SaleDTO sale);
    }
}
