using System;
using System.Collections.Generic;
using System.Text;

namespace EPAM_Task_2.Interfaces
{
    interface IAnalyser
    {
        void Analys();
        ICollection<IWord> GetWordList();
    }
}
