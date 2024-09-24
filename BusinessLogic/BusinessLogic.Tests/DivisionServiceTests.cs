using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests
{
    public class DivisionServiceTests
    {
        [Fact]
        public void Divide_DivideByZero_ThrowsArgumentException()
        {
            // Arrange
            var service = new DivisionService();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => service.Divide(10, 0));

            // Kiểm tra message của exception
            Assert.Equal("Cannot divide by zero.", exception.Message);
        }
    }

}
