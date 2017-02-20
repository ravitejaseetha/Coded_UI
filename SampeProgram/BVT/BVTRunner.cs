using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVT
{
    public class BVTRunner
    {
        public static string thisParameterFile;
        public BVTRunner()
        {

        }

        public BVTRunner(string paramFile)
        {
            thisParameterFile = paramFile;
        }

        public void ExecuteTest(IBVTContext context)
        {
            context.Fixture();
            context.InvalidRIFDataEntry();
        }

        public void ExecuteTest(List<string> names)
        {
            Type type;
            foreach(var testName in names)
            {
                type = Type.GetType(string.Format("BVT.{0}", testName));
                IBVTContext test = (IBVTContext)Activator.CreateInstance(type, GetInvalidRIFtData(),StudentData());
                ExecuteTest(test);

            }
        }

        private BVTEntity GetInvalidRIFtData()
        {
            return new BVTData(thisParameterFile).GetInvalidRIFData().FirstOrDefault();
        }


        private List<BVTEntity> StudentData()
        {
            return new BVTData(thisParameterFile).GetInvalidRIFData();
        }
    }
}
