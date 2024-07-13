﻿using Application.Models.Dtos;
using Application.Models.Requests;

namespace Application.Interfaces
{
    public interface IProductService
    {
        ICollection<ProductDto> GetAllProducts();
        ProductDto GetProductById(int id);
        ProductDto CreateProduct(ProductCreateRequest dto);
        void UpdateProduct(int id, ProductCreateRequest dto);
        void DeleteProduct(int id);
    }
}