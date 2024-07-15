using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
                var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadToken(token) as JwtSecurityToken;
                var role = jwtToken?.Claims.FirstOrDefault(claim => claim.Type == "role")?.Value;

                if (role != "Admin")
                {
                    return Unauthorized("You do not have access to this resource.");
                }

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
