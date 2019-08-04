using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PaySlipGenerator
{
    public class PaySlipEngine
    {

        private readonly ILogger _logger;
        private readonly IEmployeeSource _employeeSource;
        private readonly IEmployeeSerializer _employeeSerializer;
        private readonly IEmployeeSalarySerializer _employeeSalarySerializer;
        private readonly IPaySlipInfo _paySlipInfo;
        private readonly IPaySlipInfoWrite _paySlipInfoWrite;

        //public IPaySlipContext Context { get; set; }

        //public ILogger Logger = new ConsoleLogger();

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

        public PaySlipEngine(ILogger logger, IEmployeeSource employeeSource, IEmployeeSerializer employeeSerializer, 
                              IEmployeeSalarySerializer employeeSalarySerializer, IPaySlipInfo paySlipInfo, IPaySlipInfoWrite paySlipInfoWrite)
        {
            _logger = logger;
            _employeeSource = employeeSource;
            _employeeSerializer = employeeSerializer;
            _employeeSalarySerializer = employeeSalarySerializer;
            _paySlipInfo = paySlipInfo;
            _paySlipInfoWrite = paySlipInfoWrite;
    }

        public void GeneratePaySlip()
        {
            _logger.Log("START");

            //string employeeJson = Context.LoadEmployeeFromFile();
            string employeeJson = _employeeSource.GetEmployeeFromSource();

            //var employee = Context.GetEmployeeFromJsonString(employeeJson);
            var employee = _employeeSerializer.GetEmployeeFromJsonString(employeeJson);

            //var employeeSalary = Context.GetEmployeeSalaryFromJsonString(employeeJson);
            var employeeSalary = _employeeSalarySerializer.GetEmployeeSalaryFromJsonString(employeeJson);

            //Context.GeneratePaySlipInfo(employee, employeeSalary);
            _paySlipInfo.GeneratePaySlipInfo(employee, employeeSalary);

            //Context.WritePaySlipInfo("employeepayslip.csv",employee, employeeSalary);
            _paySlipInfoWrite.WritePaySlipInfo("employeepayslip.csv", employee, employeeSalary);

            _logger.Log("END");
        }
    }
}
