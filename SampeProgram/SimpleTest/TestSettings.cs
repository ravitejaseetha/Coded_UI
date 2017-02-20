using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTest
{
    public class TestSettings : BaseSettings
    {
        private static TestSettings defaultInstance = new TestSettings();
        private static string settingsFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Config");
        private static string settingsFile;

        public static TestSettings Default
        {
            get
            {
                settingsFile = Path.Combine(settingsFilePath, "TestSettings.xml");
                return defaultInstance;
            }
        }

        string browser = "Firefox";
        public string Browser
        {
            get
            {
                string value = GetValue(settingsFile,"Browser");
                if(null != value)
                {
                    browser = value;
                }
                return browser;
            }
        }

        string url = "";
        public string URL
        {
            get
            {
                string value = GetValue(settingsFile, "AUMCPUrl");
                if (null != value)
                {
                    url = value;
                }
                return url;
            }
        }

        string excelSheet = "";
        public string ExcelSheet
        {
            get
            {
                string value = GetValue(settingsFile, "ExcelSheet");
                if (null != value)
                {
                    excelSheet = value;
                }
                return excelSheet;
                //return ((string)(this["DBConnection"]));
            }
            //set
            //{
            //    this["DBConnection"] = value;
            //}
        }
    }
}
