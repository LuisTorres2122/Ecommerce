using Ecommerce.DTO;
using ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _salerService;

        public SaleController(ISaleService salerService)
        {
            _salerService = salerService;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(SaleDTO sale)
        {
            var response = new ResponseDTO<SaleDTO>();
            try
            {
                response.ItsRight = true;
                response.Result = await _salerService.Register(sale);
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
