using BVT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVTTestRunner
{
    class Program 
    {
        static void Main(string[] args)
        {
            BVTRunner test = new BVTRunner(@".\TestData\SampleTestData2.xls");
            test.ExecuteTest(GetDataConditionContexts());
        }


        static List<string> GetDataConditionContexts()
        {
            return ConfigurationManager.AppSettings.AllKeys.ToList().Where(data => IsConditonData(data)).ToList();
        }

        static bool IsConditonData(string key)
        {
            return Convert.ToBoolean(ConfigurationManager.AppSettings[key]);
        }
    }
}
