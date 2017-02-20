using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public enum ControlType
    {
        Button,

        EditBox,

        Custom,

        Calender,

        ComboBox,

        CheckBox,

        Dialog,

        Frame,

        Image,

        Label,

        Link,

        ListBox,

        Page,

        RadioButton,

        SpanArea,

        WebTable,

        WebRow,

        WebCell
    }

    public enum LocatorType
    {
        Id,
        Name,
        PartialLinkText,
        Css,
        Xpath,
        TagName,
        LinkText,
        ClassName
    }
    public class ControlAccess
    {
        private BrowserType aBrowserType;
        private LocatorType aLocatorType;
        public string Locator { get; set; }
        public Browser Browser { get; set; }
        public ControlType ControlType { get; set; }
        // private ControlType aControlType;
        private ControlType aControlType;
        public LocatorType LocatorType { get; set; }
        private IWebElement aWebElement;

        private IWebDriver aWebDriver;
        public IControl GetControl()
        {
            InitializeWebElement();
            return Utility.GetControlFromWebElement(aWebElement, ControlType);
        }
        //public void IntializeControlAccess()
        //{

        //    aControlType = ControlType;
        //}

        public bool IsElementPresent()
        {
            try
            {
                InitializeWebElement();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        private string aLocator;
        internal void InitializeWebElement()
        {
            if (LocatorType == LocatorType.Id)
            {
                aWebElement = aWebDriver.FindElement(By.Id("gb_70"));
            }

        }

        public void IntializeControlAccess()
        {
            aBrowserType = Browser.BrowserType;
            aWebDriver = Browser.BrowserHandle;
            aLocatorType = LocatorType;
            aLocator = Locator;
            aControlType = ControlType;
        }
    }
}
