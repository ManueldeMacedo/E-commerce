using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> ListAsync();
        Task<Cart?> GetByIdAsync(int id);
    }
}
