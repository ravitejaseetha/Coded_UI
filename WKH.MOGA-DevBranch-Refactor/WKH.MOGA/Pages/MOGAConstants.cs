using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WKH.MOGA
{
    public class MOGAConstants
    {

        public static readonly ILog log = LogManager.GetLogger(typeof(MOGAConstants));
        public void LoggingTests()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static MOGAFunctions mogaFunctions = new MOGAFunctions();

        public static string mogaRegTestDataFile = Environment.CurrentDirectory +ConfigurationManager.AppSettings["MOGATestDataFileRelativePath"].ToString();
        public static string browserType = mogaFunctions.GetEnvironmentData("BrowserType");
        public static string appURL = ConfigurationManager.AppSettings["MOGAUrl"].ToString();
        public static string appDutchURL = ConfigurationManager.AppSettings["MOGADutchUrl"].ToString();
        public static string appDashBoardAdminURL = ConfigurationManager.AppSettings["MOGAdashBoardAdminUrl"].ToString();
        public static string appRegistrationPageURL = ConfigurationManager.AppSettings["MOGARegistrationPageUrl"].ToString();
        public static string reportPath = ConfigurationManager.AppSettings["ReportPath"].ToString();
        public static string ssrURL =MOGAConstants.mogaFunctions.GetEnvironmentData("SSRUrl");
        public static string productName =MOGAConstants.mogaFunctions.GetEnvironmentData("Product");
        public static string runForMultipleUser =MOGAConstants.mogaFunctions.GetEnvironmentData("TestDataPerameterization");
        public static string dataBaseName =MOGAConstants.mogaFunctions.GetEnvironmentData("DataBase");
        public static string logMessage = string.Empty;
        public static string userName1 =MOGAConstants.mogaFunctions.GetEnvironmentData("UserName1");
        public static string passWord1 =MOGAConstants.mogaFunctions.GetEnvironmentData("Password1");
        public static string userName2 =MOGAConstants.mogaFunctions.GetEnvironmentData("UserName2");
        public static string passWord2 =MOGAConstants.mogaFunctions.GetEnvironmentData("Password2");
        public static string mogaAdminUserid =MOGAConstants.mogaFunctions.GetEnvironmentData("AdminUsername");
        public static string mogaAdminPwd =MOGAConstants.mogaFunctions.GetEnvironmentData("AdminPwd");
        public static string inValidUserName1 =MOGAConstants.mogaFunctions.GetEnvironmentData("InValidUserName1");
        public static string inValidPassWord1 =MOGAConstants.mogaFunctions.GetEnvironmentData("InValidPassword1");
        public static string dashBoardAdminUid =MOGAConstants.mogaFunctions.GetEnvironmentData("DashBoardAdminUname");
        public static string dashBoardAdminPwd =MOGAConstants.mogaFunctions.GetEnvironmentData("DashBoardAdminPwd");
        public static string outLookUrl = ConfigurationManager.AppSettings["OutlookURL"].ToString();
        public static string outLookUid = ConfigurationManager.AppSettings["OutlookUserID"].ToString();
        public static string outLookPwd = ConfigurationManager.AppSettings["OutlookPwd"].ToString();
        public static string ssrUserName1 =MOGAConstants.mogaFunctions.GetEnvironmentData("ssrUserName1");
        public static string ssrPassWord1 =MOGAConstants.mogaFunctions.GetEnvironmentData("ssrPassword1");
	    public static string searchItem =MOGAConstants.mogaFunctions.GetEnvironmentData("SearchItem");
		public static string expectedResult =MOGAConstants.mogaFunctions.GetEnvironmentData("Expected");


		public static string strMedline = "MEDLINE";
        public static string strJournals = "Journals";
        public static string strAllResources = "All";

       

    }
}
