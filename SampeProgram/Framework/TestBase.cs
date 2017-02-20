using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class TestBase
    {
        private static ContainerAccess container = new ContainerAccess();
        private static WebControlUtility aWebDriver;
        public WebControlUtility WebDriver
        {
            get
            {
                if (null == aWebDriver)
                {
                    aWebDriver = CreatePlugin<WebControlUtility>();
                    //string path = string.Format(@"{0}\DownloadDirectory", Directory.GetCurrentDirectory());
                    aWebDriver.Browser = new Browser(BrowserType.Firefox);
                }
                return aWebDriver;
            }

            private set
            {
                aWebDriver = value;
            }
        }


        private static T CreatePlugin<T>() where T : IContainerPlugin
        {
            return container.GetPlugin<T>();
        }

        private PageClassBase pageClassBase;
        public PageClassBase PageClassBase
        {
            get
            {
                if (null == pageClassBase)
                {
                    pageClassBase = new PageClassBase(this);
                }
                return pageClassBase;
            }
        }
    }
}
