using System.Collections.Generic;

namespace EPAM_Task_2.Interfaces
{
    interface IWord
    {
        ICollection<int> ReiterationList { get; }
        string Text { get; }
        void AddPosition(int pos);
    }
}
