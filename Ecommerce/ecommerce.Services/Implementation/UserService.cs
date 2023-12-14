using ecommerce.Services.Interfaces;
using Ecommerce.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Model;
using AutoMapper;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<SessionDTO> Authorization(LoginDTO login)
        {
            try
            {
                var query = _userRepository.get(u => u.EmailUser == login.Email && u.PasswordUser == login.Password);
                var fromDB = await query.FirstOrDefaultAsync();

                if (fromDB != null)
                    return _mapper.Map<SessionDTO>(fromDB); 
                else
                    throw new TaskCanceledException("No se encontro");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserDTO> Create(UserDTO user)
        {
            try
            {
                var dbModel = _mapper.Map<User>(user);
                var ResponseRepository = await _userRepository.Create(dbModel);
                if (ResponseRepository.IdUser != 0)
                    return _mapper.Map<UserDTO>(ResponseRepository);
                else
                    throw new TaskCanceledException("No se puede crear");
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var query = _userRepository.get(u => u.IdUser == id);
                var existingUser = await query.FirstOrDefaultAsync();
                if (existingUser != null)
                {
                    var deleteUser = await _userRepository.Delete(existingUser);

                    if (!deleteUser)
                        throw new TaskCanceledException("No se pudo Eliminar");
                    return deleteUser;
                }
                else
                {
                    throw new TaskCanceledException("No se encontro");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserDTO> GetUser(int id)
        {
            try
            {
                var query = _userRepository.get(u => u.IdUser == id);
                var existingUser = await query.FirstOrDefaultAsync();
                if (existingUser != null)
                    return _mapper.Map<UserDTO>(existingUser);
                else
                    throw new TaskCanceledException("No se encontro");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(UserDTO user)
        {
            try
            {
                var query = _userRepository.get(u => u.IdUser == user.Id);
                var existingUser = await query.FirstOrDefaultAsync();
                if (existingUser != null)
                {
                    existingUser.NameUser = user.Name;     
                    existingUser.EmailUser = user.Email;
                    existingUser.PasswordUser = user.Password;
                    var response = await _userRepository.Update(existingUser);
                    if (!response)
                        throw new TaskCanceledException("No se pudo Editar");
                    return response;
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron Resultado");
                }
                    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UserDTO>> UserList(string rol, string browse)
        {
            try
            {
                var query = _userRepository
                    .get(u => u.RolUser == rol &&
                    string.Concat(u.NameUser.ToLower(), u.EmailUser.ToLower()).Contains(browse));
                var list = await query.ToListAsync();
                return _mapper.Map<List<UserDTO>>(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
