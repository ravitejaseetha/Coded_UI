using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractExample
{
    class Program : Employe
    {
        static void Main(string[] args)
        {

           // Employe emp = new Employe();
          //  emp.General();
        }

        public override void Sample()
        {
            throw new NotImplementedException();
        }
    }
}
