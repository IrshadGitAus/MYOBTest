using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PaySlipGenerator
{
    public class PaySlipEngine
    {
        public   ConsoleLogger Logger { get; set; }

        public FileEmployeeSource EmployeeSource { get; set; }

        public FileEmployeeSerializer EmployeeSerializer { get; set; } 

        public FileEmployeeSalarySerializer EmployeeSalarySerializer { get; set; }

        public PaySlipInfo EmployeePaySlipInfo { get; set; }

        public PaySlipInfoWrite EmployeePaySlipInfoWrite { get; set; }

        public PaySlipEngine()
        {
            Logger = new ConsoleLogger();
            EmployeeSource = new FileEmployeeSource();
            EmployeeSerializer = new FileEmployeeSerializer();
            EmployeeSalarySerializer = new FileEmployeeSalarySerializer();
            EmployeePaySlipInfo = new PaySlipInfo();
            EmployeePaySlipInfoWrite = new PaySlipInfoWrite();
        }

        public void GeneratePaySlip()
        {
            string employeeJson = EmployeeSource.GetEmployeeFromSource();

            var employee = EmployeeSerializer.GetEmployeeFromJsonString(employeeJson);
            var employeeSalary = EmployeeSalarySerializer.GetEmployeeSalaryFromJsonString(employeeJson);

            EmployeePaySlipInfo.GeneratePaySlipInfo(employee, employeeSalary);
            EmployeePaySlipInfoWrite.WritePaySlipInfo("employeepayslip.csv",employee, employeeSalary);

        }
    }
}
