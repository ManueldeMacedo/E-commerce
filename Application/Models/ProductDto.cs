using Domain.Entities;
using System;

namespace Application.Models
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }

        public static ProductDto Create(Product product)
        {
            var dto = new ProductDto();
            dto.Name = product.Name;
            dto.Description = product.Description;
            dto.Price = product.Price;
            dto.Stock = product.Stock;
            dto.Image = product.Image;

            return dto;
        }
    }
}
