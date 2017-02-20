using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Sample s = new Sample();
            s.Hello();
        }
    }

    public class Sample
    {
        private static log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Sample()
        {
            log4net.ThreadContext.Properties["myContext"] = "Logging from TestRunner";
            Logger.Debug("Insideeeeeeeee TestRunner Constructor!");
            //Console.ReadKey();
            //Logger.Debug(this.GetType().Name);
        }
        public  void Hello()
        {
            Logger.Debug(this.GetType().Name);
            Console.WriteLine("asdasd");
        }
    }
}
