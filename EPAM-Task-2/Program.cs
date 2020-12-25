using EPAM_Task_2.Classes;
using EPAM_Task_2.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EPAM_Task_2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            IDataManager manage = new FileManager();
            ICollection<string> stringList = manage.ReadAll();
            Cleaner textCleaner = new TextCleaner(stringList.ToArray());
            string[] cleanedText = textCleaner.Clean();

            Analyser analyser = new FileTextAnalyser(cleanedText);
            analyser.Analys();

            ICollection<IWord> wordCollection = analyser.GetWordList();

            manage.Write(wordCollection);  
        }
    }
}
