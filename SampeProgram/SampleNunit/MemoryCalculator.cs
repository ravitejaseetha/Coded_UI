using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleNunit
{
    class MemoryCalculator
    {
        int currentValue = 0;
   
        public void Add(int i)
        {
            currentValue = currentValue + i;
        }

        public void Sub(int i)
        {
            currentValue = currentValue - i;
           
        }

        public int CurrentValue
        {
            get
            {
                return currentValue;
            }
        }


    }
}
