using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTest
{
    public class Test
    {

        private readonly List<object> utilsList = new List<object>();
        public Test(TestBase testBase)
        {

        }
      

        private Home home;
        public Home HomePage
        {
            get
            {
                if (null == home)
                {
                    home = new Home();
                }
                return home;

            }
        }

       
    }


}
