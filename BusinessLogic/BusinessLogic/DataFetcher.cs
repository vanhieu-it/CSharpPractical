using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class DataFetcher
    {
        public async Task<string> FetchDataAsync()
        {
            await Task.Delay(500); // Giả lập thao tác bất đồng bộ, như gọi API
            return "Data fetched";
        }
    }
}
