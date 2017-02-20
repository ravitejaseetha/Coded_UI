using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class Polymorphism
    {
        //Method overloading. Same method signature but different parameters
        public void Sample(string i)
        {
            Console.WriteLine(i);
        }

        public void Sample(string i, string j)
        {
            Console.WriteLine(i + j);
        }

        public void Sample(int i)
        {
            Console.WriteLine(i);
        }

        //Method overrriding. Same method signature and same number of parameters and the method should be either abstract or virtual in base class and 
        //ovveride method in derived class.

        public virtual void SampleOverride(int i)
        {
            Console.WriteLine("Base class abstract method");
            Console.WriteLine(i);
        }

        public virtual void SampleHiding(int k)
        {
            Console.WriteLine("Base class abstract method for method hiding");
            Console.WriteLine(k);
        }
    }


    class DerivedPolymorphism : Polymorphism
    {
        //Method overriding in derived class
        public override void SampleOverride(int i)
        {
            Console.WriteLine("Derived class overriden method");
            Console.WriteLine(i);
        }

        //Method hiding
        public new void SampleHiding(int j)
        {
            Console.WriteLine("Derived class new method");
            Console.WriteLine(j);
        }

    }


}
