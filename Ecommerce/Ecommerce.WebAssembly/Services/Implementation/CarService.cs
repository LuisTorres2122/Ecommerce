using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Interfaces;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class CarService : ICarService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly ISyncLocalStorageService _syncLocalStorageService;
        private readonly IToastService _toastService;

        public CarService(
            ILocalStorageService localStorageService,
            ISyncLocalStorageService syncLocalStorageService,
            IToastService toastService)
        {
            _localStorageService = localStorageService;
            _syncLocalStorageService = syncLocalStorageService; 
            _toastService = toastService;
        }

        public event Action ShowItems;

        public async Task AddCar(CarDTO car)
        {
            try 
            {
                var getCar = await _localStorageService.GetItemAsync<List<CarDTO>>("Car");
                if(getCar == null)
                 getCar = new List<CarDTO>();

                var founded = getCar.FirstOrDefault(c => c.Product.Id == car.Product.Id);

                if (founded != null)
                    getCar.Remove(founded);

                getCar.Add(car);
                await _localStorageService.SetItemAsync("Car",getCar);

                if (founded != null)
                    _toastService.ShowSuccess("El producto ha sido actulizado");
                else
                    _toastService.ShowSuccess("El producto ha sido agregado");

                ShowItems.Invoke();
            }
            catch
            {
                _toastService.ShowError("No se pudo agregar");
            }
        }

        public async Task CleanCar()
        {
            await _localStorageService.RemoveItemAsync("Car");
            ShowItems.Invoke();
        }

        public async Task<List<CarDTO>> getCar()
        {
            var getCar = await _localStorageService.GetItemAsync<List<CarDTO>>("Car");
            if (getCar != null)
                getCar = new List<CarDTO>();

            return getCar;
        }

        public int QuatityProductsCar()
        {
            var getCar = _syncLocalStorageService.GetItem<List<CarDTO>>("Car");
            return getCar == null ? 0 : getCar.Count();
        }

        public async Task RemoveCar(int idProduct)
        {
            try
            {
                var getCar = await _localStorageService.GetItemAsync<List<CarDTO>>("Car");
                if (getCar != null)
                {
                    var element = getCar.FirstOrDefault(c => c.Product.Id == idProduct);
                    if (element != null)
                    {
                       getCar.Remove(element);
                       await _localStorageService.SetItemAsync("Car", getCar);
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
