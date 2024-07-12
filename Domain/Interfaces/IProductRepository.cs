using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product product);
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> ListAsync();
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
