using Application.Models.Dtos;
using Domain.Entities;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class CartCreateRequest
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public int AmountProduct { get; set; }

        [Required]
        public ICollection<CartProductDto> Products { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [Required]
        public TypePayment TypePayment { get; set; }

        public static Cart ToEntity(CartCreateRequest dto)
        {
            var cartProducts = dto.CartListParser(dto.Products);

            return new Cart(dto.UserId, dto.Order, dto.AmountProduct, cartProducts, dto.TotalPrice, dto.TypePayment);
        }

        public ICollection<CartProduct> CartListParser(ICollection<CartProductDto> Products)
        {
            var cartProducts = Products.Select(p => new CartProduct
            {
                ProductId = p.ProductId,
                Quantity = p.Quantity
            }).ToList();

            return cartProducts;
        }
    }
}
