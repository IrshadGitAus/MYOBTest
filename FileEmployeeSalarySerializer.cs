using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PaySlipGenerator
{
    public class FileEmployeeSalarySerializer
    {
        public EmployeeSalary GetEmployeeSalaryFromJsonString(string strJsonString)
        {
            return JsonConvert.DeserializeObject<EmployeeSalary>(strJsonString, new StringEnumConverter());
        }
    }
}
