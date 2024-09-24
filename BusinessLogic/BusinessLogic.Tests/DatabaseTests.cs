using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests
{
    [Collection("Database collection")]
    public class DatabaseTests : IDisposable
    {
        private readonly DatabaseFixture _fixture;

        public DatabaseTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        public void Dispose()
        {
            // Cleanup logic here
            _fixture.Dispose();
        }

        [Fact]
        public void Test1()
        {
            // Test using shared database connection
        }

        [Fact]
        public void TestDatabaseConnection()
        {
            // Use _fixture to test the database connection
        }
    }

}
