using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTest
{
     public class TestBase
    {

        public TestBase()
        {

        }
        private Test test;
        protected Test TestPage
        {
            get
            {
                if (null == test)
                {
                    test = new Test(this);
                }
                return test;
            }
        }
    }
}
