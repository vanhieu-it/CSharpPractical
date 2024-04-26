using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Advanced
{
    public class Director: Employee
    {
        public string Permissions { get; set; } = string.Empty;
        public bool AbleToHire { get; set; } = false;
    }
}
