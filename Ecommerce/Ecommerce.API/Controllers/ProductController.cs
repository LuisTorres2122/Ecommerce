using Ecommerce.DTO;
using ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ecommerce.Services.Implementation;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("List/{browse:alpha?}")]
        public async Task<IActionResult> List(string? browse)
        {
            var response = new ResponseDTO<List<ProductDTO>>();
            try
            {
                response.ItsRight = true;
                response.Result = await _productService.ProductList(browse);
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("Catalog/{category:alpha}/{browse:alpha?}")]
        public async Task<IActionResult> Catalog(string category, string? browse)
        {
            var response = new ResponseDTO<List<ProductDTO>>();
            try
            {
                if (browse is null) browse = "";
                response.ItsRight = true;
                response.Result = await _productService.Catalog(category, browse);
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
            var response = new ResponseDTO<ProductDTO>();
            try
            {

                response.ItsRight = true;
                response.Result = await _productService.GetProduct(id);
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ProductDTO cat)
        {
            var response = new ResponseDTO<ProductDTO>();
            try
            {
                response.ItsRight = true;
                response.Result = await _productService.Create(cat);
            }
            catch (Exception ex)
            {
                response.ItsRight = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ProductDTO cat)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.ItsRight = true;
                response.Result = await _productService.Update(cat);
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
                response.Result = await _productService.Delete(id);
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
