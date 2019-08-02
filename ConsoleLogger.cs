using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlipGenerator
{
    public interface ILogger
    {
        void Log(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string strMessage)
        {
            Console.WriteLine(strMessage);
        }
    }
}
