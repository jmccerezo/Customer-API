using EvaluationAssignment.DTO.Customer;
using EvaluationAssignment.Models;
using EvaluationAssignment.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationAssignment.Controllers
{
    [Route("api/customers/")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;
        /*private readonly ILogger<CustomerController> _logger;
        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }*/

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        //POST
        [HttpPost]
        public async Task <ActionResult<Customer>> CreateCustomer(CustomerDto customerDto)
        {
            /*_logger.LogInformation("Create Customer");*/
            var newCustomer = await _customerService.CreateCustomer(customerDto);
            if(newCustomer != null)
                return Created("/", newCustomer);

            return BadRequest();
        }

        //GET
        [HttpGet]
        public async Task<ActionResult<Customer>> GetAllCustomers()
        {
            /*_logger.LogInformation("Get all customers");*/
            var customers = await _customerService.GetAllCustomers();

            if (customers == null)
                throw new KeyNotFoundException("Error fetching customers data!");

            return Ok(customers);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            /*_logger.LogInformation("Get customer by id");*/
            var customer = await _customerService.GetCustomerById(id);

            if (customer == null)
                throw new KeyNotFoundException("Customer not found");

            return Ok(customer);
        }

        //PUT
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Customer>> UpdateCustomer(int id, CustomerDto customerDto)
        {
            /*_logger.LogInformation("Update customer");*/
            var updateCustomer = await _customerService.UpdateCustomer(id, customerDto);
            if (updateCustomer == null)
                throw new KeyNotFoundException("Update failed! Customer not found");

            return Ok(updateCustomer);
        }

        //DELETE
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            /*_logger.LogInformation("Delete customer");*/
            var deleteCustomer = await _customerService.DeleteCustomer(id);

            if (deleteCustomer == null)
                throw new KeyNotFoundException("Delete failed! Customer not found");

            return Ok(deleteCustomer);
        }
    }
}
