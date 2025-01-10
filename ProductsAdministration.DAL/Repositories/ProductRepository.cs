using Microsoft.EntityFrameworkCore;
using ProductsAdministration.DAL.Data;
using ProductsAdministration.DAL.Models;
using ProductsAdministration.DAL.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAdministration.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product  = await GetProductById(id);
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Products.Entry(product).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
