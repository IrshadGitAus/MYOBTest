using System;

namespace PaySlipGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start payslip engine...");

            var e = new PaySlipEngine();
            e.WritePaySlipInfoToCSV();
        }
    }
}
