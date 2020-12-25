using EPAM_Task_2.Interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace EPAM_Task_2.Classes
{
    class FileManager : IDataManager
    {
        private string _path;
        ILogger logger;
        static char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'r', 's', 't', 'y', 'v', 'w', 'x', 'y', 'z' };

        public FileManager()
        {
            _path = ConfigurationManager.AppSettings["InputFile"];
            logger = new FileLogger();
        }

        public string[] ReadAll()
        {
            try
            {
                ICollection<string> stringList = new List<string>();
                using (StreamReader sr = new StreamReader(_path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line != "")
                        {
                            stringList.Add(line);
                        }
                    }
                }

                return stringList.ToArray();
            }
            catch(FileNotFoundException e)
            {
                logger.Log("Файл для чтения не найден...");
                return new string[0];
            }
            catch
            {
                logger.Log("Неизвестная ошибка...");
                return new string[0];
            }
        }

        public void Write(ICollection<IWord> collection)
        {
            try
            {
                logger.Log("=====================================================");
                char bufChar = ' ';
                foreach (var item in collection.OrderBy(w => w.Text))
                {
                    char firstLetter = item.Text[0];
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
            catch
            {
                logger.Log("Ошибка...");
            }
            
        }
    }
}

