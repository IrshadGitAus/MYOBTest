using System;

namespace PaySlipGenerator
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("starting payslip generator....");
            //var logger = new ConsoleLogger();
            var logger = new FileLogger();

            var e = new PaySlipEngine(logger, new FileEmployeeSource(), new FileEmployeeSerializer(),
                new FileEmployeeSalarySerializer(), new PaySlipInfo(),new PaySlipInfoWrite());
            e.GeneratePaySlip();
        }
    }
}
