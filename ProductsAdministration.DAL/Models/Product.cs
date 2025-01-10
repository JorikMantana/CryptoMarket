using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAdministration.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; } //Название продукта
        public string Description { get; set; } //Описание продукта
        public int Price { get; set; } //Цена продукта
    }
}
