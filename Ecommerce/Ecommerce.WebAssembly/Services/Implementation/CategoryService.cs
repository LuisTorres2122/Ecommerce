using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Interfaces;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class CategoryService : ICategoryService

    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDTO<List<CategotyDTO>>> CategoryList(string browse)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<CategotyDTO>>>($"Category/List/{browse}");
        }

        public async Task<ResponseDTO<CategotyDTO>> Create(CategotyDTO category)
        {
            var response = await _httpClient.PostAsJsonAsync("Category/Create", category);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<CategotyDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Delete(int id)
        {

            var response = await _httpClient.DeleteAsync($"Category/Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return new ResponseDTO<bool> { Result = true, Message = "Se elimno Correctamente", ItsRight = true };
            }
            else
            {

                return new ResponseDTO<bool> { Result = false, Message = $"Algo salio mal: {response.StatusCode}", ItsRight = false };
            }
        }

        public async Task<ResponseDTO<CategotyDTO>> GetCategory(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<CategotyDTO>>($"Category/GetById/{id}");
        }

        public async Task<ResponseDTO<bool>> Update(CategotyDTO category)
        {
            var response = await _httpClient.PutAsJsonAsync("Category/Update", category);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        
    }
}
