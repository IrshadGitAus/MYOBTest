using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PaySlipGenerator
{
    public class FileEmployeeSource : IEmployeeSource
    {
        public string GetEmployeeFromSource()
        {
            return File.ReadAllText("employee.json");
        }
    }
}
