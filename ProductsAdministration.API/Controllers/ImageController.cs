using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsAdministration.API.Entities;
using ProductsAdministration.BLL.DTO;
using ProductsAdministration.BLL.Services.IServices;

namespace ProductsAdministration.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ImageController : Controller
    {
        private IImageService _imageServie;

        public ImageController(IImageService imageServie)
        {
            _imageServie = imageServie;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddImages(ImageRequest imageRequest)
        {
            foreach (var image in imageRequest.Images)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName; 
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                string relativePath = $"/Images/{uniqueFileName}";

                var imageDto = new ImageDto
                {
                    ProductId = imageRequest.ProductId,
                    ImagePath = relativePath
                };

                await _imageServie.AddImage(imageDto);
            }

            return Ok();
        }


        [HttpGet("{productId}")]
        public async Task<ActionResult<IEnumerable<ImageDto>>> GetImagesByProductId(int productId)
        {
            var images = await _imageServie.GetImagesByProductId(productId);

            return Ok(images);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteImage(int id)
        {
            await _imageServie.DeleteImage(id);

            return Ok();
        }
    }
}
