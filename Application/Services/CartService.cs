using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CartService : ICartService
    {
        private readonly IRepositoryBase<Cart> _baseRepository;
        private readonly ICartRepository _cartRepository;

        public CartService(IRepositoryBase<Cart> repositoryBase, ICartRepository cartRepository2)
        {
            _baseRepository = repositoryBase;
            _cartRepository = cartRepository2;
        }

        public ICollection<CartResponse> GetAllCarts()
        {
            var carts = _cartRepository.ListAsync().Result ?? throw new KeyNotFoundException("No se encontraron carritos");
            return CartResponse.ToDtoList(carts);
        }

        public CartResponse GetCartById(int id)
        {
            var cart = _cartRepository.GetByIdAsync(id).Result ?? throw new KeyNotFoundException("No se encontró el carrito");
            return CartResponse.ToDto(cart);
        }

        public CartResponse CreateCart(CartCreateRequest dto)
        {
            var cartEntity = CartCreateRequest.ToEntity(dto);
            var cart = _baseRepository.AddAsync(cartEntity).Result;
            return CartResponse.ToDto(cart);
        }

        public void UpdateCart(int id, CartCreateRequest dto)
        {
            var cart = _cartRepository.GetByIdAsync(id).Result ?? throw new KeyNotFoundException("No se encontró el carrito");
            cart.UserId = dto.UserId;
            cart.Order = dto.Order;
            cart.AmountProduct = dto.AmountProduct;
            cart.CartProducts = dto.CartListParser(dto.Products);
            cart.TotalPrice = dto.TotalPrice;
            cart.TypePayment = dto.TypePayment;
            _baseRepository.UpdateAsync(cart).Wait();
        }

        public void DeleteCart(int id)
        {
            var cart = _baseRepository.GetByIdAsync(id).Result ?? throw new KeyNotFoundException("No se encontró el carrito");
            _baseRepository.DeleteAsync(cart).Wait();
        }
    }
}
