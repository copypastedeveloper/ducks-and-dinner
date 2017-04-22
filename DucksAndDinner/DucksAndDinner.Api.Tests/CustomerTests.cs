using System;
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
    public class CustomerTests
    {
        CustomerController _controller;
        Mock<ICustomerRepository> _mockedCustomerRepository;

        [TestInitialize]
        public void Initialize()
        {
            _mockedCustomerRepository = new Mock<ICustomerRepository>();

            _controller = new CustomerController(_mockedCustomerRepository.Object);
            _controller.Request = new HttpRequestMessage();
            _controller.Request.SetConfiguration(new HttpConfiguration());
        }

        [TestMethod]
        public void RegisterACustomerSuccessfully()
        {
            //arrange 
            var newCustomer = new Customer
            {
                UserName = "Nathan",
                FirstName = "Nathan",
                LastName = "Gonzalez",
                NumberOfDucksPerTypicalMeal = 4,
                Password = "duckie123"
            };

            //act
            var result = _controller.RegisterCustomer(newCustomer);

            //assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            //customer gets saved to a repository
            _mockedCustomerRepository.Verify(x => x.Save(newCustomer));
        }

        [TestMethod]
        public void RegisterAnCustomerWithoutAUserNameShouldFail()
        {
            var newCustomer = new Customer
            {
                UserName = "",
                FirstName = "Nathan",
                LastName = "Gonzalez",
                NumberOfDucksPerTypicalMeal = 4,
                Password = "duckie123"
            };

            var result = _controller.RegisterCustomer(newCustomer);

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            _mockedCustomerRepository.Verify(x => x.Save(It.IsAny<Customer>()), Times.Never);
        }
    }
}
