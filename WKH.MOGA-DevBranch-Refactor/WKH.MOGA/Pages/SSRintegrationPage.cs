using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WKH.SeleniumFrameWork;

namespace WKH.MOGA
{
    public class SSRintegrationPage : UIObjects
    {

        public static SSRintegrationPage ssrIntegrationPage;

        public SSRintegrationPage()
        {
            PageFactory.InitElements(WebDriver, this);
            ssrIntegrationPage = this;
        }

        //creating object of this class. Call this before accessing anyother method of this class
        public static void NavigateHere()
        {
            ssrIntegrationPage = new SSRintegrationPage();
        }

        #region User page control variables
       
        [FindsBy(How = How.XPath, Using = "//h3")]
        public IWebElement contentUploadTitle;

        [FindsBy(How = How.XPath, Using = "//*[@id='selectorContainer']/div[2]")]
        public IWebElement FileSelectorLink;

        [FindsBy(How = How.Id, Using = "startLink")]
        public IWebElement startUploadLink;

        [FindsBy(How = How.XPath, Using = "//*[@class='col-xs-12']/p")]
        public IWebElement filesForProcessingMsg;

        [FindsBy(How = How.XPath, Using = "//*[@class='results table table-striped table-bordered']/tbody//td[1]")]
        public IWebElement uploadSuccessMsg;

        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement userName;

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement passWord;

        #region//Login page controls
        [FindsBy(How = How.Name, Using = "loginfmt")]
        public IWebElement userNameInput;

        [FindsBy(How = How.Name, Using = "passwd")]
        public IWebElement passwordInput;

        [FindsBy(How = How.Id, Using = "idSIButton9")]
        public IWebElement loginButton;
        #endregion

        #endregion

        public static void LoginToSSR(string username, string pwd)
        {
            ssrIntegrationPage = new SSRintegrationPage();
            ResultReport.AddTestStepDetails("Login to SSR Dev");
            
            //loginPage.loginLink.Click();
            ssrIntegrationPage.userNameInput.SendKeys(username);
            ssrIntegrationPage.passwordInput.SendKeys(pwd);
            ssrIntegrationPage.loginButton.Click();

            if (MOGAConstants.browserType == "FireFox")
            {
                //click on accept button in security warning popup
                UIObjects.WebDriver.SwitchTo().Alert().Accept();
            }
            
        }

        //This method is used to select the tab
        //Parameters required : tabtext
        public static void SelectTab(string tabTextValue)
        {
            ResultReport.AddTestStepDetails("Navigate to the " + tabTextValue + " tab");
            switch (tabTextValue)
            {
                #region Verify Products ,Publishers, Subjects And Categories
                case "Products":
                case "Publishers":
                case "Subjects And Categories":

                    WebElement("LinkText=Product Catalog").Click();
                    WebElement("LinkText=" + tabTextValue).Click();
                    WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50)); //implicit wait
                    break;
                #endregion

                #region Verify InProcess Job ,Incoming Jobs
                case "InProcess Jobs":
                case "Incoming Jobs":

