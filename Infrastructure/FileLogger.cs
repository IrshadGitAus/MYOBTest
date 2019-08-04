using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PaySlipGenerator
{

    public class FileLogger : ILogger
    {
        public void Log(string strMessage)
        {
            using (var stream = File.AppendText("log.txt"))
            {
                stream.WriteLine(strMessage);
                stream.Flush();
            }
        }
    }
}
