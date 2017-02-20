using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject
{
    public static class Class1
    {
        [Test]
        public static void WebTimings()
        {
            IWebDriver driver = new FirefoxDriver();
            
            driver.Navigate().GoToUrl("http:\\www.google.com");
            var webTiming = (Dictionary<string, object>)((IJavaScriptExecutor)driver)
                .ExecuteScript(@"var performance = window.performance || window.webkitPerformance || window.mozPerformance || window.msPerformance || {};
                                 var timings = performance.timing || {};
                                 return timings;");
            /* The dictionary returned will contain something like the following.
* The values are in milliseconds since 1/1/1970
*
* connectEnd: 1280867925716
* connectStart: 1280867925687
* domainLookupEnd: 1280867925687
* domainLookupStart: 1280867925687
* fetchStart: 1280867925685
* legacyNavigationStart: 1280867926028
* loadEventEnd: 1280867926262
* loadEventStart: 1280867926155
* navigationStart: 1280867925685
* redirectEnd: 0
* redirectStart: 0
* requestEnd: 1280867925716
* requestStart: 1280867925716
* responseEnd: 1280867925940
* responseStart: 1280867925919
* unloadEventEnd: 1280867925940
*/
          
            
            webTiming.Select(x => new { x.Key, x.Value }).ToList().ForEach(x => Console.WriteLine(x.Key + "\t" + x.Value));
           
        }
    }
}
