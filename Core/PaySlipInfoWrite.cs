using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PaySlipGenerator
{
    public interface IPaySlipInfoWrite
    {
        void WritePaySlipInfo(string strCsvFileName, Employee e, EmployeeSalary es);
    }

    public class PaySlipInfoWrite : IPaySlipInfoWrite
    {
        public void WritePaySlipInfo(string strCsvFileName,Employee e, EmployeeSalary es)
        {
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


            first = e.firstName + " " + e.lastName;
            second = es.payPeroid;
            third = (es.grossIncome).ToString();
            fourth = (es.incomeTax).ToString();
            fifth = (es.netIncome).ToString();
            sixth = (es.super).ToString();
            newLine = string.Format("{0},{1},{2},{3},{4},{5}", first, second, third, fourth, fifth, sixth);
            csv.AppendLine(newLine);

            File.WriteAllText(strCsvFileName, csv.ToString());
        }

        
    }
}
