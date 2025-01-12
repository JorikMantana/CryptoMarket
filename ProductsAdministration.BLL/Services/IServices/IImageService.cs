using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsAdministration.BLL.DTO;

namespace ProductsAdministration.BLL.Services.IServices
{
    public interface IImageService
    {
        public Task AddImage(ImageDto imageDto);
        public Task<IEnumerable<ImageDto>> GetImagesByProductId(int productId);
        public Task DeleteImage(int id);
    }
}
