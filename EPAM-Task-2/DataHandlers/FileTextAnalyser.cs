using EPAM_Task_2.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EPAM_Task_2.Classes
{
    class FileTextAnalyser : Analyser
    {
        private string[] _text;
        private ICollection<IWord> wordList;

        public FileTextAnalyser(string[] text)
        {
            wordList = new List<IWord>();
            _text = text;
        }

        public override void Analys()
        {
            for (int i = 0; i < _text.Length; i++)
            {
                string[] strArray = _text[i].Split(' ');
                foreach (var word in strArray)
                {
                    if (wordList == null || wordList.FirstOrDefault(w => w.Text == word) == null)
                    {
                        wordList.Add(new Word(word.ToString(), i+1));
                    }
                    else
                    {
                        if (wordList.FirstOrDefault(w => w.Text == word).ReiterationList.FirstOrDefault(r => r == i+1) == 0)
                        {
                            wordList.FirstOrDefault(w => w.Text == word).AddPosition(i + 1);
                        }
                    }
                }
            }
        }

        public override ICollection<IWord> GetWordList() => wordList;
    }
}
