using DucksAndDinner.Api.Controllers;
using DucksAndDinner.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DucksAndDinner.Api.Tests
{
    [TestClass]
    public class BringingADuck
    {
        [TestMethod]
        public void DuckShouldBeSavedToTheListOfAvailableDucks()
        {
            //arrange
            var mockDuckRepository = new Mock<IDuckRepository>();
            
            var controller = new DuckController(mockDuckRepository.Object);
            var newDuck = new Duck
            {
                Name = "Donald",
                Picture = "https://lumiere-a.akamaihd.net/v1/images/character_mickeymouse_donaldduck_d79720c3.jpeg?region=0,0,300,300",
                Weight = 3
            };

            //act
            controller.BringADuck(newDuck);

            //assert
            mockDuckRepository.Verify(x => x.Save(newDuck),Times.Once);
        }
    }
}