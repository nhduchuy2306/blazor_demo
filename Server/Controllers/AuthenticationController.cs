using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Dtos;
using ServerLibrary.Services;

namespace Server.Controllers
{
    [Route("api/authens")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public AuthenticationController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public IActionResult Login(AuthenticationDTO authenticationDTO)
        {
            try
            {
                var authenticationOutputDTO = _customerService.Login(authenticationDTO);
                return Ok(authenticationOutputDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
