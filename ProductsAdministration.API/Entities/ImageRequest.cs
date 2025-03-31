using ProductsAdministration.BLL.DTO;

namespace ProductsAdministration.API.Entities;

public class ImageRequest
{
    public int ProductId { get; set; } //Id продукта, к которому относится изображение
    public IEnumerable<IFormFile> Images { get; set; } //Изображения
}