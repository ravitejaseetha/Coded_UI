using System;
using System.Collections.Generic;
using Microsoft.CSharp;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;
using ExcelFile = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop;
using System.Reflection;
//using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
namespace ReportGeneration
{
    public class ExcelDataRead
    {
        public List<dynamic> ReadData(int columnNumber, int rowStart, int rowEnd)
        {
            ExcelFile.Application oXL = new ExcelFile.Application();
            //   ExcelFile.Workbook oWB = oXL.Workbooks.Open(Application.StartupPath + "\\PROJEKTSTATUS_GESAMT_neues_Layout.xlsm", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            ExcelFile.Workbook oWB1 = oXL.Workbooks.Open("d:\\Water Savings by Increasing Tower Cycles (v2.0).xlsm", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            ExcelFile.Worksheet oWS = oWB1.Worksheets[4] as ExcelFile.Worksheet;
            ExcelFile.Range range;
            range = oWS.UsedRange;
            //read first row, first cell value 
            List<dynamic> data = new List<dynamic>();
            for (int i = rowStart; i <= rowEnd; i++)
            {
                var val = (range.Cells[i, columnNumber] as ExcelFile.Range).Value2;
                data.Add((range.Cells[i, columnNumber] as ExcelFile.Range).Value2);
            }
            oWB1.Close();
            return data;
        }

        //public  void WriteData()
        //{
        //    ExcelFile.Application oXL = new ExcelFile.Application();
        //    ExcelFile.Workbook oWB = oXL.Workbooks.Open("d:\\Water Savings by Increasing Tower Cycles (v2.0).xlsm", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
        //    ExcelFile.Worksheet oWS = oWB.Worksheets[4] as ExcelFile.Worksheet;
        //    ExcelFile.Range range;
        //    range = oWS.UsedRange;
        //    //rename the Sheet name 
        //    // oWS.Name = "Excel Sheet";

        //    for (int i = 26; i < 36; i++)
        //    {
        //        oWS.Cells[i, 12] = i + 3;
        //    }
        //    oWB.Save();
        //    //oWB.SaveAs("d:\\Water Savings by Increasing Tower Cycles (v2.0).xlsm", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel1.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
        //    oWB.Close();

        //}
    }
}
