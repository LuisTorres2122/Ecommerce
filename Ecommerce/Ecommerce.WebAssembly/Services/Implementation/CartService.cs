using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Interfaces;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly ISyncLocalStorageService _syncLocalStorageService;
       

        public CartService(
            ILocalStorageService localStorageService,
            ISyncLocalStorageService syncLocalStorageService)
        {
            _localStorageService = localStorageService;
            _syncLocalStorageService = syncLocalStorageService; 
          
        }

        public event Action ShowItems;

        public async Task AddCart(CartDTO cart)
        {
            try 
            {
                var getCart = await _localStorageService.GetItemAsync<List<CartDTO>>("Cart");
                if(getCart == null)
                 getCart = new List<CartDTO>();

                var founded = getCart.FirstOrDefault(c => c.Product.Id == cart.Product.Id);

                if (founded != null)
                    getCart.Remove(founded);

                getCart.Add(cart);
                await _localStorageService.SetItemAsync("Cart",getCart);

                if (founded != null)
                    Console.WriteLine("El producto ha sido actulizado");
                else
                    Console.WriteLine("El producto ha sido agregado");

                ShowItems.Invoke();
            }
            catch
            {
                Console.WriteLine("No se pudo agregar");
            }
        }

        public async Task CleanCart()
        {
            await _localStorageService.RemoveItemAsync("Cart");
            ShowItems.Invoke();
        }

        public async Task<List<CartDTO>> getCart()
        {
            var getCart = await _localStorageService.GetItemAsync<List<CartDTO>>("Cart");
            if (getCart == null)
                getCart = new List<CartDTO>();

            return getCart;
        }

        public int QuatityProductsCart()
        {
            var getCart = _syncLocalStorageService.GetItem<List<CartDTO>>("Cart");
            return getCart == null ? 0 : getCart.Count();
        }

        public async Task RemoveCart(int idProduct)
        {
            try
            {
                var getCart = await _localStorageService.GetItemAsync<List<CartDTO>>("Cart");
                if (getCart != null)
                {
                    var element = getCart.FirstOrDefault(c => c.Product.Id == idProduct);
                    if (element != null)
                    {
                       getCart.Remove(element);
                       await _localStorageService.SetItemAsync("Cart", getCart);
                        ShowItems.Invoke();
                    }
                       
                }


            }
            catch
            {

            }
        }
    }
}
