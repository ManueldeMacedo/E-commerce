using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CartService : ICartService
    {
        private readonly IRepositoryBase<Cart> _cartRepository;

        public CartService(IRepositoryBase<Cart> repositoryBase)
        {
            _cartRepository = repositoryBase;
        }

        public ICollection<CartResponse> GetAllCarts()
        {
            var carts = _cartRepository.ListAsync().Result ?? throw new Exception("No se encontraron carritos");
            return CartResponse.ToList(carts);
        }

        public CartResponse GetCartById(int id)
        {
            var cart = _cartRepository.GetByIdAsync(id).Result ?? throw new Exception("No se encontró el carrito");
            return CartResponse.ToDto(cart);
        }

        public CartResponse CreateCart(CartCreateRequest dto)
        {
            var cartEntity = CartCreateRequest.ToEntity(dto);
            var cart = _cartRepository.AddAsync(cartEntity).Result;
            return CartResponse.ToDto(cart);
        }

        public void UpdateCart(int id, CartCreateRequest dto)
        {
            var cart = _cartRepository.GetByIdAsync(id).Result ?? throw new Exception("No se encontró el carrito");
            cart.UserId = dto.UserId;
            cart.Order = dto.Order;
            cart.AmountProduct = dto.AmountProduct;
            cart.CartProducts = dto.CartListParser(dto.Products);
            cart.TotalPrice = dto.TotalPrice;
            cart.TypePayment = dto.TypePayment;
            _cartRepository.UpdateAsync(cart).Wait();
        }

        public void DeleteCart(int id)
        {
            var cart = _cartRepository.GetByIdAsync(id).Result ?? throw new Exception("No se encontró el carrito");
            _cartRepository.DeleteAsync(cart).Wait();
        }
    }
}
