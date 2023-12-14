using ecommerce.Services.Implementation;
using ecommerce.Services.Interfaces;
using Ecommerce.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashBoardService _dashService;

        public DashBoardController(IDashBoardService dashService)
        {
            _dashService = dashService;
        }

        [HttpGet("Resume")]
        public async Task<IActionResult> Resume()
        {
            var response = new ResponseDTO<DashBoardDTO>();
            try
            {
                response.ItsRight = true;
                response.Result = await _dashService.Resume();
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
