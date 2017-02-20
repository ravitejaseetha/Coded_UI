using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVT
{
    public interface IBVTContext
    {
        void Fixture();
        void TearDown();
        void RequestInfo();
        void StraighRIFDataEntry();
        void InvalidRIFDataEntry();
        void SourceRepData();
        void ValidateData();
        void CheckBrokenLink();
    }
}
