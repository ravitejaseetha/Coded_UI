using Excel;
using ExcelLibrary.SpreadSheet;
//using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel1 = Microsoft.Office.Interop.Excel;
namespace DataDriven
{
    class Program
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }

public static DataTable ExcelToDataTable(string fileName)
{
    //open file and returns as Stream
    FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
    //Createopenxmlreader via ExcelReaderFactory
    IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream); //.xls
    
   // IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream); //.xlsx
    //Set the First Row as Column Name
    excelReader.IsFirstRowAsColumnNames = true;
    //Return as DataSet
    DataSet result = excelReader.AsDataSet();
    //Get all the Tables
    DataTableCollection table = result.Tables;
    //Store it in DataTable
    DataTable resultTable = table["TestParameter"];
    
    //return
    return resultTable;
}
       
        List<Program> dataCol = new List<Program>();
        public void PopulateDataIncollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);
            
            for(int row = 1; row <= table.Rows.Count; row++)
            {
                for(int col = 0;col <table.Columns.Count; col++)
                {
                    Program p1 = new Program()
                    {
                    rowNumber = row,
                    colName = table.Columns[col].ColumnName,
                    colValue = table.Rows[row-1][col].ToString()
                    };
                    dataCol.Add(p1);
                }
            }
        }


        public void Form1_Load(List<string> data)
        {

            DataTable dt = new DataTable();
            //Add Datacolumn
            DataColumn workCol = dt.Columns.Add("Tokens", typeof(String));

            dt.Columns.Add("LastName", typeof(String));
            //dt.Columns.Add("Blog", typeof(String));
            //dt.Columns.Add("City", typeof(String));
            //dt.Columns.Add("Country", typeof(String));
            //dt.Columns.Add("Tokens", typeof(String));
            
            //Add in the datarow
            DataRow newRow = dt.NewRow();

            newRow["Tokens"] = "Arun";
            DataRow newRow1 = dt.NewRow();
            newRow1["Tokens"] = "Rao";

            //newRow["lastname"] = "Prakash";
            //newRow["Blog"] = "http://royalarun.blogspot.com/";
            //newRow["city"] = "Coimbatore";
            //newRow["country"] = "India";

            //dt.Rows.Add("Kri");
            //dt.Rows.Add("sda");

            foreach(string val in data)
            {
                dt.Rows.Add(val+"dgf");
            }

            var rows = dt.Rows;
         
            //open file
            StreamWriter wr = new StreamWriter(@"D:\\TeleTracking\\TestRunner.xls");

            try
            {

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    wr.Write(dt.Columns[i].ToString().ToUpper() + "\t");
                }

                wr.WriteLine();

                //write rows to excel file
                for (int i = 0; i < (dt.Rows.Count); i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i][j] != null)
                        {
                            wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
                        }
                        else
                        {
                            wr.Write("\t");
                        }
                    }
                    //go to next line
                    wr.WriteLine();
                }
                //close file
                wr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Linq using query

                //string data = (from colData in dataCol
                //               where colData.colName == columnName && colData.rowNumber == rowNumber
                //               select colData.colValue).SingleOrDefault();
              
                //LINQ using lambda expressions
                string data = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).Select(y => y.colValue).SingleOrDefault();
                return data.ToString();
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public List<string> ReadDataLi(string columnName)
        {
            try
            {
                //Linq using query

                //string data = (from colData in dataCol
                //               where colData.colName == columnName && colData.rowNumber == rowNumber
                //               select colData.colValue).SingleOrDefault();

                //LINQ using lambda expressions
                var data = dataCol.Where(x => x.colName == columnName).Select(y => y.colValue).ToList();
                return data;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public int CountRows(string columnName)
        {
            var count = dataCol.Where(x => x.colName == columnName).Count();
            return count;
        }

        static void Main(string[] args)
        {




            Program p2 = new Program();
            List<string> sample = new List<string>();
            p2.PopulateDataIncollection("D:\\TeleTracking\\TestRunner.xls");
            int StudentCount = p2.CountRows("StudentId");
            int TokenCount = p2.CountRows("Tokens");
           // Console.WriteLine(StudentCount+"\t"+TokenCount);
            int x = 0;
            for (int i = 1; i <= StudentCount; i++)
            {
                
                string va = p2.ReadDataLi("Tokens")[x];
                Console.WriteLine(va);
                sample.Add(p2.ReadData(i, "StudentId"));
                Console.WriteLine(sample[i-1]);
                x++;
            }
            Console.ReadKey();
           // p2.Form1_Load(sample);



            //create new xls file 
            //string file = "D:\\TeleTracking\\TestRunner.xls"; 
            //Workbook workbook = new Workbook(); 
            //Worksheet worksheet = new Worksheet("First Sheet1");

            //for (int i = 0; i < sample.Count(); i++)
            //{
            //    worksheet.Cells[i+1, 1] = new Cell(sample[i]);
            //}
            //worksheet.Cells[2, 0] = new Cell(9999999);
            //worksheet.Cells[3, 3] = new Cell((decimal)3.45); 
            //worksheet.Cells[2, 2] = new Cell("Text string");                                 
            //worksheet.Cells[2, 4] = new Cell("Second string"); 
            //worksheet.Cells[4, 0] = new Cell(32764.5, "#,##0.00");
            //worksheet.Cells[5, 1] = new Cell(DateTime.Now, @"YYYY-MM-DD");
            //worksheet.Cells.ColumnWidth[0, 1] = 3000; 
            //workbook.Worksheets.Add(worksheet); workbook.Save(file);

            // open xls file 
            //Workbook book = Workbook.Load(file);
            //Worksheet sheet = book.Worksheets[0];

            // traverse cells 
            //foreach (<Pair, Cell> cell in sheet.Cells) 
            //{ 
            //    dgvCells[cell.Left.Right, cell.Left.Left].Value = cell.Right.Value; 
            //}

            // traverse rows by Index 
            //for (int rowIndex = sheet.Cells.FirstRowIndex; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
            //{
            //    Row row = sheet.Cells.GetRow(rowIndex);
            //    for (int colIndex = row.FirstColIndex; colIndex <= row.LastColIndex; colIndex++) 
            //    { 
            //        Cell cell = row.GetCell(colIndex); 
            //    } 
            //} 
           
        }
    }
}
