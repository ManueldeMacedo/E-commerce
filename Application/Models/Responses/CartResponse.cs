using Application.Models.Dtos;
using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Responses
{
    public class CartResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Order { get; set; }
        public int AmountProduct { get; set; }
        public ICollection<CartProductDto>? Products { get; set; }
        public double TotalPrice { get; set; }
        public TypePayment typePayment { get; set; }

        public static CartResponse ToDto(Cart cart)
        {
            return new CartResponse
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Order = cart.Order,
                AmountProduct = cart.AmountProduct,
                Products = CartProductListParser(cart.CartProducts),
                TotalPrice = cart.TotalPrice,
                typePayment = cart.TypePayment
            };
        }

        public static List<CartResponse> ToList(IEnumerable<Cart> carts)
        {
            var listCartResponse = new List<CartResponse>();
            foreach (var cart in carts)
            {
                listCartResponse.Add(ToDto(cart));
            }
            return listCartResponse;
        }

        public static ICollection<CartProductDto> CartProductListParser(ICollection<CartProduct> Products)
        {
            var cartProductsDto = Products.Select(p => new CartProductDto
            {
                ProductId = p.ProductId,
                Quantity = p.Quantity
            }).ToList();

            return cartProductsDto;
        }
    }
}
