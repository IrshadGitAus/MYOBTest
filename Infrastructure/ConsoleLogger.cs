using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PaySlipGenerator
{
   
    public class ConsoleLogger : ILogger
    {
        public void Log(string strMessage)
        {
            Console.WriteLine(strMessage);
        }
    }

}
