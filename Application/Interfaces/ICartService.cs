using Application.Models.Requests;
using Application.Models.Responses;

namespace Application.Interfaces
{
    public interface ICartService
    {
        ICollection<CartResponse> GetAllCarts();
        CartResponse GetCartById(int id);
        CartResponse CreateCart(CartCreateRequest dto);
        void UpdateCart(int id, CartCreateRequest dto);
        void DeleteCart(int id);
    }
}
