using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TestRunner
    {
        public string sample;
        private List<Student>  testData;
        public TestRunner(List<Student> data)
        {
            testData = data;
        }
    }
}
