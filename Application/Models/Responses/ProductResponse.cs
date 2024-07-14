using Domain.Entities;

namespace Application.Models.Responses
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }

        public static ProductResponse ToDto(Product product)
        {
            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Image = product.Image
            };
        }

        public static Product ToEntity(ProductResponse dto)
        {
            return new Product(dto.Name, dto.Description, dto.Price, dto.Stock, dto.Image);
        }

        public static List<ProductResponse> ToList(IEnumerable<Product> products)
        {
            var listProductDto = new List<ProductResponse>();
            foreach (var product in products)
            {
                listProductDto.Add(ToDto(product));
            }
            return listProductDto;
        }
    }
}
