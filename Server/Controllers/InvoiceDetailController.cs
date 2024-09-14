using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Dtos;
using ServerLibrary.Services;

namespace Server.Controllers
{
    [Route("api/invoicedetails")]
    [ApiController]
    [Tags("Invoice Detail")]
    public class InvoiceDetailController : ControllerBase
    {
        private readonly IInvoiceDetailService _invoiceDetailService;

        public InvoiceDetailController(IInvoiceDetailService invoiceDetailService)
        {
            _invoiceDetailService = invoiceDetailService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<InvoiceDetailDTO>> GetInvoiceDetails()
        {
            var invoiceDetails = _invoiceDetailService.GetAll();
            return Ok(invoiceDetails);
        }

        [HttpGet("{invoiceDetailId:int}")]
        public ActionResult<InvoiceDetailDTO> GetInvoiceDetailById(int invoice)
        {
            try
            {
                return _invoiceDetailService.GetById(invoice);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateInvoiceDetail([FromBody] InvoiceDetailInputDTO invoiceDetail)
        {
            _invoiceDetailService.Create(invoiceDetail);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{invoiceDetailId:int}")]
        public ActionResult UpdateInvoiceDetail(int invoiceDetailId, [FromBody] InvoiceDetailInputDTO invoiceDetail)
        {
            try
            {
                _invoiceDetailService.Update(invoiceDetailId, invoiceDetail);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{invoiceDetailId:int}")]
        public ActionResult DeleteInvoiceDetail(int invoiceDetailId)
        {
            try
            {
                _invoiceDetailService.Delete(invoiceDetailId);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
