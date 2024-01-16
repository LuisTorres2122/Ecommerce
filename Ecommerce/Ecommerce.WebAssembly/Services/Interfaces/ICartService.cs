using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Interfaces
{
    public interface ICartService
    {
        event Action ShowItems;

        int QuatityProductsCart();
        Task AddCart(CartDTO cart);
        Task RemoveCart(int idProduct);
        Task<List<CartDTO>> getCart();
        Task CleanCart();
    }
}
