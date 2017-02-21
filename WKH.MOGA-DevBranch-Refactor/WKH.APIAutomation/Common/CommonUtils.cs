using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationCore.API.Framework.Library;
using AutomationCore.API.Framework.Common;
using System.Net;
using Newtonsoft.Json;

namespace WKH.APIAutomation.Common
{

    class CommonUtils
    {
        public static T DeserializeToJSON<T>(string responseString)
        {
          T responseJSON =  JsonConvert.DeserializeObject<T>(responseString);
          return responseJSON;
        }
    }


}
