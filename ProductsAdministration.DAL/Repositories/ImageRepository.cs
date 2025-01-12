using ProductsAdministration.DAL.Models;
using ProductsAdministration.DAL.Repositories.IRepositories;
using ProductsAdministration.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductsAdministration.DAL.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext _context;

        public ImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddImage(Image image)
        {
            await _context.Images.AddAsync(image);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteImage(int id)
        {
            var image = _context.Images.FirstOrDefault(x => x.Id == id);
            _context.Images.Remove(image);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Image>> GetImagesByProductId(int productId)
        {
            return await _context.Images
                .Where(x => x.ProductId == productId)
                .ToListAsync();
        }
    }
}
