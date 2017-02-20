using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class PageClassBase
    {
        static private List<object> utilsList = new List<object>();


        public PageClassBase(TestBase testBase)
        {
            utilsList.Add(testBase.WebDriver);
        }

        private WebControlUtility webDriver;
        protected WebControlUtility WebDriver
        {
            get
            {
                return webDriver;
            }
        }
        public PageClassBase(List<object> utils)
        {
            foreach (object util in utils)
            {
                if (util is WebControlUtility)
                {
                    webDriver = (WebControlUtility)util;
                }

            }
        }


        private PageClass pageLogin;
        public PageClass PageLogin
        {
            get
            {
                if (null == pageLogin)
                {
                    pageLogin = new PageClass(utilsList);
                }
                return pageLogin;
            }
        }

        private Wait wait;
        public Wait Wait
        {
            get
            {
                if (null == wait)
                {
                    wait = new Wait(WebDriver);
                }
                return wait;
            }
        }

        public T GetHtmlControl<T>() where T : WebControl
        {
            return Wait.GetHtmlControl<T>();
        }
    }
}
