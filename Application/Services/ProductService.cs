using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Application.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductDto CreateProduct(ProductDto prod)
        {
            Product product2 = new Product(prod.Name, prod.Description, prod.Price, prod.Stock, prod.Image);
            var product = _productRepository.CreateProduct(product2);
            return ProductDto.Create(product);
        }


    }
}
