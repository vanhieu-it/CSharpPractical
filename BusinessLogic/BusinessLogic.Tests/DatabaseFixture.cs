using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests
{
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            // Setup database connection or any shared resource here
        }

        public void Dispose()
        {
            // Cleanup any resources here
        }
    }

}
