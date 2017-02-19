using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlReport
{
    class Program
    {
        static void Main(string[] args)
        {
            var dlls = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll");
            List<string> dll = new List<string>();
            foreach (var item in dlls)
            {
                dll.Add(Path.GetFileName(item));
            }
       
            var filePath = Directory.GetCurrentDirectory() + @"\TestResult.trx";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            var htmlfilePath = Directory.GetCurrentDirectory() + @"\TestResult.trx.html";
            if (File.Exists(htmlfilePath))
            {
                File.Delete(htmlfilePath);
            }

            StringBuilder sb = new StringBuilder();

            var trxBat = Directory.GetCurrentDirectory() + @"\TestResult.bat";
            if (System.IO.File.Exists(trxBat))
             {
                 File.Delete(trxBat);
             }
            TextWriter tw = new StreamWriter(trxBat, true);

            sb.Append(string.Format("\"{0}\"", @"C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe.exe"));
             foreach (var item in dll)
	         {
                 sb.Append(" /testcontainer:" + item + "");
	         }
             sb.Append(" /resultsfile:TestResult.trx");
             tw.Write(sb.ToString());
             tw.Close();
             var htmlBat = Directory.GetCurrentDirectory() + @"\TestResultHtml.bat";
             if (System.IO.File.Exists(htmlBat))
             {
                 File.Delete(htmlBat);
             }
             TextWriter tw1 = new StreamWriter(htmlBat, true);
             tw1.WriteLine(@"TrxerConsole.exe TestResult.trx");
             tw1.Close();
             RunBat("TestResult.bat");
             RunBat("TestResultHtml.bat");
        }

        public static void RunBat(string batFileName)
        {
            Process proc = null;
            string batDir = string.Format(Directory.GetCurrentDirectory());
            proc = new Process();
            proc.StartInfo.WorkingDirectory = batDir;
            proc.StartInfo.FileName = batFileName;
            proc.StartInfo.CreateNoWindow = false;
            proc.Start();
            proc.WaitForExit();
        }
    }
}
