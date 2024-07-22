using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class ProductCreateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Stock { get; set; }

        public string Image { get; set; }

        public static Product ToEntity(ProductCreateRequest dto)
        {
            return new Product(dto.Name, dto.Description, dto.Price, dto.Stock, dto.Image);
        }

        public static bool validateDto(ProductCreateRequest dto)
        {
            if (dto.Name == default ||
                dto.Price == default ||
                dto.Description == default ||
                dto.Stock == default)
                return false;

            return true;
        }
    }
}
