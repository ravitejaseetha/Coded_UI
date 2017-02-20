//using Microsoft.AnalysisServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAMPTest
{
    class Program
    {
       // IWebDriver driver = new FirefoxDriver();
        static void Main(string[] args)
        {
            Login log = new Login();
            log.UserLogin().UserLogout();
            Console.ReadKey();
         
            //IWebDriver driver = new FirefoxDriver();
            //driver.Manage().Window.Size = new Size(480, 320);
        }
    }

    class Login 
    {
        public  Logout UserLogin()
        {
            Console.WriteLine("UserLogin with username and password");
            return new Logout();
        }
    }

    class Logout
    {

        public  Logout UserLogout()
        {
            Console.WriteLine("Descriptive and meaningful phrases(DAMP)");
            return this;
        }
    }
}
