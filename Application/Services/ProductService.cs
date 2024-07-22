﻿using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ICollection<ProductResponse> GetAllProducts()
        {
            var products = _productRepository.ListAsync().Result ?? throw new KeyNotFoundException("No se encontraron productos");
            return ProductResponse.ToList(products);
        }

        public ProductResponse GetProductById(int id)
        {
            var product = _productRepository.GetByIdAsync(id).Result ?? throw new KeyNotFoundException("No se encontró el producto");
            return ProductResponse.ToDto(product);
        }

        public ProductResponse CreateProduct(ProductCreateRequest dto)
        {
            var product = _productRepository.AddAsync(ProductCreateRequest.ToEntity(dto)).Result;
            return ProductResponse.ToDto(product);
        }

        public void UpdateProduct(int id, ProductCreateRequest dto)
        {
            var existingProduct = _productRepository.GetByIdAsync(id).Result ?? throw new KeyNotFoundException("No se encontró el producto");

            existingProduct.Name = dto.Name;
            existingProduct.Description = dto.Description;
            existingProduct.Price = dto.Price;
            existingProduct.Stock = dto.Stock;
            existingProduct.Image = dto.Image;

            _productRepository.UpdateAsync(existingProduct).Wait();
        }

        public void DeleteProduct(int id)
        {
            var product = _productRepository.GetByIdAsync(id).Result ?? throw new KeyNotFoundException("No se encontró el producto");
            _productRepository.DeleteAsync(product);
        }

        public bool IsProductInStock(int id)
        {
            var product = _productRepository.GetByIdAsync(id).Result ?? throw new KeyNotFoundException("No se encontró el producto");
            return product.Stock > 0;
        }

        public IEnumerable<ProductResponse> SearchProductsByName(string searchTerm)
        {
            var products = _productRepository.ListAsync().Result ?? throw new KeyNotFoundException("No se encontraron productos");

            if (string.IsNullOrEmpty(searchTerm))
            {
                return products.Select(ProductResponse.ToDto);
            }

            searchTerm = searchTerm.ToLower();
            return products.Where(p => p.Name.ToLower().Contains(searchTerm)).Select(ProductResponse.ToDto);
        }
    }
}
