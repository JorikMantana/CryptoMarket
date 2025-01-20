using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult> AddImages(IEnumerable<IFormFile> images, int productId)
        {
            if (images == null || !images.Any())
            {
                return BadRequest("No images provided.");
            }

            foreach (var image in images)
            {
                try
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
                        ProductId = productId,
                        ImagePath = relativePath
                    };

                    await _imageServie.AddImage(imageDto);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
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
