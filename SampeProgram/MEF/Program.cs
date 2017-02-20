using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEF
{
    public class Program : PageBase
    {
        private static SampleTwo sampleTwo;
        public static SampleTwo SampleTwoo
        {
            get
            {
                return sampleTwo;
            }
            set
            {
                sampleTwo = value;
            }
        }

        public Program():
            base(sampleTwo)
        {

        }
        
        static void Main(string[] args)
        {
            Plugin ps = new Plugin();
            SampleTwoo = new SampleTwo("Hello");
            //var valuew = sm.StringProp;
            ps.AssembleComponents();
            var val = ps.GetObjects();
            
            Sample s = new Sample();
        }
    }

    public class Sample : Program
    {
        public Sample()
            :base()
        {

        }
    }
}
