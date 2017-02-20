using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Specflow
{
    [Binding]
    public sealed class Hooks1
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Before run");
        }

        [BeforeFeature]
        public static  void BeforeFeature()
        {
            Console.WriteLine("Before run");
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.WriteLine("Before Scenario");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("After Scenario");
        }
    }
}
