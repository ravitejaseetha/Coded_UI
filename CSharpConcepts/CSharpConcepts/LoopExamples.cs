using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class LoopExamples
    {
        int number = 0;
        public void WhileExample()
        {
           

            while (number < 5)
            {
                Console.WriteLine(number);
                number = number + 1;
            }

            Console.ReadLine();
        }

        public void DoExample()
        {
            do
            {
                Console.WriteLine(number);
                number = number + 1;
            } while (number < 5);
        }


        public void ForExample()
        {
            int number = 5;
            for (int i = 0; i < number; i++)
                Console.WriteLine(i);
            Console.ReadLine();
        }

        public void ForEachExample()
        {
            ArrayList list = new ArrayList();
            list.Add("John Doe");
            list.Add("Jane Doe");
            list.Add("Someone Else");
            foreach (string name in list)
                Console.WriteLine(name);
            Console.ReadLine();
        }

    }
}
