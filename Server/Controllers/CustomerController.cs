using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Dtos;

namespace Server.Controllers
{
    [Route("api/customers")]
    [ApiController]
    [Tags("Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ISalesInvoiceService _salesInvoiceService;

        public CustomerController(ICustomerService customerService, ISalesInvoiceService salesInvoiceService)
        {
            _customerService = customerService;
            _salesInvoiceService = salesInvoiceService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDTO>> GetCustomers()
        {
            return Ok(_customerService.GetAll());
        }

        [HttpGet("{customerId:int}/saleinvoices")]
        public ActionResult<IEnumerable<CustomerDTO>> GetSalesByCustomerId(int customerId)
        {
            return Ok(_salesInvoiceService.GetSalesByCustomerId(customerId));
        }

        [HttpGet("{customerId:int}")]
        public ActionResult<CustomerDTO> GetCustomerById(int customerId)
        {
            try
            {
                return _customerService.GetById(customerId);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("byname/{customerName}")]
        public ActionResult<CustomerDTO> GetCustomerByName(string customerName)
        {
            try
            {
                return _customerService.GetByName(customerName);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost(Name = "CreateCustomer")]
        public ActionResult CreateCustomer([FromBody] CustomerInputDTO customer)
        {
            _customerService.Create(customer);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{customerId:int}")]
        public ActionResult UpdateCustomer(int customerId, [FromBody] CustomerInputDTO customer)
        {
            try
            {
                _customerService.Update(customerId, customer);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{customerId:int}")]
        public ActionResult DeleteCustomer(int customerId)
        {
            try
            {
                _customerService.Delete(customerId);
                return Ok();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
