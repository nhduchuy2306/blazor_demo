using Microsoft.AspNetCore.Authorization;
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
    }
}
