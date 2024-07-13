using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Interfaces;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ICollection<ProductDto> GetAllProducts()
        {
            var products = _productRepository.ListAsync().Result ?? throw new Exception("No se encontraron productos");
            return ProductDto.ToList(products);
        }

        public ProductDto GetProductById(int id)
        {
            var product = _productRepository.GetByIdAsync(id).Result ?? throw new Exception("No se encontró el producto");
            return ProductDto.ToDto(product);
        }

        public ProductDto CreateProduct(ProductCreateRequest dto)
        {
            var productEntity = ProductCreateRequest.ToEntity(dto);
            var product = _productRepository.AddAsync(productEntity).Result;
            return ProductDto.ToDto(product);
        }

        public void UpdateProduct(int id, ProductCreateRequest dto)
        {
            var product = _productRepository.GetByIdAsync(id).Result ?? throw new Exception("No se encontró el producto");
            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Description = dto.Description;
            product.Stock = dto.Stock;
            product.Image = dto.Image;
            _productRepository.UpdateAsync(product).Wait();
        }

        public void DeleteProduct(int id)
        {
            var product = _productRepository.GetByIdAsync(id).Result ?? throw new Exception("No se encontró el producto");
            _productRepository.DeleteAsync(product).Wait();
        }

        public ProductDto CreateProduct(ProductDto prod)
        {
            throw new NotImplementedException();
        }
    }
}

