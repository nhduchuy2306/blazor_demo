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

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
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
                return _warehouseService.GetById(warehouseId);
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