                    WebElement("LinkText=Dashboard").Click();
                    WebElement("LinkText=" + tabTextValue).Click();
                    WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10)); //implicit wait
                    break;

                #endregion

                #region Verify DashBoard,Tools
                case "Retrieve Asset":
                    WebElement("LinkText=Tools").Click();
                    WebElement("LinkText=" + tabTextValue).Click();
                    WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10)); //implicit wait
                    break;

                #endregion

                #region select Users,Home,Content Upload,Reports,Trace Logs
                default:
                    WebElement("LinkText=" + tabTextValue).Click();
                    WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10)); //implicit wait
                    break;
                    #endregion
            }
        }

        //Verify that the content upload page loads successfully
        public static bool VerifyContentUploadPage()
        {
            ResultReport.AddTestStepDetails("Verify the content upload page in loaded state");
            bool flag = false;
            if (ssrIntegrationPage.contentUploadTitle.Equals("Select up to 10 files on your computer"))
            {
                string contentUpload = WebDriver.Url;
                Uri currentUri = new Uri(contentUpload);
                string baseUrl = currentUri.AbsolutePath;
                Assert.IsTrue(baseUrl.Contains("ContentUpload"));
                flag = true;
            }
            return flag;
        }

        //Upload File(s) in the content upload page
        public static void UploadFile(string filename = @"C:\TestData\MOGA\SSRfiles\medline_medline14n0747_30\medline14n0747_30.xml")
        {           
                ResultReport.AddTestStepDetails("Upload file " + "\"" + filename + "\"" + " in the content upload page");

                UIObjects.WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10)); //implicit wait
                ssrIntegrationPage.FileSelectorLink.Click();
               
                {
                    UIObjects.WebDriver.SwitchTo().ActiveElement().SendKeys(@"C:\TestData\MOGA\SSRfiles\ZipFile\" + filename + ".zip");

                    SendKeys.SendWait(@"{Enter}");

                    SendKeys.SendWait("%{F4}");
                }
                            
                ssrIntegrationPage.startUploadLink.Click();

            WebDriverWait waitForObject = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(500));
            waitForObject.Until(ExpectedConditions.UrlContains("UploadResult"));
        }

        //Verify that file has been uploaded successfully in the content upload page
        public static string VerifySuccessfulUpload(string filename)
        {
            ResultReport.AddTestStepDetails("Verify the successful upload of file in the content upload page");
            string Unique = "test";
            WebDriverWait waitForObject = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(500));
            waitForObject.Until(ExpectedConditions.UrlContains("UploadResult"));

            string elementText = ssrIntegrationPage.contentUploadTitle.Text;
            string filesForProcessingText = ssrIntegrationPage.filesForProcessingMsg.Text;
            if (elementText.Equals("Upload Result") && filesForProcessingText.Equals("The following files were queued for processing:"))
            {
                bool flag = false;
                string successuploadfile = ssrIntegrationPage.uploadSuccessMsg.Text;
                int indexvalue = successuploadfile.IndexOf("/");
                Unique = successuploadfile.Substring(indexvalue + 1);

                if (successuploadfile.Contains(filename))
                {
                    flag = true;
                    Assert.IsTrue(flag);
                }
                else
                    Assert.IsTrue(false, "File not uploaded correctly");

            }
            return Unique;
        }

        //Open a new tab in the browser and pass the webmail url
        public static void OpenNewTab(string url)
        {
            ResultReport.AddTestStepDetails("Open a new tab in the browser and go to the webmail application");
            IWebElement body =UIObjects.WebElement("TagName=body");
            body.SendKeys(OpenQA.Selenium.Keys.Control.ToString() + 't');
            CommonMethods.OpenURL(new Uri(url));
         }

        //Login to the Webmail application
        public static void OpenWebMail(String username, String password)
        {
            ResultReport.AddTestStepDetails("Login to webmail using automation id/password");
            ssrIntegrationPage.userName.SendKeys(username);
            ssrIntegrationPage.passWord.SendKeys(password);
            IWebElement savebtn = UIObjects.WebElement("XPath=//*[@class='txtpad']/input[@class='btn']");
            savebtn.Click();
        }


        //Verify upload success email in Webmail application
        public static bool VerifyUploadSuccessEmail1(string Unique)
        {

            bool Status = false;
            UIObjects.WebDriver.FindElement(By.XPath(" //input[@id='txtS']")).Clear();
            UIObjects.WebDriver.FindElement(By.XPath(" //input[@id='txtS']")).SendKeys(Unique);
            UIObjects.WebDriver.FindElement(By.XPath(" //input[@id='txtS']")).SendKeys(OpenQA.Selenium.Keys.Enter);
            Thread.Sleep(5000);
            ReadOnlyCollection<IWebElement> Msg = UIObjects.WebElements("XPath=//*[@id='divSubject']");
            if (Msg.Count != 0)
            {
                foreach (IWebElement Subject in Msg)
                {
                    if (Subject.Text.Contains(Unique) && Subject.Text.Contains("Success Notification"))
                    {
                        Status = true;
                        break;
                    }
                }
                return Status;
            }
            else
                return Status;
        }


        public static string[] UpdatingXML()
        {
            // Generate random number
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 10);

            string[] contentData = new string[2];

            string titleOfRecord = "QA Automation Test " + rnd.Next(11, 100); ;

            //Loading XML
            XmlDocument doc = new XmlDocument();
            String path = @"C:\TestData\MOGA\SSRfiles\medline_medline14n0747_30\medline14n0747_30.xml";
            doc.Load(path);
            string defFilePath = @"C:\TestData\MOGA\SSRfiles\medline_medline14n0747_30";
            string newFileName = "medline_medline" + DateTime.Now.ToString("MMddyyhhmmsstt");
            string zipFilePath = @"C:\TestData\MOGA\SSRfiles\ZipFile\"+ newFileName + ".zip";

            // get a list of all <Title> nodes
            XmlNodeList aNodes = doc.SelectNodes("/MedlineCitationSet/MedlineCitation/Article/ArticleTitle");
               
            // Replace random <Title> node with user string and SAVE
            if (aNodes[randomNumber].InnerText != "")
            {
                String oldTitle = aNodes[randomNumber].InnerText;
                aNodes[randomNumber].InnerText = titleOfRecord;
                doc.Save(path);
            }
            else
            {
                Console.WriteLine("Random title value is empty");
            }

            //Zip XML after update
            ZipFile.CreateFromDirectory(defFilePath, zipFilePath, CompressionLevel.Fastest, true);

            contentData[0] = titleOfRecord;
            contentData[1] = newFileName;
            return contentData;
        }

    }
}
