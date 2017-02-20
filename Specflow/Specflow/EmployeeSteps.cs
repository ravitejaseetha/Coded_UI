using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Specflow
{
    [Binding]
    public class EmployeeSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        public readonly EmployeeDetails emp;
        public EmployeeSteps(EmployeeDetails emp)
        {
            this.emp = emp;
        }
    
        [Then(@"My total  power should be (.*)")]
        public void ThenMyTotalPowerShouldBe(int p0)
        {
            Console.WriteLine("Hello " + emp.name);
        }

    }
}
