using EPAM_Task_2.Interfaces;
using System.IO;
using System.Configuration;

namespace EPAM_Task_2.Classes
{
    class FileLogger:ILogger
    {
        private string path = ConfigurationManager.AppSettings["OutputFile"];
        public void Log(string message)
        {
            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(message);
            }
        }
    }
}
