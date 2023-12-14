using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Interfaces;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class SaleService : ISaleService
    {

        private readonly HttpClient _httpClient;

        public SaleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<SaleDTO>> Register(SaleDTO sale)
        {
            var response = await _httpClient.PostAsJsonAsync("Sale/Register", sale);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SaleDTO>>();
            return result!;
        }
    }
}
