using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            RunnerBase runner = new RunnerBase();
            runner.ExecuteTest(GetDataConditionContexts());
        }

        static List<string> GetDataConditionContexts()
        {
            var li = ConfigurationManager.AppSettings.AllKeys.ToList();
            return ConfigurationManager.AppSettings.AllKeys.ToList().Where(data => IsConditonData(data)).ToList();
        }

        static bool IsConditonData(string key)
        {
            return Convert.ToBoolean(ConfigurationManager.AppSettings[key]);
        }
    }
}
