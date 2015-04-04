using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ActiveType.Settings
{
    public static class Log
    {
        private static StreamWriter innerStream_ = null;

        public static void LoadLogFile()
        {
            string fileName = "logs\\Log_" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + ".log";

            //check directory
            if (!Directory.Exists("logs"))
                Directory.CreateDirectory("logs");

            innerStream_ = new StreamWriter(fileName, true);
            innerStream_.AutoFlush = true;

            innerStream_.WriteLine("");
            innerStream_.WriteLine("****************************************************************************");
        }

        public static void AddtoLogFile(string message)
        {
            if (innerStream_ != null)
                innerStream_.WriteLine(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + " - " + message);
        }
    }
}
