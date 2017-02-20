using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFExtract
{
    class Program
    {
        static void Main(string[] args)
        {

            string pathToPdf = @"D:\Nalco Global Automation Coding Standard and Style Guide 1.0.pdf";
            string pathToXml = Path.ChangeExtension(pathToPdf, ".xml");

            // Convert PDF file to XML file.
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();

            // This property is necessary only for registered version.
            //f.Serial = "XXXXXXXXXXX";

            // Let's convert only tables to XML and skip all textual data.
            f.XmlOptions.ConvertNonTabularDataToSpreadsheet = true;

            f.OpenPdf(pathToPdf);

            if (f.PageCount > 0)
            {
                int result = f.ToXml(pathToXml);

                //Show HTML document in browser
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(pathToXml);
                }
            }

            //SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
            //f.XmlOptions.ConvertNonTabularDataToSpreadsheet = true;
            //f.OpenPdf(@"d:\[STRAT-511] Associate Skills Groups with Departments - TeleTracking Technologies.pdf");
            //f.ToXml(@"d:\[STRAT-511] Associate Skills Groups with Departments - TeleTracking Technologies.xml");

        }
    }
}
