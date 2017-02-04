using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuScGen.TestExecutionUtil;
using Framework;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ReportGeneration.PageClass;

namespace ReportGeneration
{
    public class TestBase
    {

        private CommonControl control;

        public CommonControl Control
        {
            get
            {
                if (null == control)
                {
                    control = new CommonControl();
                }
                return control;
            }
        }

        private Login login;

        public Login Login
        {
            get
            {
                if (null == login)
                {
                    login = new Login();
                }
                return login;
            }
        }

        private TestExecute runner;
        public TestExecute Runner
        {
            get
            {
                if (null == runner)
                {
                    runner = new TestExecute();
                    Copy(Directory.GetCurrentDirectory() + @"\Report", Directory.GetCurrentDirectory() + @"\Reports");
                    runner.Print = new Utils.ScreenShot(Directory.GetCurrentDirectory() + @"\Reports");
                }
                return runner;
            }
        }

        private void Copy(string sourceDir, string targetDir)
        {
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);

                foreach (var file in Directory.GetFiles(sourceDir))
                    File.Copy(file, Path.Combine(targetDir, Path.GetFileName(file)));

                foreach (var directory in Directory.GetDirectories(sourceDir))
                    Copy(directory, Path.Combine(targetDir, Path.GetFileName(directory)));
            }
        }

        [TestFixtureTearDown]
        public void Close()
        {
            Control.Close();
           
        }
    }
}
