using ProductsAdministration.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAdministration.DAL.Repositories.IRepositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducts();
        public Task<Product> GetProductById(int id);
        public Task UpdateProduct(Product product);
        public Task DeleteProduct(int id);
        public Task AddProduct(Product product);
    }
}
