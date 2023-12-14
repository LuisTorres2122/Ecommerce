using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DTO;

namespace ecommerce.Services.Interfaces
{
    public interface IUserService
    {
        Task <List<UserDTO>> UserList(string rol, string browse);
        Task<UserDTO> GetUser(int id);
        Task<SessionDTO> Authorization(LoginDTO login);
        Task<UserDTO> Create(UserDTO user);
        Task<bool> Update(UserDTO user);
        Task<bool> Delete(int id);


    }
}
