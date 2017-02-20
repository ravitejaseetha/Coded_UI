using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

[SetUpFixture]
public class SetUpFixtureForEntireAssembly
{
    [OneTimeSetUp]
    public void RunBeforeAnyTestsInEntireAssembly()
    {
        Console.WriteLine("!!!!! Before any tests in entire assembly");
        MessageBox.Show("EntireAssembly");
    }

    [OneTimeTearDown]
    public void RunAfterAnyTestsInInEntireAssembly()
    {
        MessageBox.Show("AfterEntireAssembly");
    }
}

