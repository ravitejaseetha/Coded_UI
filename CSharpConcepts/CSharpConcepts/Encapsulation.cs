using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class Encapsulation
    {
        private decimal _balance;
        public decimal Balance
        {
            get
            {
                return _balance;
            }

            set
            {
                // do security checks and validation
                if (value > 0)
                    _balance = value;
                else
                    throw new InvalidOperationException();
            }
        }
    }
}
