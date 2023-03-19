using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NonStop
{
    internal class Logger
    {
        private static readonly String LogFileName = "nonstop.log";
        private String LogFile = Directory.GetCurrentDirectory() + "\\" + LogFileName;

        public Logger() { 

        }

        public void WriteLog(String Message, String Severity)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[" + DateTime.Now.ToString() + "] ");
            sb.Append("[" + Severity + "] ");
            sb.Append(Message + Environment.NewLine);

            File.AppendAllText(LogFile, sb.ToString());
        }
    }
}
