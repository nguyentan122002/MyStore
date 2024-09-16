using Azure.Messaging;
using March.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace March.Controllers
{

    public class ProductsController : BaseApiController
    {
        private readonly IProductServices _productServices;
        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var data = await _productServices.GetAllProductsAsync();
            if (data != null)
            {
                return Ok(data);
            }
            return BadRequest("Not Data");

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsAsync(int id)
        {
            var data = await _productServices.GetProductsAsync(id);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
            
           
        }
    }
}
