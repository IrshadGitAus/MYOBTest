using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PaySlipGenerator
{
    public class FileEmployeeSerializer : IEmployeeSerializer
    {
       public Employee GetEmployeeFromJsonString(string strJsonString)
        {
            return JsonConvert.DeserializeObject<Employee>(strJsonString, new StringEnumConverter());
        }
    }
}
