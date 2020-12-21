using EPAM_Task_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPAM_Task_2.Classes
{
    class Word : IWord
    {
        public ICollection<int> ReiterationList { get;}
        public string Text { get; }

        public Word(string text, int position)
        {
            ReiterationList = new List<int>();
            Text = text;
            AddPosition(position);
            
        }

        public void AddPosition(int pos)
        {
            ReiterationList.Add(pos);
        }
    }
}
