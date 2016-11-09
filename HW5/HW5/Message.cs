using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    public class Message
    {
        public string author { get; set; }
        public string destination { get; set; }
        public string text { get; set; }

        public override string ToString()
        {
            string result = string.Empty;
            result += "Автор: " + author +'\n';
            result += "Получатель: " + destination + '\n';
            result += "Текст: " + text + '\n';
            return result;
        }
    }
}
