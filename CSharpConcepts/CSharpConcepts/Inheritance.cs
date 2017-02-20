using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class Inheritance
    {
        public void Example()
        {
            Console.WriteLine("Base class method");
        }

        public  void BaseMethod()
        {
            Console.WriteLine("Base Virtual Method ");
        }

       
    }

    class SampleInheritance : Inheritance
    {
        public void DerivedExample()
        {
             Example();
        }

        public  void BaseMethod()
        {
            Console.WriteLine("Overriden Method");
        }
    }
    // Inhertiance in c# is transitive . If A extends B and B extends C then A can access C methods.
    class ExampleInhertiance : SampleInheritance
    {
        public void NewDerivedExample()
        {
            Console.WriteLine("New class method");
        }
        public void Inherit()
        {
            Example();
        }
    }
}
