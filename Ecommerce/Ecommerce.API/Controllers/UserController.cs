using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ecommerce.Services.Interfaces;
using System.Runtime.CompilerServices;
using Ecommerce.DTO;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("List/{rol:alpha}/{browse:alpha?}")]
        public async Task<IActionResult> List(string rol, string? browse)
        {
            var response = new ResponseDTO<List<UserDTO>>();
            try
            {
                if (browse is null) browse = "";
                response.ItsRight = true;
                response.Result = await _userService.UserList(rol, browse);
            }
            catch (Exception ex)
            {
                response.ItsRight= false;
                response.Message= ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = new ResponseDTO<UserDTO>();
            try
            {
                
                response.ItsRight = true;
                response.Result = await _userService.GetUser(id);
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]UserDTO user)
        {
            var response = new ResponseDTO<UserDTO>();
            try
            {
                response.ItsRight = true;
                response.Result = await _userService.Create(user);
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Authorization")]
        public async Task<IActionResult> Authorization([FromBody] LoginDTO login)
        {
            var response = new ResponseDTO<SessionDTO>();
            try
            {
                response.ItsRight = true;
                response.Result = await _userService.Authorization(login);
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UserDTO user)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.ItsRight = true;
                response.Result = await _userService.Update(user);
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.ItsRight = true;
                response.Result = await _userService.Delete(id);
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
    }
}
