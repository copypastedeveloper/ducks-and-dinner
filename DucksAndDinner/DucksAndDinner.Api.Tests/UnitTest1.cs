using System;
using System.Net;
using DucksAndDinner.Api.Controllers;
using DucksAndDinner.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DucksAndDinner.Api.Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void RegisterACustomerSuccessfully()
        {
            //arrange 
            var controller = new CustomerController();
            var newCustomer = new Customer
            {
                UserName = "Nathan",
                FirstName = "Nathan",
                LastName = "Gonzalez",
                NumberOfDucksPerTypicalMeal = 4,
                Password = "duckie123"
            };

            //act
            var result = controller.RegisterCustomer(newCustomer);

            //assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

        }
    }
}
