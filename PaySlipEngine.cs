using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PaySlipGenerator
{
    public class PaySlipEngine
    {

        public IPaySlipContext Context { get; set; } = new DefaultPaySlipContext();

        public ILogger Logger = new ConsoleLogger();

        /*

        public ConsoleLogger Logger { get; set; }

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
        */

        public void GeneratePaySlip()
        {
            Logger.Log("START");

            string employeeJson = Context.LoadEmployeeFromFile();

            var employee = Context.GetEmployeeFromJsonString(employeeJson);
            var employeeSalary = Context.GetEmployeeSalaryFromJsonString(employeeJson);

            Context.GeneratePaySlipInfo(employee, employeeSalary);
            Context.WritePaySlipInfo("employeepayslip.csv",employee, employeeSalary);

            Logger.Log("END");
        }
    }
}
