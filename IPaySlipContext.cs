using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlipGenerator
{
    public interface IPaySlipContext
    {
        void Log(string message);

        string LoadEmployeeFromFile();

        string LoadEmployeeFromURI(string uri);

        Employee GetEmployeeFromJsonString(string employeeJson);

        EmployeeSalary GetEmployeeSalaryFromJsonString(string employeeJson);

        void GeneratePaySlipInfo(Employee employee, EmployeeSalary employeeSalary);

        void WritePaySlipInfo(string csvFFileName,Employee employee, EmployeeSalary employeeSalary);

        ConsoleLogger Logger { get; }

        PaySlipEngine Engine { get; set; }

    }
}
