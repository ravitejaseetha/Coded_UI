using System;
using TechTalk.SpecFlow;
using System.Linq;
using TechTalk.SpecFlow.Assist;
using SpecFlow.Assist.Dynamic;

namespace Specflow
{

    public enum Cars
    {
        Audi,
        Alto,
        Swift
    }
    [Binding]
    public class RaceSteps : Steps
    {
        public readonly EmployeeDetails emp;
        public RaceSteps(EmployeeDetails emp)
        {
            this.emp = emp;
        }
        [Given(@"I'm a new player")]
        public void GivenIMANewPlayer()
        {
            Console.WriteLine("New player");
        }

        [Given(@"I have the following attributes")]
        public void GivenIHaveTheFollowingAttributes(Table table)
        {
            //var race = table.Rows.First(row => row["attribute"] == "Race")["value"];
            //var resistance = table.Rows.First(row => row["attribute"] == "Resistance")["value"];
            //Console.WriteLine(race + resistance);

            var val = table.CreateInstance<PlayerAttributes>();
            var race = val.Race;
            var resis = val.Resistance;
        }

        [When(@"I take (.*) damage")]
        public void WhenITakeDamage(int p0)
        {
            
            Console.WriteLine(p0);
        }

        [Then(@"My health should now be (.*)")]
        public void ThenMyHealthShouldNowBe(Cars p0)
        {
            Console.WriteLine(p0);
                    }


        [Given(@"I have the following magical items")]
        [Scope(Scenario = "Total magical power")]
        public void GivenIHaveTheFollowingMagicalItems(Table table)
        {
            //foreach (var item in table.Rows)
            //{
            //    var name = item["name"];
            //    var value = item["value"];
            //    var power = item["power"];
            //}

            var val = table.CreateDynamicSet();
            foreach (var item in val)
            {
                emp.name = (string)item.name;
            }
        }

        [Then(@"My total magical power should be (.*)")]
        
        public void ThenMyTotalMagicalPowerShouldBe(int p0)
        {
            Console.WriteLine("Hello");
            
        }



    }
}
