using AutoIt;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoItExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //IWebDriver driver = new FirefoxDriver();
            //driver.Navigate().GoToUrl("http://www.google.com");
           
          //  AutoItX.Run("calc.exe", "");
           //AutoItX.Sleep(5000);
            // AutoItX.("Calculator", "", "[CLASS:Button; INSTANCE:14]");
            //AutoItX.ControlClick("Calculator", "", "139", "Left");
            //AutoItX.ControlClick("Calculator", "", "135", "Left");
            //AutoItX.ControlClick("Calculator", "", "94", "Left");
            //AutoItX.ControlClick("Calculator", "", "132", "Left");
            //AutoItX.ControlClick("Calculator", "", "121", "Left");
           
          //  Thread.Sleep(5000);

            //driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl("http://spreadsheetpage.com/index.php/file/C35/P10/");
            //driver.FindElement(By.LinkText("smilechart.xls")).Click();

            //AutoItX.WinWaitActive("Opening smilechart.xls");
            //AutoItX.WinKill();


            AutoItX.Run("explorer.exe d:\\", "", 1);
            AutoItX.WinWaitActive("Untitled");
            AutoItX.Send("I'm in notepad I'm in notepad I'm in notepad I'm in notepad I'm in notepad");
            AutoItX.WinClose();
            Thread.Sleep(3000);
            AutoItX.WinWaitActive("Notepad");
            AutoItX.ControlClick("Notepad", "&Save", "Button1");
        
        }
    }
}
