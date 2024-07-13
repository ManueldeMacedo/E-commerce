using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Application.Models.Dtos;
using Application.Models.Responses;
using Application.Models.Requests;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CartResponse>> GetAllCarts()
        {
            try
            {
                var carts = _cartService.GetAllCarts();
                return Ok(carts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<CartResponse> GetCartById(int id)
        {
            try
            {
                var cart = _cartService.GetCartById(id);
                if (cart == null)
                {
                    return NotFound();
                }
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<CartResponse> CreateCart([FromBody] CartCreateRequest cartDto)
        {
            try
            {
                var createdCart = _cartService.CreateCart(cartDto);
                return Ok(createdCart);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public void UpdateCart(int id, [FromBody] CartCreateRequest cartDto)
        {
            _cartService.UpdateCart(id, cartDto);
            NoContent();
        }

        [HttpDelete("{id}")]
        public void DeleteCart(int id)
        {
            _cartService.DeleteCart(id);
            NoContent();
        }
    }
}
