using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class RunnerBase
    {
        private static string thisParameterFile;

        public RunnerBase()
        {

        }
        public RunnerBase(string parameterFile)
        {
            thisParameterFile = parameterFile;
        }

        public void ExecuteTest(IContext testContext)
        {
            testContext.Start();
            //testContext.Execute();
            testContext.End();
        }

        public void ExecuteTest(List<string> testNames)
        {
            Type type;
            foreach (string testName in testNames)
            {
                type = Type.GetType(string.Format("Reflection.{0}", testName));
                IContext test = (IContext)Activator.CreateInstance(type, Driver);
                ExecuteTest(test);
                
            }
           // Console.ReadKey();
        }

        private IWebDriver driver;
        public IWebDriver Driver
        {
            get
            {
               if (null == driver)
                {
                    driver = new FirefoxDriver();
               }
                return driver;
            }
        }
    }
}
