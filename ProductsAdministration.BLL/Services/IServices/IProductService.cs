using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsAdministration.BLL.DTO;

namespace ProductsAdministration.BLL.Services.IServices
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDto>> GetProducts();
        public Task<ProductDto> GetProductById(int id);
        public Task UpdateProduct(ProductDto productDto);
        public Task DeleteProduct(int id);
        public Task AddProduct(ProductDto productDto);
    }
}
