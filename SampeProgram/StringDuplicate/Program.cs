using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDuplicate
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = "java is java again java";
            string[] arrayValues = value.Split(' ');
      
           // var val1 = arrayValues[i];
            var count = 0;
            List<string> val = new List<string>();

            for (int k = 0; k < arrayValues.Count() - 1; k++)
            {
                for (int j = 1; j < arrayValues.Count(); j++)
                {
                    if (k < j)
                    {
                        if (arrayValues[k] == arrayValues[j])
                        {
                            Console.WriteLine(arrayValues[k]);
                            break;
                            val.Add(arrayValues[j]);
                            count = val.Count;
                        }
                    }
                }
                break;
            }
          // Console.WriteLine(count+1);
            Console.ReadKey();
        }
    }
}
