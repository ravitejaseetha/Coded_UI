using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoupling
{
    enum Country
    {
        India,
        Us
    }
    interface IPerson
    {
        void ShowCountry();
    }

    //class BasePerson
    //{

    //}
    //Concrete class
    class IndianPerson : IPerson
    {

        public void ShowCountry()
        {
            Console.WriteLine("India Person");
        }

        public void Example()
        {
            Console.WriteLine("Example");
        }
    }

    class UsPerson : IPerson
    {

        public void ShowCountry()
        {
            Console.WriteLine("Us Person");
        }
    }
    // Middle Layer or business layer
    class PersonSupplyer
    {
        public static IPerson ReturnPerson(Country country)
        {
            if (country == Country.India)
            {
                return new IndianPerson();
            }
            else if (country == Country.Us)
            {
                return new UsPerson();
            }
            else
            {
                return null;
            }
        }
    }

    //Client Code
    class Program : Sample
    {
        static void Main(string[] args)
        {
            //IPerson person = PersonSupplyer.ReturnPerson(Country.India);
            //person.ShowCountry();
            
       
            Console.ReadKey();
        }

        public new void Example()
        {
            Console.WriteLine("hello");
        }
      
        public override void ExampleTwo()
        {
            Console.WriteLine("Example Two in base class");
        }
    }


    public abstract class Sample
    {
        public void Example()
        {
            Console.WriteLine("Example");
        }

        public abstract void ExampleTwo();
    }
}
