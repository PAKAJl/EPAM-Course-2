using EPAM_Task_2.Classes;
using EPAM_Task_2.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EPAM_Task_2
{
    class Program
    {
        static char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'r', 's', 't', 'y', 'v', 'w', 'x', 'y', 'z' };
        static void Main(string[] args)
        {
            ICollection<string> stringList = new List<string>();
            string path = "1.txt";

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    stringList.Add(line);
                }
            }

            ITextCleaner textCleaner = new TextCleaner(stringList.ToArray());
            string[] cleanedText = textCleaner.Clean();

            IAnalyser analyser = new FileTextAnalyser(cleanedText);
            analyser.Analys();

            ICollection<IWord> wordCollection = analyser.GetWordList();

            ILogger logger = new  FileLogger();
            char bufChar = ' ';
            foreach (var item in wordCollection.OrderBy(w => w.Text))
            {
                char firstLetter = item.Text.Substring(0,1).ToCharArray()[0];
                if (firstLetter != bufChar)
                {
                    foreach (var letter in alphabet)
                    {
                        if (letter == firstLetter)
                        {
                            logger.Log(char.ToUpper(letter).ToString());
                            bufChar = firstLetter;
                            break;
                        }
                    }
                }
                
                string matches = "";
                foreach (var match in item.ReiterationList)
                {
                    matches += match + " ";
                }
                logger.Log($"{item.Text}..................{item.ReiterationList.Count}:  {matches}");
            }
        }
    }
}
