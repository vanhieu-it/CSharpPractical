using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests
{
    public class DataFetcherTests
    {
        [Fact]
        public async Task FetchDataAsync_ReturnsCorrectData()
        {
            // Arrange
            var fetcher = new DataFetcher();

            // Act
            var result = await fetcher.FetchDataAsync();

            // Assert
            Assert.Equal("Data fetched", result);
        }
    }

}
