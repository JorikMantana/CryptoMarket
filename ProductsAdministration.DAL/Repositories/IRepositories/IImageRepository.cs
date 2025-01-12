using ProductsAdministration.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAdministration.DAL.Repositories.IRepositories
{
    public interface IImageRepository
    {
        public Task AddImage(Image image);
        public Task<IEnumerable<Image>> GetImagesByProductId(int productId);
        public Task DeleteImage(int id);
        
    }
}
