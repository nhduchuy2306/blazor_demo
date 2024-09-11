using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Dtos;

namespace Server.Controllers
{
    [Route("api/products")]
    [ApiController]
    [Tags("Product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IWarehouseProductService _warehouseProductService;

        public ProductController(IProductService productService, IWarehouseProductService warehouseProductService)
        {
            _productService = productService;
            _warehouseProductService = warehouseProductService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{productId:int}")]
        public ActionResult<ProductDTO> GetProductById(int productId)
        {
            try
            {
                var product = _productService.GetById(productId);
                return Ok(product);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{productId:int}/warehouses")]
        public ActionResult<IEnumerable<WarehouseProductDTO>> GetWarehousesByProductId(int productId)
        {
            try
            {
                var product = _warehouseProductService.GetWarehousesByProductId(productId);
                return Ok(product);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("byname/{productName}")]
        public ActionResult<ProductDTO> GetProductByName(string productName)
        {
            try
            {
                var product = _productService.GetByName(productName);
                return Ok(product);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateProduct([FromBody] ProductInputDTO product)
        {
            _productService.Create(product);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{productId:int}")]
        public ActionResult UpdateProduct(int productId, [FromBody] ProductInputDTO product)
        {
            try
            {
                _productService.Update(productId, product);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{productId:int}")]
        public ActionResult DeleteProduct(int productId)
        {
            try
            {
                _productService.Delete(productId);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
