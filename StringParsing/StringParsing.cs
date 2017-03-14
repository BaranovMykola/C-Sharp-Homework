using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace StringParsing
{
    class StringParsing
    {
        static void removeNumbers(ref string str)
        {
            str = Regex.Replace(str, @"\d+", "");
            Console.WriteLine(str);
        }
        static bool isEmail(string mail)
        {
            return Regex.Match(mail, @"\w+@\w+\.\w+").Length == mail.Length;
        }
        static void Main(string[] args)
        {
            string str = "gmapf@gmail.com";
            Console.WriteLine("{0} is email format: {1}", str, isEmail(str));
            Console.ReadKey();
        }
    }
}
