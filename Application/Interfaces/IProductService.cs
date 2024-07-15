using Application.Models.Requests;
using Application.Models.Responses;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IProductService
    {
        ICollection<ProductResponse> GetAllProducts();
        ProductResponse GetProductById(int id);
        ProductResponse CreateProduct(ProductCreateRequest dto);
        void UpdateProduct(int id, ProductCreateRequest dto);
        void DeleteProduct(int id);
        bool IsProductInStock(int id);
        IEnumerable<ProductResponse> SearchProductsByName(string searchTerm);
    }
}
