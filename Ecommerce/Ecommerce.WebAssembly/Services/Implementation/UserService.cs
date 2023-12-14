using Ecommerce.DTO;
using Ecommerce.WebAssembly.Services.Interfaces;
using System.Net.Http.Json;


namespace Ecommerce.WebAssembly.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<SessionDTO>> Authorization(LoginDTO login)
        {
            var response = await _httpClient.PostAsJsonAsync("User/Authorization", login);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SessionDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<UserDTO>> Create(UserDTO user)
        {
            var response = await _httpClient.PostAsJsonAsync("User/Create", user);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UserDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"User/Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return new ResponseDTO<bool> { Result = true, Message = "Se elimno Correctamente", ItsRight = true };
            }
            else
            {
               
                return new ResponseDTO<bool> { Result = false, Message = $"Algo salio mal: {response.StatusCode}", ItsRight = false };
            }

        }

        public async Task<ResponseDTO<UserDTO>> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<UserDTO>>($"User/GetById/{id}");
        }

        public async Task<ResponseDTO<List<UserDTO>>> List(string rol, string browse)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<UserDTO>>>($"User/List/{rol}/{browse}");
        }

        public async Task<ResponseDTO<bool>> Update(UserDTO userDTO)
        {
            var response = await _httpClient.PutAsJsonAsync("User/Update", userDTO);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }
    }
}
