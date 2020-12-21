using EPAM_Task_2.Interfaces;
using System;

namespace EPAM_Task_2.Classes
{
    class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
