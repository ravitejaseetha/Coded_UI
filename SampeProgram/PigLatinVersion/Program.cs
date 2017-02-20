using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PigLatinVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            Result();
        }

        public static void Result()
        {
            Regex regex = new Regex("[0-9]");
            Regex regex1 = new Regex("[_@(+).,-]");
            Regex regex2 = new Regex("[A-Za-z]");
            string value = "sdfsd gdfg? hjgh,";
            string[] values = value.Split(' ');
            string result, resultOne;
            List<string> endResult = new List<string>();
            foreach(string val in values)
            {
                if (regex1.IsMatch(val) && regex2.IsMatch(val))
                {
                    var punctuation = val.Substring(val.Length - 1);
                    var afterSplit = val.Substring(0, val.Length - 1);
                    result = afterSplit.Substring(0, 1);
                    resultOne = val.Substring(1, val.Length - 2);
                    endResult.Add(resultOne + result + "ay" + punctuation + " ");
                }
                else if (regex.IsMatch(val) && regex2.IsMatch(val))
                {
                    endResult.Add(val);
                }
                else if (regex.IsMatch(val))
                {
                    endResult.Add(val + " ");
                }
    
                else
                {
                    result = val.Substring(0, 1);
                    resultOne = val.Substring(1, val.Length - 1);
                    endResult.Add(resultOne + result + "ay ");
                }       
            }
            foreach(var va in endResult)
            {
                Console.Write(va);
            }
            
            Console.ReadKey();
        }
    }
}
