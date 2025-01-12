using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAdministration.BLL.DTO
{
    public class ImageDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; } //Id продукта, которому принадлежит изображение
        public string ImagePath { get; set; } //Путь к изображенеию
        public bool? isMainImage { get; set; } //Является ли изображение главным на странице продукта
    }
}
