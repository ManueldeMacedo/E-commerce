using Domain.Entities;

namespace Application.Models.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }

        public static ProductDto ToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Image = product.Image
            };
        }

        public static Product ToEntity(ProductDto dto)
        {
            return new Product(dto.Name, dto.Description, dto.Price, dto.Stock, dto.Image);
        }

        public static List<ProductDto> ToList(IEnumerable<Product> products)
        {
            var listProductDto = new List<ProductDto>();
            foreach (var product in products)
            {
                listProductDto.Add(ToDto(product));
            }
            return listProductDto;
        }
    }
}
