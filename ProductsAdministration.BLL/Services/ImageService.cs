using Mapster;
using ProductsAdministration.BLL.DTO;
using ProductsAdministration.BLL.Services.IServices;
using ProductsAdministration.DAL.Models;
using ProductsAdministration.DAL.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAdministration.BLL.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task AddImage(ImageDto imageDto)
        {
            var image = imageDto.Adapt<Image>();

            await _imageRepository.AddImage(image);
        }

        public async Task DeleteImage(int id)
        {
            await _imageRepository.DeleteImage(id);
        }

        public async Task<IEnumerable<ImageDto>> GetImagesByProductId(int productId)
        {
            var images = await _imageRepository.GetImagesByProductId(productId);

            return images.Adapt<IEnumerable<ImageDto>>();
        }
    }
}
