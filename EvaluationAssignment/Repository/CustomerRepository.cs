using EvaluationAssignment.DTO.Customer;
using EvaluationAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace EvaluationAssignment.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private EvaluationAssignmentContext _dbContext;
        public CustomerRepository(EvaluationAssignmentContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateCustomer(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _dbContext.Customers.SingleOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task<Customer> UpdateCustomer(int id, Customer customer)
        {
            var data = await _dbContext.Customers.SingleOrDefaultAsync(c => c.CustomerId == id);
            data.CustomerName = customer.CustomerName;
            data.Address = customer.Address;
            data.CustomerType = customer.CustomerType;
            data.Mobile = customer.Mobile;
            await _dbContext.SaveChangesAsync();

            return data;
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            var customer = await _dbContext.Customers.SingleOrDefaultAsync(c => c.CustomerId==id);
            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();

            return customer;
        }
    }
}
