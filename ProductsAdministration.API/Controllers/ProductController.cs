﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductsAdministration.BLL.DTO;
using ProductsAdministration.BLL.Services.IServices;
using System.Runtime.CompilerServices;

namespace ProductsAdministration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductDto productDto)
        {
            await _productService.AddProduct(productDto);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            return await _productService.GetProductById(id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var productDtos = _productService.GetProducts();

            return Ok(productDtos);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(ProductDto productDto)
        {
            await _productService.UpdateProduct(productDto);

            return Ok(productDto);
        }
    }
}
