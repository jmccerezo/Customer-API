using EvaluationAssignment.Models;

namespace EvaluationAssignment.Repository
{
    public interface ICustomerRepository
    {
        Task CreateCustomer(Customer customer);
        Task <List<Customer>>GetAllCustomers();
        Task <Customer> GetCustomerById(int id);
        Task<Customer> UpdateCustomer(int id, Customer customer);
        Task<Customer> DeleteCustomer(int id);
    }
}