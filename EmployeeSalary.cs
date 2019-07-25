using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlipGenerator
{
    public class EmployeeSalary
    {
        public double annualSalary { get; set; } //60050
        public double superRate { get; set; } //9%
        public string paymentDate { get; set; } //01 March - 31 March
        public string payPeroid { get; set; } //01 March - 31 March
        public double grossIncome { get; set; }
        public double incomeTax { get; set; }
        public double netIncome { get; set; }
        public double super { get; set; }
    }
}
