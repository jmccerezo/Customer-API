using EvaluationAssignment.DTO.Customer;
using EvaluationAssignment.Models;

namespace EvaluationAssignment.Service
{
    public interface ICustomerService
    {
        Task<CustomerDto> CreateCustomer(CustomerDto customerDto);
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<CustomerDto> UpdateCustomer(int id, CustomerDto customerDto);
        Task<Customer> DeleteCustomer(int id);
    }
}