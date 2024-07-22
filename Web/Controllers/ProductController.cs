using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Infrastructure.Services.AutenticacionService;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductResponse>> GetAllProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();
                return Ok(products);
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

        [HttpGet("{id}")]
        public ActionResult<ProductResponse> GetProductById(int id)
        {
            try
            {
                var product = _productService.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
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

        [AuthorizeRoles("Admin")]
        [HttpPost]
        public ActionResult<ProductResponse> CreateProduct([FromBody] ProductCreateRequest productDto)
        {
            try
            {
                var createdProduct = _productService.CreateProduct(productDto);
                return Ok(createdProduct);
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid("Acceso denegado. No tiene los permisos necesarios.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ha ocurrido un error inesperado. Error: " + ex.Message);
            }
        }

        [AuthorizeRoles("Admin", "Client")]
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, [FromBody] ProductCreateRequest productDto)
        {
            try
            {
                _productService.UpdateProduct(id, productDto);
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

        [AuthorizeRoles("Admin")]
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid("Acceso denegado. No tiene los permisos necesarios.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ha ocurrido un error inesperado. Error: " + ex.Message);
            }
        }

        [HttpGet("{id}/stock")]
        public ActionResult CheckStock(int id)
        {
            try
            {
                var product = _productService.GetProductById(id);
                bool inStock = _productService.IsProductInStock(id);

                if (inStock)
                {
                    return Ok($"El producto '{product.Name}' posee stock disponible.");
                }
                else
                {
                    return Ok($"El producto '{product.Name}' se encuentra agotado.");
                }
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

        [HttpGet("search")]
        public ActionResult<IEnumerable<ProductResponse>> SearchProducts([FromQuery] string searchTerm)
        {
            try
            {
                var products = _productService.SearchProductsByName(searchTerm);
                return Ok(products);
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
