using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Dtos;

namespace Server.Controllers
{
    [Route("api/warehouses")]
    [ApiController]
    [Tags("Warehouse")]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;
        private readonly IWarehouseProductService _warehouseProductService;

        public WarehouseController(IWarehouseService warehouseService, IWarehouseProductService warehouseProductService)
        {
            _warehouseService = warehouseService;
            _warehouseProductService = warehouseProductService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WarehouseDTO>> GetWarehouses()
        {
            return Ok(_warehouseService.GetAll());
        }

        [HttpGet("{warehouseId:int}")]
        public ActionResult<WarehouseDTO> GetWarehouseById(int warehouseId)
        {
            try
            {
                return Ok(_warehouseService.GetById(warehouseId));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{warehouseId:int}/products")]
        public ActionResult<IEnumerable<WarehouseProductDTO>> GetProductsByWarehouseId(int warehouseId)
        {
            try
            {
                return Ok(_warehouseProductService.GetProductsByWarehouseId(warehouseId));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateWarehouse([FromBody] WarehouseInputDTO warehouse)
        {
            _warehouseService.Create(warehouse);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{warehouseId:int}")]
        public ActionResult UpdateWarehouse(int warehouseId, [FromBody] WarehouseInputDTO warehouse)
        {
            try
            {
                _warehouseService.Update(warehouseId, warehouse);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{warehouseId:int}")]
        public ActionResult DeleteWarehouse(int warehouseId)
        {
            try
            {
                _warehouseService.Delete(warehouseId);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
