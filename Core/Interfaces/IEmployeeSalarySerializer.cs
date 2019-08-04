using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlipGenerator
{
    public interface IEmployeeSalarySerializer
    {
        EmployeeSalary GetEmployeeSalaryFromJsonString(string strJsonString);
    }
}
