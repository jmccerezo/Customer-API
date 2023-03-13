using AutoMapper;
using EvaluationAssignment.DTO.Customer;
using EvaluationAssignment.Models;
using EvaluationAssignment.Repository;

namespace EvaluationAssignment.Service
{
    public class CustomerService : ICustomerService
    {
        private IMapper _mapper;
        private ICustomerRepository _customerRepository;
        public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto> CreateCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepository.CreateCustomer(customer);
            return customerDto;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllCustomers();
            return customers;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            return customer;
        }

        public async Task<CustomerDto> UpdateCustomer(int id, CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepository.UpdateCustomer(id, customer);

            return customerDto;
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            var customer = await _customerRepository.DeleteCustomer(id);
            return customer;
        }
    }
}
