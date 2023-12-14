using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Interfaces;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class ProductService : IProducService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDTO<List<ProductDTO>>> Catalog(string category, string browse)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductDTO>>>($"Product/Catalog/{category}/{browse}");
        }

        public async Task<ResponseDTO<ProductDTO>> Create(ProductDTO product)
        {
            var response = await _httpClient.PostAsJsonAsync("Product/Create", product);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ProductDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"Product/Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return new ResponseDTO<bool> { Result = true, Message = "Se elimno Correctamente", ItsRight = true };
            }
            else
            {

                return new ResponseDTO<bool> { Result = false, Message = $"Algo salio mal: {response.StatusCode}", ItsRight = false };
            }
        }

        public async Task<ResponseDTO<ProductDTO>> GetProduct(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<ProductDTO>>($"Product/GetById/{id}");
        }

        public async Task<ResponseDTO<List<ProductDTO>>> ProductList(string browse)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductDTO>>>($"Product/List/{browse}");
        }

        public async Task<ResponseDTO<bool>> Update(ProductDTO product)
        {
            var response = await _httpClient.PutAsJsonAsync("Product/Update", product);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }
    }
}
