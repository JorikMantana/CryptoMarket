﻿using Microsoft.AspNetCore.Mvc;
using ProductsAdministration.BLL.DTO;
using ProductsAdministration.BLL.Services.IServices;

namespace ProductsAdministration.API.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ImageController : Controller
    {
        private IImageService _imageServie;

        public ImageController(IImageService imageServie)
        {
            _imageServie = imageServie;
        }

        [HttpPost]
        public async Task<ActionResult> AddImages(IEnumerable<IFormFile> images, int productId)
        {
            foreach (var image in images)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
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

            return Ok();
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<IEnumerable<ImageDto>>> GetImagesByProductId(int productId)
        {
            var images = await _imageServie.GetImagesByProductId(productId);

            return Ok(images);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteImage(int id)
        {
            await _imageServie.DeleteImage(id);

            return Ok();
        }
    }
}
