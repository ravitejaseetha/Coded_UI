using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WinUtil
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CategoryTextbox.Enabled = false;
            TestTextbox.Enabled = false;

        }
        string Assembly;
        string Category;
        string Test;
        private void button1_Click(object sender, EventArgs e)
        {

            Assembly = AssemblyTextbox.Text;
            Category = CategoryTextbox.Text;
            Test = TestTextbox.Text;



            StringBuilder sb = new StringBuilder();
            var filePath = Directory.GetCurrentDirectory() + @"\TestResults\TestResult.trx";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            var htmlfilePath = Directory.GetCurrentDirectory() + @"\TestResults\TestResult.trx.html";
            if (File.Exists(htmlfilePath))
            {
                File.Delete(htmlfilePath);
            }
            var trxBat = Directory.GetCurrentDirectory() + @"\TestResult.bat";
            if (System.IO.File.Exists(trxBat))
            {
                File.Delete(trxBat);
            }
            TextWriter tw = new StreamWriter(trxBat, true);

            sb.Append(string.Format("\"{0}\"", @"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"));
         

            if (Assembly.Length == 0)
            {
                MessageBox.Show("Please enter your assembly name", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
            else
            {
                sb.Append(" " + Assembly + ".dll");
                if (Category.Length > 0)
                {
                    sb.Append(" /TestCaseFilter:"+ string.Format("\"{0}\"", "TestCategory="+ Category +""));

                }
                if (Test.Length > 0)
                {
                    sb.Append(" /tests:" + Test + "");
                }
                sb.Append(@" /Logger:trx");
                tw.Write(sb.ToString());
                tw.Close();
                var htmlBat = Directory.GetCurrentDirectory() + @"\TestResults\TestResultHtml.bat";
                if (System.IO.File.Exists(htmlBat))
                {
                    File.Delete(htmlBat);
                }
                RunBat("TestResult.bat");
                TextWriter tw1 = new StreamWriter(htmlBat, true);
                tw1.WriteLine(@"TrxerConsole.exe TestResult.trx");
                tw1.Close();
                var directory = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\TestResults\\");
                var myFile = (from f in directory.GetFiles("*.trx")
                              orderby f.LastWriteTime descending
                              select f).First();
                XmlDocument xml = new XmlDocument();
                var filename = Directory.GetCurrentDirectory() + "\\TestResults\\" + myFile.Name;

                xml.Load(filename); //myXmlString is the xml file in string //copying xml to string: string myXmlString = xmldoc.OuterXml.ToString();
                XmlNodeList elemList = xml.GetElementsByTagName("TestMethod");
                //XmlNodeList els = xml.GetElementsByTagName("StdOut");
                //XmlNodeList els1 = xml.GetElementsByTagName("Output");
                ////var vals = els[0].InnerText.Split(',');
                //XmlElement records = xml.CreateElement("Output");
                //xml.DocumentElement.AppendChild(records);
                for (int i = 0; i < elemList.Count; i++)
                {
                    if (!elemList[i].Attributes["className"].Value.Contains(','))
                    {
                        elemList[i].Attributes["className"].Value = elemList[i].Attributes["className"].Value + ",";
                    }

                }
                xml.Save(filename);
                System.IO.File.Move(filename, Directory.GetCurrentDirectory() + "\\TestResults\\" + "TestResult.trx");
                RunBat("TestResultHtml.bat");
                progressBar1.Value = 100;
                MessageBox.Show("Execution Completed and report has been generated", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Application.Exit();
            }

        }



        public void RunBat(string batFileName)
        {
            Process proc = null;
            string batDir = null;
            if (batFileName.Contains("Html"))
            {
                batDir = string.Format(Directory.GetCurrentDirectory() + "\\TestResults");
            }
            else
            {
                batDir = string.Format(Directory.GetCurrentDirectory());
            }

            proc = new Process();
            proc.StartInfo.WorkingDirectory = batDir;
            proc.StartInfo.FileName = batFileName;
            proc.StartInfo.CreateNoWindow = false;
            proc.Start();
            proc.WaitForExit();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }





        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //CategoryTextbox.Enabled = true;
            if (checkBox1.Checked == true)
            {
                checkBox2.Enabled = false;
                CategoryTextbox.Enabled = true;
            }
            if (checkBox1.Checked == false)
            {
                checkBox2.Enabled = true;
                CategoryTextbox.Clear();
                CategoryTextbox.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked == true)
            {
                checkBox1.Enabled = false;
                TestTextbox.Enabled = true;
            }
            if (checkBox2.Checked == false)
            {
                checkBox1.Enabled = true;
                TestTextbox.Clear();
                TestTextbox.Enabled = false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Show the color dialog.
            DialogResult result = colorDialog1.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                this.BackColor = colorDialog1.Color;
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }




    }
}
