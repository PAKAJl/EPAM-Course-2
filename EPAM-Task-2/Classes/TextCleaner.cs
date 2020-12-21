using EPAM_Task_2.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EPAM_Task_2.Classes
{
    class TextCleaner : ITextCleaner
    {
        private string[] _text;
        private char[] _exeptionChars = new char[] {'!','?','#','.',',' };

        public TextCleaner(string[] text)
        {
            _text = text;
            
        }

        public string[] Clean()
        {
            ICollection<string> buf = new List<string>();
            Regex regex = new Regex(@"[^0-9a-zA-Z]+");
            foreach (var str in _text)
            {
                string clearedString = regex.Replace(str, " ");
                buf.Add(clearedString.Trim().ToLower());
            }
            return buf.ToArray();


        }


    }
}
