using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class FunctionParameters
    {
        public void PassbyValue()
        {
            SampleValue(1);
        }

        public void SampleValue(int p)
        {
            Console.WriteLine(p);
        }


        public void PassByReference()
        {
            //value must be initialized in calling method for ref
            int myValue =10;
            
            SampleReference(ref myValue);
            Console.WriteLine(myValue);
        }

        public void SampleReference(ref int myValue)
        {
            myValue = 34;
        }


        public void PassByOut()
        {
            //value must be initialized in called method for out
            int myVal;
            SampleOut(out myVal);
            Console.WriteLine(myVal);
        }

        public void SampleOut(out int myVal)
        {
            myVal = 8;
        }

        public void PassParams()
        {
            ParamsExample("Hello","Hi");
        }

        public void ParamsExample(params string[] names)
        {
            Console.WriteLine(names[0]);
        }


        public void NamedParameters(string name, int age)
        {
            Console.WriteLine(name+age);
        }
 


    }
}
