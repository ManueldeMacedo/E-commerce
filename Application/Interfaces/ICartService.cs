using Application.Models.Dtos;
using Application.Models.Requests;
using Application.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
