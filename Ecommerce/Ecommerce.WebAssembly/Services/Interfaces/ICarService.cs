using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Interfaces
{
    public interface ICarService
    {
        event Action ShowItems;

        int QuatityProductsCar();
        Task AddCar(CarDTO car);
        Task RemoveCar(int idProduct);
        Task<List<CarDTO>> getCar();
        Task CleanCar();
    }
}
