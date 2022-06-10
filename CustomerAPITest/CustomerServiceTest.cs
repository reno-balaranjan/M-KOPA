using System.Collections.Generic;
using CustomerAPI.Models;
using CustomerAPI.Services;
using Moq;
using NUnit.Framework;

namespace CustomerAPITest
{
    public class Tests
    {
        private Mock<ICustomerService> _customerServiceMock;
        private List<Customer> _customers;

        [SetUp]
        public void Setup()
        {
            _customerServiceMock = new Mock<ICustomerService>();
            _customers = new List<Customer>();
            _customerServiceMock.Setup(x => x.Customers).Returns(_customers);
        }

        [Test]
        public void AddNewCustomer()
        {
            //Arrange
            var count = _customerServiceMock.Object.Customers.Count;
            _customerServiceMock.Object.Customers.Add(new Customer
            {
                DateOfBirth = "12/12/2022",
                FirstName = "James",
                LastName = "Bond",
                IdNumber = 111,
                PhoneNumber = "1211111"

            });
            var postCount = _customerServiceMock.Object.Customers.Count;

            //Act

            //Assert
            Assert.AreEqual(count+1, postCount);
        }

        [Test]
        public void DeleteUser()
        {
            //Arrange
            var customer = new Customer()
            {
                DateOfBirth = "12/12/2022",
                FirstName = "James",
                LastName = "Bond",
                IdNumber = 111,
                PhoneNumber = "1211111"
            };

            //Act
            _customerServiceMock.Object.Customers.Add(customer);
            _customerServiceMock.Object.Customers.Remove(customer);

            //Assert
            Assert.AreEqual(0, _customerServiceMock.Object.Customers.Count);
        }
    }
}