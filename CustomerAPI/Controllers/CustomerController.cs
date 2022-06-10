using System.Text.Json;
using CustomerAPI.Models;
using CustomerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly CustomerService _customerService;
        public CustomerController(ILogger<CustomerController> logger, CustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpPost]
        public Task<IActionResult> Post(Customer customer)
        {
            _customerService.Customers.Add(customer);
            return Task.FromResult<IActionResult>(Ok());
        }

        [HttpDelete(Name = "DeleteCustomerById")]
        public async Task<IActionResult> DeleteCustomerById(string Id)
        {
            var result = _customerService.DeleteUser(Convert.ToInt64(Id));

            if (!result) return BadRequest();
            var response = new ControllerResponse
            {
                Success = true
            };

            var jsonString = JsonSerializer.Serialize(response);
            return Ok(jsonString);

        }
    }
}
