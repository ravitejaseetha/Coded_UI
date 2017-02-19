using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using System.Threading;
using System.Diagnostics;

namespace AppiumExample
{
    class Program 
    {
        static void Main(string[] args)
        {
           
            //Process proc = null;
            //proc = new Process();
            //proc.StartInfo.WorkingDirectory = @"C:\Users\Raviteja\Desktop\";
            //proc.StartInfo.FileName = "Emualtor.bat";
            //proc.StartInfo.CreateNoWindow = false;
            //proc.Start();
            //proc.WaitForExit();

            
            AppiumDriver<IWebElement> driver;
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("device", "Android");
            //capabilities.SetCapability(CapabilityType.BrowserName, "Browser");
            capabilities.SetCapability(CapabilityType.TakesScreenshot, "true");
            capabilities.SetCapability(CapabilityType.Platform, "Windows");
            capabilities.SetCapability("deviceName", "5554:Sample");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "4.4.2");
            capabilities.SetCapability("appPackage", "com.mTourism");
            capabilities.SetCapability("appActivity", "mtourism.droid.MainActivity");


            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(180));
           // Thread.Sleep(20000);
            driver.FindElement(By.Id("android:id/up")).Click();
           // Thread.Sleep(5000);
          //  driver.FindElemencmt(By.Id("android:id/up")).Click();
            Thread.Sleep(5000);
           // ITouchScreen action = new RemoteTouchScreen(driver);
            //action.SingleTap()
           // driver.Swipe(420, 0, 80, 0,2000);
            //driver.FindElement(By.Id("lst-ib")).SendKeys("Hello World");
            
            Thread.Sleep(5000);
        }


        private bool appInstalledOrNot(String uri)
        {
            
            PackageManager pm = getPackageManager();
            try
            {
                pm.getPackageInfo(uri, PackageManager.GET_ACTIVITIES);
                return true;
            }
            catch (PackageManager.NameNotFoundException e)
            {
            }

            return false;
        }
    }
}
