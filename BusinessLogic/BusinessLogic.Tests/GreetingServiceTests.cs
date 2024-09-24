using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests
{
    public class GreetingServiceTests
    {
        [Fact]
        public void GreetUser_ReturnsCorrectGreeting()
        {
            // Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(service => service.GetUserName(1)).Returns("John Doe");

            var greetingService = new GreetingService(mockUserService.Object);

            // Act
            var result = greetingService.GreetUser(1);

            // Assert
            Assert.Equal("Hello, John Doe!", result);

            // Verify if GetUserName was called once
            mockUserService.Verify(service => service.GetUserName(1), Times.Once);
        }
    }

}
