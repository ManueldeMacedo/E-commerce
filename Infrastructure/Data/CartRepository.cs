using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Infrastructure.Data
{
    public class CartRepository : EfRepository<Cart>, ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cart>> ListAsync()
        {
            return await _context.Carts
                                 .Include(c => c.CartProducts)
                                 .ThenInclude(cp => cp.Product)
                                 .ToListAsync();
        }

        public async Task<Cart?> GetByIdAsync(int id)
        {
            return await _context.Carts
                                 .Include(c => c.CartProducts)
                                 .ThenInclude(cp => cp.Product)
                                 .FirstOrDefaultAsync(c => c.Id == id);
        }

    }
}
