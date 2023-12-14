using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Services.Interfaces
{
    public interface IUserService
    {
        Task<ResponseDTO<List<UserDTO>>> List(string rol, string browse);
        Task<ResponseDTO<UserDTO>> Get(int id);
        Task<ResponseDTO<SessionDTO>> Authorization(LoginDTO login);
        Task<ResponseDTO<UserDTO>> Create(UserDTO user);
        Task<ResponseDTO<bool>> Update(UserDTO userDTO);
        Task<ResponseDTO<bool>> Delete(int id);
    }
}
