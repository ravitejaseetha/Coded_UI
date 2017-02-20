using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParsing
{
    class TestSettings : BaseSettings
    {
        string url = "";
        string _path;
        string settingsPath;

        public TestSettings(string path)
        {
            _path = path;
             settingsPath = Path.Combine(Directory.GetCurrentDirectory(), "TestSettings.xml");
        }
        public string URL
        {
            get
            {
                string value = GetValue(settingsPath, "AUMCPUrl");
                if(null != value)
                {
                    url = value;
                }
                return url;
            }
        }
    }
}
