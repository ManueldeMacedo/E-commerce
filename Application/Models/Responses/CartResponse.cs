using Application.Models.Dtos;
using Domain.Entities;
using Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Application.Models.Responses
{
    public class CartResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Order { get; set; }
        public int AmountProduct { get; set; }
        public ICollection<CartProductDto> Products { get; set; } = new List<CartProductDto>();
        public double TotalPrice { get; set; }
        public TypePayment TypePayment { get; set; }

        public static CartResponse ToDto(Cart cart)
        {
            return new CartResponse
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Order = cart.Order,
                AmountProduct = cart.AmountProduct,
                Products = CartProductListParser(cart.CartProducts ?? new List<CartProduct>()),
                TotalPrice = cart.TotalPrice,
                TypePayment = cart.TypePayment
            };
        }

        public static ICollection<CartResponse> ToDtoList(IEnumerable<Cart> carts)
        {
            return carts.Select(cart => new CartResponse
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Order = cart.Order,
                AmountProduct = cart.AmountProduct,
                Products = CartProductListParser(cart.CartProducts ?? new List<CartProduct>()),
                TotalPrice = cart.TotalPrice,
                TypePayment = cart.TypePayment
            }).ToList();
        }

        private static List<CartProductDto> CartProductListParser(ICollection<CartProduct> Products)
        {
            return Products.Select(p => new CartProductDto
            {
                ProductId = p.ProductId,
                Quantity = p.Quantity
            }).ToList();
        }
    }
}
