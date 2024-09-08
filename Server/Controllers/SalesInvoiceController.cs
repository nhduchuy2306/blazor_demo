using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Dtos;

namespace Server.Controllers
{
    [Route("api/salesinvoices")]
    [ApiController]
    [Tags("Sales Invoice")]
    public class SalesInvoiceController : ControllerBase
    {
        private readonly ISalesInvoiceService _salesInvoiceService;

        public SalesInvoiceController(ISalesInvoiceService salesInvoiceService)
        {
            _salesInvoiceService = salesInvoiceService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SalesInvoiceDTO>> GetSalesInvoices()
        {
            var salesInvoices = _salesInvoiceService.GetAll();
            return Ok(salesInvoices);
        }

        [HttpGet("{salesInvoiceId:int}")]
        public ActionResult<SalesInvoiceDTO> GetSalesInvoiceById(int salesInvoiceId)
        {
            try
            {
                var salesInvoice = _salesInvoiceService.GetById(salesInvoiceId);
                return Ok(salesInvoice);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{salesInvoiceId:int}/invoicedetails")]
        public ActionResult<SalesInvoiceDTO> GetInvoiceDetailByInvoiceId(int salesInvoiceId)
        {
            try
            {
                var salesInvoice = _salesInvoiceService.GetInvoiceDetailsByInvoiceId(salesInvoiceId);
                return Ok(salesInvoice);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateSalesInvoice([FromBody] SalesInvoiceInputDTO salesInvoice)
        {
            _salesInvoiceService.Create(salesInvoice);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{salesInvoiceId:int}")]
        public ActionResult UpdateSalesInvoice(int salesInvoiceId, [FromBody] SalesInvoiceInputDTO salesInvoice)
        {
            try
            {
                _salesInvoiceService.Update(salesInvoiceId, salesInvoice);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{salesInvoiceId:int}")]
        public ActionResult DeleteSalesInvoice(int salesInvoiceId)
        {
            try
            {
                _salesInvoiceService.Delete(salesInvoiceId);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
