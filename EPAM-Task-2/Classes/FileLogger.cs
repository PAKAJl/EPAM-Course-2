using EPAM_Task_2.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EPAM_Task_2.Classes
{
    class FileLogger:ILogger
    {
        private string path = @"log.txt";
        public void Log(string message)
        {
            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(message);
            }
        }
    }
}
