using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DucksAndDinner.Api.Controllers;
using DucksAndDinner.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DucksAndDinner.Api.Tests
{
    [TestClass]
    public class CustomerRetrievalTests
    {
        Mock<ICustomerRepository> _mockedCustomerRepository;
        CustomerController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _mockedCustomerRepository = new Mock<ICustomerRepository>();

            _controller = new CustomerController(_mockedCustomerRepository.Object);
            _controller.Request = new HttpRequestMessage();
            _controller.Request.SetConfiguration(new HttpConfiguration());
        }

        [TestMethod]
        public void GetAllCustomersShouldReturnAllCustomers()
        {
            //arrange
            _mockedCustomerRepository.Setup(x => x.GetAll())
                .Returns(() => new List<Customer>
                {
                    new Customer {UserName = "Jimmy"},
                    new Customer {UserName = "Steve"},
                    new Customer {UserName = "Sally"}
                });

            //act
            var result = _controller.GetAll();

            //assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

            IEnumerable<Customer> content;
            result.TryGetContentValue(out content);
            Assert.AreEqual(3, content.Count());
        }
    }
}