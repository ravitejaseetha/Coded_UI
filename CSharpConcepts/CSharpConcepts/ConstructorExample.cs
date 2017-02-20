using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class ConstructorExample
    {
        public string name, gender;
        //Parameterless constructor or default Constructor
        public ConstructorExample()
        {
            name = "Sachin";
            gender = "Male";
        }

        //Paramterized constructor
        public ConstructorExample(string s1)
            :this()
        {
            name = s1;
        }

        //Static Constructor is called without even creating instance
        static ConstructorExample()
        {
            Console.WriteLine("Static Constructor");
        }

        //Copy Constructor
        //Used to pass same class type as parameter to the constructor
        public ConstructorExample(ConstructorExample c1)
        {
            name = c1.name;
            gender = c1.gender;
        }

        //Private Constructor
        // We cannot create an instance to a private constructor an we cannot have public and private default constructor in the same class and we cannot
        //Inherit if the class has only private constructor
        //private ConstructorExample()
        //{

        //}
    }
}
