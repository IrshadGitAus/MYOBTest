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

        public PaySlipEngine()
        {
            Logger = new ConsoleLogger();
            EmployeeSource = new FileEmployeeSource();
            EmployeeSerializer = new FileEmployeeSerializer();
        }

        public void WritePaySlipInfoToCSV()
        {

            string employeeJson = EmployeeSource.GetEmployeeFromSource();
            var employee = EmployeeSerializer.GetEmployeeFromJsonString(employeeJson);

            employee.payPeroid = GetPayPeriod(employee.paymentDate);
            employee.grossIncome = GetGrossIncome(employee.annualSalary);
            employee.incomeTax = GetTaxOnIncome(employee.annualSalary);
            employee.netIncome = GetNetIncome(employee.grossIncome, employee.incomeTax);
            employee.super = GetSuper(employee.grossIncome, employee.superRate);

            var csv = new StringBuilder();
            var first = "Name";
            var second = "Pay Period";
            var third = "Gross Income";
            var fourth = "Income Tax";
            var fifth = "Net Income";
            var sixth = "Super";
            var newLine = "";

            //name, pay period,gross income, income tax, net income and super.
            newLine = string.Format("{0},{1},{2},{3},{4},{5}", first, second, third, fourth, fifth, sixth);
            csv.AppendLine(newLine);


            first = employee.firstName + " " + employee.lastName;
            second = employee.payPeroid;
            third = (employee.grossIncome).ToString();
            fourth = (employee.incomeTax).ToString();
            fifth = (employee.netIncome).ToString();
            sixth = (employee.super).ToString();
            newLine = string.Format("{0},{1},{2},{3},{4},{5}", first, second, third, fourth, fifth, sixth);
            csv.AppendLine(newLine);

            File.WriteAllText("employeepayslip.csv", csv.ToString());
        }

        public string GetPayPeriod(string paymentStartDate)
        {
            return paymentStartDate;
        }

        public double GetGrossIncome(double annualSalary)
        {
            return Math.Round(annualSalary / 12);
        }

        public double GetTaxOnIncome(double annualSalary)
        {
            double dblTax = 0;

            if (annualSalary >= 0 & annualSalary <= 18200)
            {
                dblTax = 0;
            }
            else if (annualSalary >= 18201 & annualSalary <= 37000)
            {
                //(3, 572 + (60, 050 - 37, 000) x 0.325) / 12
                dblTax = Math.Round((0 + (annualSalary - 18200) * 0.190) / 12);
            }
            else if (annualSalary >= 37001 & annualSalary <= 87000)
            {
                dblTax = Math.Round((3572 + (annualSalary - 37000) * 0.325) / 12);
            }
            else if (annualSalary >= 87001 & annualSalary <= 180000)
            {
                dblTax = Math.Round((19822 + (annualSalary - 87000) * 0.370) / 12);
            }
            else if (annualSalary >= 180001)
            {
                dblTax = Math.Round((54232 + (annualSalary - 180000) * 0.450) / 12);
            }
            else
            {
                dblTax = 0;
            }

            return dblTax;

        }


        public double GetNetIncome(double grossIncome, double taxOnIncome)
        {
            return grossIncome - taxOnIncome;
        }

        public double GetSuper(double grossIncome, double superRate)
        {
            return Math.Round(grossIncome * (superRate / 100));
        }



    }



}
