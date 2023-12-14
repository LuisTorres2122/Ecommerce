using Ecommerce.DTO;
using ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ecommerce.Services.Implementation;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CateogoryController : ControllerBase
    {
        private readonly ICategorySevice _categoryrService;

        public CateogoryController(ICategorySevice categoryrService)
        {
            _categoryrService = categoryrService;
        }


        [HttpGet("CategoryList/{browse:alpha}")]
        public async Task<IActionResult> CategoryList(string browse)
        {
            var response = new ResponseDTO<List<CategotyDTO>>();
            try
            {
                response.ItsRight = true;
                response.Result = await _categoryrService.CategoryList(browse);
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = new ResponseDTO<CategotyDTO>();
            try
            {

                response.ItsRight = true;
                response.Result = await _categoryrService.GetCategory(id);
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }



        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CategotyDTO cat)
        {
            var response = new ResponseDTO<CategotyDTO>();
            try
            {
                response.ItsRight = true;
                response.Result = await _categoryrService.Create(cat);
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }



        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CategotyDTO cat)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.ItsRight = true;
                response.Result = await _categoryrService.Update(cat);
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
                response.Result = await _categoryrService.Delete(id);
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
