using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    interface InterfaceExample
    {
        // An interface can be a member of a namespace or a class and can contain signatures of Methods, Properties, Indexers, Events
        void EmployeeRecord(int i);
        string Name();
        String Address
        {
            get;
            set;
        }
    }

    interface Sample
    {
        void Vehicles();
        string Name();
        string Sa();
    }

    //Multiple inheritance is possible with interface
    public class EmployeeExample : InterfaceExample, Sample
    {
        public void EmployeeRecord(int j)
        {
            Console.WriteLine("Employee information");
        }

        // If both interface has same method signature then explicitly mention the interface name along with method to implement that particular interface method.We should not 
        //mention access modifier if we use explicit typing(i.e, it will be only private)
        string InterfaceExample.Name()
        {
            return "Interface Example Hello";
        }

        string Sample.Name()
        {
            return "Sample Interface Hello";
        }

        //public string Name()
        //{
        //    return "Hello";
        //}
        //public string Name()
        //{
        //    return "hi";
        //}
        public string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public void Vehicles()
        {
            Console.WriteLine("Vehicles");
        }

        public string Sa()
        {
            return "Hello";
        }
    }
}
