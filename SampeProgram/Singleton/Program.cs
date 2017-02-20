using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            NewExample exa = new NewExample();
            exa.Example1();
        }
    }

    public  class Example
    {
        private static readonly object mutex = new object();
        private Example()
        {

        }
        //Volatile indicated the field can be modified in the program
        //by something such as the operating system or hardware or a concurrently executing thread
        private static volatile Example instance;
        public static Example GetInstance()
        {

            //Thread Safe
            //When multiple threads running concurrently it will lock to create instance until the other thread is released 

            if (instance == null)
            {
                lock (mutex)
                {
                    if (instance == null)
                    {
                        instance = new Example();
                    }
                }
            }
            return instance;
        }
        public void DoSomething()
        {

        }
    }

    public class NewExample
    {
        public void Example1()
        {
            Example ex = Example.GetInstance();
            Example ex1 = Example.GetInstance();
            Assert.AreSame(ex, ex1);

        }
    }
}
