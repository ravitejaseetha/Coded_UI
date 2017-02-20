using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class DataDriven
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

        List<DataDriven> dataCol = new List<DataDriven>();
        public void PopulateDataIncollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    DataDriven p1 = new DataDriven()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    dataCol.Add(p1);
                }
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
            catch (Exception e)
            {
                return null;
            }
        }

        public void SendData(string fileName,int rowNumber,string columnName)
        {
            PopulateDataIncollection(fileName);
            ReadData(rowNumber, columnName);
        }
    }
}
