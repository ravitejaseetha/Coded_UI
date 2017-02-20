using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    enum Days { Sun = 1, Mon, Tue, Wed, Thu, Fri, Sat };
    //  enum Range : long { Max = 2147483648L, Min = 255L };

    enum Range : long { Max = 2147483648L, Min = 255L };
    enum Name { first, last};
    class EnumExample
    {
        public void ValuesEnum()
        {
            int x = (int)Days.Sun;
            int y = (int)Days.Fri;
            Console.WriteLine("Sun = {0}", x);
            Console.WriteLine("Fri = {0}", y);

            long x1 = (long)Range.Max;
            long y1 = (long)Range.Min;
            Console.WriteLine("Max = {0}", x1);
            Console.WriteLine("Min = {0}", y1);
           
            Name myName;
            if (Enum.TryParse("first", out myName))
            {
                if(myName == Name.first)
                {
                    Console.WriteLine("True");
                }
            }

        }


       


    }
}
