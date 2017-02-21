using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WKH.MOGA;
using WKH.SeleniumFrameWork;
using System.Collections.Generic;

namespace MOGAtestcases
{
    [TestClass]
    public class SSRcontentTCs
    {

        # region constructor
       
        #endregion

        //[WorkItem(102617),TestCategory("SmokeTest"), TestMethod]
        public void SSRdataLoadE2EFlowVerification_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, "Chrome");

                FrameworkBase.OpenBrowser("Chrome", MOGAConstants.ssrURL);
                SSRintegrationPage.NavigateHere();
                SSRintegrationPage.LoginToSSR(MOGAConstants.ssrUserName1, MOGAConstants.ssrPassWord1);
                string[] contentData = SSRintegrationPage.UpdatingXML();
                SSRintegrationPage.SelectTab("Content Upload");
                SSRintegrationPage.NavigateHere();
                SSRintegrationPage.VerifyContentUploadPage();
                SSRintegrationPage.UploadFile(contentData[1]);
                string uniquevalue = SSRintegrationPage.VerifySuccessfulUpload(contentData[1]);
            
             //   SSRintegrationPage.OpenNewTab(MOGAConstants.outLookUrl);
             //   SSRintegrationPage.OpenWebMail(MOGAConstants.outLookUid, MOGAConstants.outLookPwd);
             //   bool flag = SSRintegrationPage.VerifyUploadSuccessEmail1(uniquevalue);

                FrameworkBase.CloseBrowser();

                System.Threading.Thread.Sleep(180000); // need to wait 3 min to get the data uploaded.Need to create a separate method to handle

                FrameworkBase.OpenBrowser("Chrome", MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();

                bool flag = false;
                for (int i = 0; i < 5; i++ )
                {                    
                    FindCitationPage.DoCitationSearch(contentData[0]);
                    flag = FindCitationPage.VerifyDataAfterContentUploadFromSSR(contentData[0]);
                    if (flag) break;
                    System.Threading.Thread.Sleep(60000);
                }
                Assert.IsTrue(flag, "From SSR, data not getting uploaded to SBA,please check!!!");
                  
                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();

                //uploading original XML file to revert test data
                FrameworkBase.OpenBrowser("Chrome", MOGAConstants.ssrURL);
                SSRintegrationPage.NavigateHere();
                SSRintegrationPage.LoginToSSR(MOGAConstants.ssrUserName1, MOGAConstants.ssrPassWord1);
                SSRintegrationPage.SelectTab("Content Upload");
                SSRintegrationPage.NavigateHere();
                SSRintegrationPage.VerifyContentUploadPage();
                SSRintegrationPage.UploadFile("medline_medline14n0747_30Original");
                FrameworkBase.CloseBrowser();

                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);

            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        #region Initialize + Cleanup + Test Context
        [TestInitialize()]
        public void MyTestInitialize()
        {
            
           
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            MOGAConstants.logMessage = string.Empty;
            
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        #endregion

    }
}

