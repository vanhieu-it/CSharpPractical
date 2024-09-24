using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests
{
    public class ButtonTests
    {
        [Fact]
        public void Click_RaisesClickedEvent()
        {
            // Arrange
            var button = new Button();
            var wasEventRaised = false;
            button.Clicked += (sender, args) => wasEventRaised = true;

            // Act
            button.Click();

            // Assert
            Assert.True(wasEventRaised);
        }
    }

}
