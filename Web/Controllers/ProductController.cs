using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Application.Services;
using Microsoft.AspNetCore.Mvc;


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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<ProductResponse> CreateProduct([FromBody] ProductCreateRequest productDto)
        {
            try
            {
                var createdProduct = _productService.CreateProduct(productDto);
                return Ok(createdProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public void UpdateProduct(int id, [FromBody] ProductCreateRequest productDto)
        {
                 _productService.UpdateProduct(id, productDto);
                NoContent();
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
                _productService.DeleteProduct(id);
                NoContent();
        }
    }
}
