using Moq;
using EvaluationAssignment.Service;
using EvaluationAssignment.DTO.Customer;
using EvaluationAssignment.Models;
using EvaluationAssignment.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiTest
{
    public class CrudApiTest
    {
        private Mock<ICustomerService> customerService;
        public CrudApiTest()
        {
            customerService = new Mock<ICustomerService>();
        }
        public List<Customer> createCustomerList()
        {
            List<Customer> customerTable = new List<Customer>()
            {
                new Customer()
                {
                    CustomerId = 1,
                    CustomerName = "John",
                    Address = "Philippines",
                    Mobile = 1234567890,
                    CustomerType = 1
                },
                new Customer()
                {
                    CustomerId = 2,
                    CustomerName = "Jessie",
                    Address = "Philippines",
                    Mobile = 1234567890,
                    CustomerType = 2
                }
            };

            return customerTable;
        }
        public CustomerDto createCustomerDto()
        {
            CustomerDto customerDto = new CustomerDto()
            {
                CustomerName = "John",
                Address = "Philippines",
                Mobile = 1234567890,
                CustomerType = 1
            };

            return customerDto;
        }

        //POST: api/customers
        [Fact]
        public void CreateCustomer_ReturnsNotNull()
        {
            //Arrange
            var customer = createCustomerDto();
            customerService.Setup(x => x.CreateCustomer(customer)).Returns(Task.Run(() => customer));

            var customerController = new CustomerController(customerService.Object);

            //Act
            var result = customerController.CreateCustomer(customer);

            //Assert
            Assert.NotNull(result);
        }

        //GET: api/customers
        [Fact]
        public void GetAllCustomers_ReturnsNotNull()
        {
            //Arrange
            var customerList = createCustomerList();
            customerService.Setup(x => x.GetAllCustomers()).Returns(Task.Run(() => customerList));

            var customerController = new CustomerController(customerService.Object);

            //Act
            var result = customerController.GetAllCustomers();

            //Assert
            Assert.NotNull(result);
        }

        //GET: api/customers/{id:int}
        [Fact]
        public void GetCustomerById_ReturnsNotNull()
        {
            //Arrange
            int id = 1;
            var customerList = createCustomerList();
            customerService
                .Setup(x => x.GetCustomerById(id))
                .Returns(Task.Run(() => customerList
                .SingleOrDefault(c => c.CustomerId == id)));

            var customerController = new CustomerController(customerService.Object);

            //Act
            var result = customerController.GetCustomerById(id);

            //Assert
            Assert.NotNull(result);
        }

        //PUT: api/customers/{id:int}
        [Fact]
        public void UpdateCustomer_ReturnsNotNull()
        {
            //Arrange
            int id = 1;
            var customerList = createCustomerList();
            customerService
                .Setup(x => x.GetCustomerById(id))
                .Returns(Task.Run(()=>customerList
                .SingleOrDefault(c => c.CustomerId == id)));

            var updateInfo = new CustomerDto()
            {
                CustomerName = "Juan",
                Address = "Mexico",
                Mobile = 0987654321,
                CustomerType = 2
            };

            var customerController = new CustomerController(customerService.Object);

            //Act
            var result = customerController.UpdateCustomer(id, updateInfo);

            //Assert
            Assert.NotNull(result);
        }

        //DELETE: api/customers/{id:int}
        [Fact]
        public void DeleteCustomer_ReturnsNotNull()
        {
            //Arrange
            int id = 1;
            var customerList = createCustomerList();
            customerService
                .Setup(x => x.GetCustomerById(id))
                .Returns(Task.Run(() => customerList
                .SingleOrDefault(c => c.CustomerId == id)));

            var customerController = new CustomerController(customerService.Object);

            //Act
            var result = customerController.DeleteCustomer(id);

            //Assert
            Assert.NotNull(result);
        }
    }
}