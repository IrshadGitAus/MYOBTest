using System;

namespace PaySlipGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var e = new PaySlipEngine();
            e.GeneratePaySlip();
        }
    }
}
