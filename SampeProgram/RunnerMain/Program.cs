using DataAccess;
using SimpleTest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunnerMain
{
    class Program
    {

        private static DataAccess.DataAccess dataAccess;
        protected static DataAccess.DataAccess Data
        {
            get
            {
                if (null == dataAccess)
                {
                    // dataAccess = CreatePlugin<DataAccess.DataAccess>();
                    //    dataAccess = DataAccess.DataAccess;
                    //    //dataAccess = "";
                    //    //dataAccess.ConectionString = ConfigurationManager.ConnectionStrings["ExcelConn"].ToString();

                    //    dataAccess.ConectionString = TestSettings.Default.ExcelSheet;
                    return dataAccess;
                    //}
                    //return DataAccess.DataAccess;
                   
                }
                return null;
            }
        }



        static void Main(string[] args)
        {
            string dataFile = string.Format(@"{0}\TestData\TestRunner.xls", Directory.GetCurrentDirectory());
            BaseDataHandler.Initialize(dataFile, Data);
            TestRunner runner = new TestRunner(StudentData.GetStudenData());
        }
    }
}
