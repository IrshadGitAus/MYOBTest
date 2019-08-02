using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlipGenerator
{
    public class DefaultPaySlipContext : IPaySlipContext
    {
        public PaySlipEngine Engine { get; set; }

        public string LoadEmployeeFromFile()
        {
            return new FileEmployeeSource().GetEmployeeFromSource();
        }

        public string LoadEmployeeFromURI(string uri)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeFromJsonString(string json)
        {
            return new FileEmployeeSerializer().GetEmployeeFromJsonString(json);
        }

        public EmployeeSalary GetEmployeeSalaryFromJsonString(string json)
        {
            return new FileEmployeeSalarySerializer().GetEmployeeSalaryFromJsonString(json);
        }

        public void GeneratePaySlipInfo(Employee e, EmployeeSalary es)
        {
            new PaySlipInfo().GeneratePaySlipInfo(e, es);
        }

        public void WritePaySlipInfo(string csvfilename, Employee e, EmployeeSalary es)
        {
            new PaySlipInfoWrite().WritePaySlipInfo(csvfilename,e, es);
        }
    }
}
