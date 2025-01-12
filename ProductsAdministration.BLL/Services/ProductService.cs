using ProductsAdministration.BLL.DTO;
using ProductsAdministration.BLL.Services.IServices;
using ProductsAdministration.DAL.Repositories.IRepositories;
using ProductsAdministration.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;

namespace ProductsAdministration.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddProduct(ProductDto productDto)
        {
            var product = productDto.Adapt<Product>();

            await _productRepository.AddProduct(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _productRepository.GetProductById(id);

            return product.Adapt<ProductDto>();
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var products = await _productRepository.GetProducts();

            return products.Adapt<IEnumerable<ProductDto>>();
        }

        public async Task UpdateProduct(ProductDto productDto)
        {
            var product = productDto.Adapt<Product>();

            await _productRepository.UpdateProduct(product);
        }
    }
}
