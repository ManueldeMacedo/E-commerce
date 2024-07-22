using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using static Infrastructure.Services.AutenticacionService;

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

        [AuthorizeRoles("Admin")]
        [HttpGet]
        public ActionResult<IEnumerable<CartResponse>> GetAllCarts()
        {
            try
            {
                var carts = _cartService.GetAllCarts();
                return Ok(carts);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ha ocurrido un error inesperado. Error: " + ex.Message);
            }
        }

        [AuthorizeRoles("Admin", "Client")]
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
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ha ocurrido un error inesperado. Error: " + ex.Message);
            }
        }

        [AuthorizeRoles("Admin", "Client")]
        [HttpPost]
        public ActionResult<CartResponse> CreateCart([FromBody] CartCreateRequest cartDto)
        {
            try
            {
                if (!CartCreateRequest.validateDto(cartDto))
                    return BadRequest("La solicitud no es válida." +
                        " Verifica que todos los campos requeridos estén presentes y contengan valores adecuados.");

                var createdCart = _cartService.CreateCart(cartDto);
                return Ok(createdCart);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ha ocurrido un error inesperado. Error: " + ex.Message);
            }
        }

        [AuthorizeRoles("Admin", "Client")]
        [HttpPut("{id}")]
        public IActionResult UpdateCart(int id, [FromBody] CartCreateRequest cartDto)
        {
            try
            {
                if (!CartCreateRequest.validateDto(cartDto))
                    return BadRequest("La solicitud no es válida." +
                        " Verifica que todos los campos requeridos estén presentes y contengan valores adecuados.");

                _cartService.UpdateCart(id, cartDto);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ha ocurrido un error inesperado. Error: " + ex.Message);
            }
        }

        [AuthorizeRoles("Admin", "Client")]
        [HttpDelete("{id}")]
        public IActionResult DeleteCart(int id)
        {
            try
            {
                _cartService.DeleteCart(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ha ocurrido un error inesperado. Error: " + ex.Message);
            }
        }
    }
}
