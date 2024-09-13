using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/warehouseproducts")]
    [ApiController]
    public class WarehouseProductController : ControllerBase
    {
        private readonly IWarehouseProductService _warehouseProductService;

        public WarehouseProductController(IWarehouseProductService warehouseProductService)
        {
            _warehouseProductService = warehouseProductService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_warehouseProductService.GetAll());
        }
    }
}
