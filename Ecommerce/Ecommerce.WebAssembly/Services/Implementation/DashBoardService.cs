using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Interfaces;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class DashBoardService : IDashboard
    {
        private readonly HttpClient _httpClient;

        public DashBoardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<DashBoardDTO>> Resume()
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<DashBoardDTO>>($"DashBoard/Resume");
        }
    }
}
