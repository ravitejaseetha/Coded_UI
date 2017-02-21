using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace WKH.SeleniumFrameWork
{
    public static class ResultReport
    {
        public static DateTime startTime = DateTime.Now;
        public static DateTime endTime;
        public static TimeSpan durationOfExec;
        public static StringBuilder writeForHtml = new StringBuilder();
        public static StringBuilder testCaseDetails = new StringBuilder();
        public static StringBuilder stepDetails = new StringBuilder();
        public static int stepNo = 0;
        public static int testCaseCount = 0;
        //public static string finalReport = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "_" + string.Format("{0:dd-MMM-yyyy hh_mm_ss}", startTime) + ".html";
        public static string finalReport ;//= CommonMethods.pathforReport() + "_" + string.Format("{0:dd-MMM-yyyy hh_mm_ss}", startTime) + ".html";
        public static int totalTestCases = 0;
        public static int passedTestCases = 0;
        public static int failedTestCases = 0;
        public static string machineName = Environment.MachineName;
        public static string operatingSystem = GetOSFriendlyName();
        public static string userName = Environment.UserName;
        public static string testSummary = string.Empty;

        //This method is used to get operating system name
        public static string GetOSFriendlyName()
        {
            string osName = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (ManagementObject os in searcher.Get())
            {
                osName = os["Caption"].ToString();
                break;
            }
            return osName;
        }

        //This method is used to Add Test case details into Results file
        public static void AddTestCaseName(string testname, string browser, string testResult = "Pass")
        {
            stepNo = 0;

            if (testResult.ToLower() == "pass")
            {
                testCaseCount = testCaseCount + 1;

                stepDetails.Append(string.Format(
                    "<tr class='firstRow'><td><b>{0}</b></td><td><b>{1}</b></td><td><b>{2}</b></td><td><b>{3}</b></td><td><b>{4}</b></td><td><b>{5}</b></td</tr>", testname, "", "", browser, "", "Pass"));
            }
            else
            {
                stepDetails.Replace((string.Format(
                    "<tr class='firstRow'><td><b>{0}</b></td><td><b>{1}</b></td><td><b>{2}</b></td><td><b>{3}</b></td><td><b>{4}</b></td><td><b>{5}</b></td</tr>", testname, "", "", browser, "", "Pass")), (string.Format(
                    "<tr class='firstRow'><td><b>{0}</b></td><td><b>{1}</b></td><td><b>{2}</b></td><td><b>{3}</b></td><td><b>{4}</b></td><td><b>{5}</b></td</tr>", testname, "", "", browser, "", "<font color='red'>" + "Fail" + "</font>")));
            }
        }

        ////This method is used to Add failed Test case details into Results file
        //public static void AddFailedTestCaseName(string testname, string browser, string testResult = "Fail")
        //{
        //    var name1 = string.Format("<tr class='firstRow'><td><b>{0}</b></td><td><b>{1}</b></td><td><b>{2}</b></td><td><b>{3}</b></td><td><b>{4}</b></td><td><b>{5}</b></td</tr>", testname, "", "", browser, "", "Pass");
        //    var name2 = string.Format("<tr class='firstRow'><td><b>{0}</b></td><td><b>{1}</b></td><td><b>{2}</b></td><td><b>{3}</b></td><td><b>{4}</b></td><td><b>{5}</b></td</tr>", testname, "", "", browser, "", "<font color='red'>" + "Fail" + "</font>");
        //    stepDetails.Replace(name1, name2);
        //}

        //This method adds all test step details into results file under test case
        public static void AddTestStepDetails(string desription, string testResult = "Pass")
        {          
            stepNo = stepNo + 1;
            if (testResult.ToLower() == "pass")
            {

                stepDetails.Append(string.Format(
                       "<tr class='hide'><td></td><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td>", "", stepNo, desription, "", "", "Pass"));
            }
            else 
            {
                failedTestCases = failedTestCases + 1;
                stepDetails.Append(string.Format(
                  "<tr class='hide'><td></td><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td>", "", stepNo, desription, "", "", "<font color='red'>" + "Fail" + "</font>"));
            }
                        
        }
                
        //This method is used to write results into Html results report
        public static void WriteResults(string URL, string product, string testResult = "Pass")
        {                
                endTime = DateTime.Now;
                DateTime presentTime = DateTime.Now;
                durationOfExec = (endTime - startTime).Duration();

                var duration = String.Format("{0:00}:{1:00}:{2:00}", durationOfExec.Hours, durationOfExec.Minutes, durationOfExec.Seconds);
                var summary = "<tr><td>" + testCaseCount.ToString() + "</td><td style=" + "color" + ": " + "green" + ">" + testCaseCount.ToString() + "</td><td style=" + "color" + ": " + "red" + ">" + testCaseCount.ToString() + "</td></tr>";

                passedTestCases = testCaseCount - failedTestCases;
                using (var sr = new StreamReader(CommonMethods.PathToFrameworkProject() + @"\ResultReportTemplate.html"))
                {
                    writeForHtml.Append(sr.ReadToEnd());
                    writeForHtml.Replace("{ExecutionStartTime}", startTime.ToString());
                    writeForHtml.Replace("{URL}", URL);
                    writeForHtml.Replace("{OperatingSystem}", operatingSystem);
                    writeForHtml.Replace("{MachineName}", machineName);
                    writeForHtml.Replace("{TotalTestCases}", testCaseCount.ToString());
                    writeForHtml.Replace("{PASSED}", passedTestCases.ToString());
                    writeForHtml.Replace("{FAILED}", failedTestCases.ToString());
                    writeForHtml.Replace("{ExecutionEndTime}", endTime.ToString());
                    writeForHtml.Replace("{TotalExecutionTime}", duration);
                    writeForHtml.Replace("{TestCaseDetails}", stepDetails.ToString());
                }
            
                if (testSummary != "") writeForHtml.Replace(testSummary, summary);
                testSummary = "<tr><td>" + testCaseCount.ToString() + "</td><td style=" + "color" + ": " + "green" + ">" + testCaseCount.ToString() + "</td><td style=" + "color" + ": " + "red" + ">" + testCaseCount.ToString() + "</td></tr>";
            
                writeForHtml.Replace(endTime.ToString(), presentTime.ToString());

                finalReport = CommonMethods.PathForReport(product) + product+ "_" + string.Format("{0:dd-MMM-yyyy hh_mm_ss}", startTime) + ".html";
                using (var stream = new StreamWriter(finalReport))
                {
                    stream.Write(writeForHtml);
                }
                writeForHtml = new StringBuilder();            
            
            //System.Diagnostics.Process.Start(finalReport);
        }


    }
}
