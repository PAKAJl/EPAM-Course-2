using System;
using System.Collections.Generic;
using System.Text;

namespace EPAM_Task_2.Interfaces
{
    abstract class Analyser
    {
        private string[] _text;
        private ICollection<IWord> wordList;

        public abstract void Analys();
        public abstract ICollection<IWord> GetWordList();
    }
}
