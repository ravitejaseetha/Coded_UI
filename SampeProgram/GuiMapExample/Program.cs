using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiMapExample
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var ele = GetElement("Tutorials", "Cricinfo.xml");
            ele.Click();
                
        }

        public static IWebElement GetElement(string logicalName, string fileName)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.cricinfo.com");
            driver.Manage().Window.Maximize();
            IWebElement ele = null;
            string file = Directory.GetCurrentDirectory() + @"\Guimap\"+@fileName;
            GuiMapParser gui = new GuiMapParser();
            var val = gui.LoadGuimap(file);
            int count = val.Count;
            for (int i = 0; i < count; i++)
            {
                //Console.WriteLine(val.Keys.ElementAt(i));
                if (val.Keys.ElementAt(i) == logicalName)
                {
                    if (val.Values.ElementAt(i).IdentificationType == "class")
                    {
                        ele = driver.FindElement(By.ClassName(val.Values.ElementAt(i).ClassName));
                    }
                    else if (val.Values.ElementAt(i).IdentificationType == "id")
                    {
                       ele = driver.FindElement(By.Id(val.Values.ElementAt(i).id));
                    }
                    else if (val.Values.ElementAt(i).IdentificationType == "xpath")
                    {
                        ele = driver.FindElement(By.XPath(val.Values.ElementAt(i).Xpath));
                    }
                    return ele;
                }
            }
            return null;
           
        }
    }
}
