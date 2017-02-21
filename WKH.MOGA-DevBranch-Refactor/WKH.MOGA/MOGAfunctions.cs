using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace WKH.MOGA
{
    public class MOGAFunctions
    {
        #region Read data from Excel

        /// <summary>
        /// Reading Excel data from Test Data Sheet as per the provided select query
        /// </summary>
        /// <param name="query">Select query to be executed on Excel</param>
        /// <returns>DataTable having results of passed select query, null in case of no data</returns>
        public DataTable ReadExcelTable(string query)
        {
            try
            {
                string path = MOGAConstants.mogaRegTestDataFile;

                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "; Jet OLEDB:Engine Type=5;Extended Properties=\"Excel 8.0;\"";

                DataTable excelDataTable = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(query, connString);
                da.Fill(excelDataTable);

                return excelDataTable;
            }
            catch(Exception ex)
            {
                throw new Exception("Exception while reading data from Excel :"+ex.Message);
            }

        }

        /// <summary>
        ///Get Value of specific key in EnvironmentData sheet of TestData Excel.
        /// </summary>
        /// <param name="key">key value</param>
        /// <returns>Value of specified key</returns>
        public string GetEnvironmentData(string key)
        {
            string query = "SELECT [Value] FROM [EnvironmentData$] where Key ='" + key + "'";
            DataTable excelDataTable = ReadExcelTable(query);

           return excelDataTable.Rows[0][0]!=null?excelDataTable.Rows[0][0].ToString():"";
        }

        /// <summary>
        /// Get Testdata of a given test case from TestData Excel.
        /// </summary>
        /// <param name="testcaseName">Testcase Name</param>
        /// <returns>List of TestData having user credentials,database etc</returns>
        public List<TestData> ReadDatafromExcel(string testcaseName)
        {
            string query = "SELECT [TestCaseName],[UserDetails],[DB],[SearchTerm] FROM [TestData$] where TestCaseName ='" + testcaseName + "'";

            DataTable excelDataTable = ReadExcelTable(query);
            List<TestData> testData = new List<TestData>();
            int i = 0;
            string[] userdetails, database, searchTerm, userCredentials = null;
            string testCaseName = null;
            for (int x = 0; x < excelDataTable.Rows.Count; x++)
            {
                testCaseName = excelDataTable.Rows[x][0].ToString();
                userdetails = excelDataTable.Rows[x][1].ToString().Split(';');
                database = excelDataTable.Rows[x][2].ToString().Split(';');
                searchTerm = excelDataTable.Rows[x][3].ToString().Split(';');

                foreach (string item in userdetails)
                {
                    userCredentials = item.Split('/');

                    TestData ts = new TestData();
                    ts.userName = userCredentials[0];
                    ts.password = userCredentials[1];
                    ts.database = database[i];
                    ts.searchTerm = searchTerm[i];
                    i++;
                    testData.Add(ts);
                    if (MOGAConstants.runForMultipleUser == "N")
                    {
                        break;
                    }
                }
            }
            return testData;
        }

        /// <summary>
        /// Get Testdata of a given test case from specified TestData Excel sheet.
        /// </summary>
        /// <param name="testcaseName">Testcase Name</param>
        /// <param name="dataBase">Testdata Excel sheet Name</param>
        /// <returns>List of TestData </returns>
        public List<string> ReadTestDatafromExcel(string testcaseName, string dataBase)
        {
            string query = "SELECT * FROM ["+dataBase+"$]";

            DataTable excelDataTable = ReadExcelTable(query);

            List<string> searchTerm = new List<string>();

            foreach (DataRow row in excelDataTable.Rows)
            {               
                if (!string.IsNullOrEmpty(row[testcaseName].ToString().Trim()))
                searchTerm.Add(row[testcaseName].ToString());
            }
            return searchTerm;
        }

        //Still need to modify
        /// <summary>
        /// Reads testdata according to database sheet and returns values from two columns of test data 
        /// </summary>
        /// <param name="fieldName">Field Name to get </param>
        ///  <param name="fieldValue">Field Value to get</param>
        /// <param name="SheetName">TestData Excel sheet Name</param>
        /// <returns>List of TestData having user credentials,database etc</returns>
         public Dictionary<string, string> ReturnTestDataOfTwoColumnsFromExcel(string fieldName, string fieldValue, string SheetName)
        {

            string query = "SELECT [" + fieldName + "],[" + fieldValue + "] FROM [" + SheetName + "$]";

            DataTable excelDataTable = ReadExcelTable(query);
            Dictionary<string, string> fieldData = new Dictionary<string, string>();

            for (int x = 0; x < excelDataTable.Rows.Count; x++)
            {
                if (!string.IsNullOrEmpty(excelDataTable.Rows[x][0].ToString().Trim()))
                    fieldData.Add(excelDataTable.Rows[x][0].ToString(), excelDataTable.Rows[x][1].ToString());
            }
            return fieldData;
        }

        /// <summary>
        /// Reads cell values of specified columns in sheet
        /// </summary>
        /// <param name="fieldNames">Field Name to get </param>
        /// <param name="sheetName">TestData Excel sheet Name</param>
        /// <returns>List of string : cell values of specified columns in sheet</returns>
        public List<string>[] GetColumnsFromExcel(List<string> fieldNames, string sheetName)
        {
           
            int count = fieldNames.Count;
            List<string>[] returnValue = new List<string>[count];
            for (int i = 0; i < returnValue.Length; i++)
            {
                returnValue[i] = new List<string>();
            }

           string query = "SELECT ";


            for (int i = 0; i < count; i++)
            {
                query += "[";
                query += fieldNames[i];
                query += "]";

                if (i < count - 1)
                {
                    query += ",";
                }
            }
            query += " FROM [";
            query += sheetName;
            query += "$]";

            DataTable excelDataTable = ReadExcelTable(query);

            for (int row = 0; row < excelDataTable.Rows.Count; row++)
            {
                for (int col = 0; col < excelDataTable.Columns.Count; col++)
                {
                    if (excelDataTable.Rows[row][col]!=null)
                    {
                        if (excelDataTable.Rows[row][col].ToString().Length > 0)
                        {
                            returnValue[row].Insert(col, excelDataTable.Rows[row][col].ToString());
                        }
                    }
                }
            }
            return returnValue;
        }

        # endregion
        public void WriteLogToExcelFile(string testcaseName, string logMessage)
        {
            string connString = "";
            string path = MOGAConstants.mogaRegTestDataFile;

            connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "; Jet OLEDB:Engine Type=5;Extended Properties=\"Excel 8.0;\"";
            using (OleDbConnection MyConnection = new OleDbConnection(connString))
            {
                System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();
                myCommand.Connection = MyConnection;
                MyConnection.Open();
                string sql = null;

                string status = "Fail";
                if (logMessage == null)
                {
                    logMessage = "Passed";
                    status = "Pass";
                }
                sql = "Update [TestData$] set Log = '" + logMessage + "', Status = '" + status + "' where TestCaseName ='" + testcaseName + "'";
                myCommand.CommandText = sql;
                myCommand.ExecuteNonQuery();
                MyConnection.Close();
            }
          
        }

 
        //This function verifies the word in the Array of words
        public  bool VerifySearchTermInArray(string term, string[] expArray)
        {
            bool result = false;

            foreach (string actTerm in expArray)
            {
                if (term.ToLower().Contains(actTerm.ToLower()))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        // Input - field Value, left Term, Operation and right Term
        public  void CheckBothTermInField(string theFieldData, string leftTerm, string operation, string rightTerm, ref bool leftFlag, ref bool rightFlag)
        {
            if (operation.Equals("and") || operation.Equals("or"))
            {
                // either left or right term should present
                if ((theFieldData.Contains(leftTerm)))
                {
                    leftFlag = true;
                }
                if (theFieldData.Contains(rightTerm))
                {
                    rightFlag = true;
                }
                return;
            }
            else if (operation.Equals("not"))
            {
                //  left term should present but the right should not..
                if ((theFieldData.Contains(leftTerm)))
                {
                    leftFlag = true;
                }
                if (!theFieldData.Contains(rightTerm))
                {
                    rightFlag = true;
                }
                return;
            }

            return;
        }
    }

  
    
}
