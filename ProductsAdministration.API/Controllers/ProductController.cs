using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductsAdministration.BLL.DTO;
using ProductsAdministration.BLL.Services.IServices;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;

namespace ProductsAdministration.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService, IImageService imageService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddProduct(ProductDto productDto)
        {
            await _productService.AddProduct(productDto);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);

            return Ok(product);
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var productDtos = await _productService.GetProducts();

            return Ok(productDtos);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);

            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateProduct(ProductDto productDto)
        {
            await _productService.UpdateProduct(productDto);

            return Ok(productDto);
        }
    }
}
