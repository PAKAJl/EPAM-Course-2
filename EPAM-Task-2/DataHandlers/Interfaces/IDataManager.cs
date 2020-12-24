using System;
using System.Collections.Generic;
using System.Text;

namespace EPAM_Task_2.Interfaces
{
    interface IDataManager
    {
        string[] ReadAll();

        void Write(ICollection<IWord> collection);
    }
}
