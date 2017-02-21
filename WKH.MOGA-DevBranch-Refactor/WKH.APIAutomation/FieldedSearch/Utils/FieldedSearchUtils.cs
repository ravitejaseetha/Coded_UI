using AutomationCore.API.Framework.Common;
using AutomationCore.API.Framework.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WKH.APIAutomation.Common;
using WKH.APIAutomation.FieldedSearch.Requests;
using WKH.APIAutomation.FieldedSearch.Responses;

namespace WKH.APIAutomation.FieldedSearch.Utils
{
    public class FieldedSearchUtils
    {
        public static string FieldName { get; set; }
        public static string FieldNameValue { get; set; }
        public static List<string> Products { get; set; }
        public static string FilterField { get; set; }
        public static string FilterQuery { get; set; }
        public static int ExpectedResultSetRows { get; set; }
        public static List<string> ExpectedResultSetReturnFields { get; set; }
        public static List<string> FilterQueries { get; set; }
        public static bool IsSynonymsRequired { get; set; }

        public static string baseWKSearchFiledAPIUrl = @"http://devplatformservices.azure-api.net/search/fielded";

        public string setBaseUrlForWKSearchFiledAPI()
        {
            return baseWKSearchFiledAPIUrl;
        }

        public static string FieldedSearchWithJournalNameValidResuestString = string.Empty;
        public static string FieldedSearchWithJournalNameValidResponseString = string.Empty;
        public static ValidFieldedSearchResponseWithJournalName validFieldedSearchJSONResponseWithJournalName;
        // private static List<ResultsClass> lstResult = validFieldedSearchJSONResponseWithJournalName.Results;

        public FieldedSearchUtils()
        {
            IsSynonymsRequired = false;

        }

        internal static void SetFieldNamefieldName(string fieldName)
        {
            FieldName = fieldName;
        }

        internal static void SetFieldNameValue(string fieldNameValue)
        {
            FieldNameValue = fieldNameValue;
        }

        internal static void SetProducts(string products)
        {
            Products = products.Split(',').ToList();

        }


        internal static void SetFilterField(string filterField)
        {
            FilterField = filterField;
        }

        internal static void SetFilterQuery(string filterQuery)
        {
            FilterQuery = filterQuery;
        }

        internal static void SetExpectedResultSetRows(int rows)
        {
            ExpectedResultSetRows = rows;
        }

        internal static void SetExpectedResultSetReturnFields(params string[] returnedFields)
        {
            List<string> lstReturnedFields = new List<string>();
            foreach (string field in returnedFields)
            {
                lstReturnedFields.Add(field);
            }
            ExpectedResultSetReturnFields = lstReturnedFields;
        }

        internal static void SetFilterQueryList()
        {
            List<string> lstFilterQuery = new List<string>();
            lstFilterQuery.Add(FilterField + ":" + FilterQuery);
            FilterQueries = lstFilterQuery;
        }

        /// <summary>
        /// Generate a search request body for fielded search with journal name
        /// </summary>
        internal static void GenerateSearchRequestBodyForFieldedSearchWithJournalName()
        {
            FieldedSearchValidRequest fieldedSearchValidRequest = new FieldedSearchValidRequest();
            fieldedSearchValidRequest.QueryString = FieldName + ":" + FieldNameValue;
            fieldedSearchValidRequest.Products = Products;
            fieldedSearchValidRequest.FilterQueries = FilterQueries;
            ResultSpecClass resultSpecClass = new ResultSpecClass();
            resultSpecClass.Rows = ExpectedResultSetRows;
            resultSpecClass.ReturnFields = ExpectedResultSetReturnFields;
            fieldedSearchValidRequest.ResultSpec = resultSpecClass;
            fieldedSearchValidRequest.SynonymsRequired = IsSynonymsRequired;

            FieldedSearchWithJournalNameValidResuestString = JsonConvert.SerializeObject(fieldedSearchValidRequest);

        }

        internal static void PostSearchAPIWithJournalName()
        {
            FieldedSearchWithJournalNameValidResponseString = RestClientUtil.DoHttpRequest(baseWKSearchFiledAPIUrl, HeaderSettings.PostMethod, HeaderSettings.JsonMediaType,
                                              FieldedSearchWithJournalNameValidResuestString, HttpStatusCode.OK);
        }

        internal static bool DoesEverySearchResultHaveFieldCount(int searchresultFieldCount)
        {
            bool flag = false;
            foreach (ResultsClass item in validFieldedSearchJSONResponseWithJournalName.Results)
            {
                if (item.Fields.Count == searchresultFieldCount)
                {
                    flag = true;
                    continue;
                }
                else
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        internal static bool DoesEverySearchResultFieldsFieldNamesAreExpected(string expectedField1, string expectedField2)
        {
            bool flag = false;

            foreach (ResultsClass item in validFieldedSearchJSONResponseWithJournalName.Results)
            {
                int fieldCount = item.Fields.Count;
                for (int i = 0; i < fieldCount; i++)
                {
                    if (item.Fields[i].FieldName.Equals(expectedField1) || item.Fields[i].FieldName.Equals(expectedField2))
                    {
                        flag = true;
                        continue;
                    }
                    else
                    {
                        flag = false;
                        return flag;
                    }
                }
            }

            return flag;
        }

        internal static bool DoesEverySearchResultFieldsFieldNamesAreExpected(string expectedField)
        {
            bool flag = false;

            foreach (ResultsClass item in validFieldedSearchJSONResponseWithJournalName.Results)
            {
                if (item.Fields[0].FieldName.Equals(expectedField))
                {
                    flag = true;
                    continue;
                }
                else
                {
                    flag = false;
                    return flag;
                }
            }
            return flag;
        }




        internal static void GetFieldedsearchWithJounrnalNameResponseInJSONFormat()
        {
            validFieldedSearchJSONResponseWithJournalName = CommonUtils.DeserializeToJSON<ValidFieldedSearchResponseWithJournalName>(FieldedSearchWithJournalNameValidResponseString);
        }

        internal static bool IsRowCountOfResultSetMatchesExpectedRowCOunt(int expectedRowCount)
        {
            return validFieldedSearchJSONResponseWithJournalName.Results.Count <= expectedRowCount;
        }

        internal static bool DoAllTitleValueContainsSubStringOfSearchString(string fieldvalue)
        {
            List<string> lsttitles = GetTitles();
            return lsttitles.Any(fieldvalue.Contains);
        }

        private static List<string> GetTitles()
        {
            List<ResultsClass> lstResult = validFieldedSearchJSONResponseWithJournalName.Results;
            List<string> titleValueList = new List<string>();
            foreach (ResultsClass item in lstResult)
            {
                titleValueList.Add(item.Fields[0].FieldValue.ToString());
            }
            return titleValueList;
        }

        internal static bool DoAllJournalNameValueContainsSubStringOfProductvalue(string fieldvalue)
        {
            List<string> lstProductNames = GetProductNames();
            return lstProductNames.Any(fieldvalue.Contains);
        }

        private static List<string> GetProductNames()
        {
            List<string> productValueList = new List<string>();
            List<ResultsClass> lstResult = validFieldedSearchJSONResponseWithJournalName.Results;
            foreach (ResultsClass item in lstResult)
            {
                productValueList.Add(item.Fields[1].FieldValue.ToString());
            }
            return productValueList;
        }

        internal static bool DoesFirstFieldNameMatchExpectedValue(string expectedFieldName)
        {
            bool flag = false;
            List<ResultsClass> lstResult = validFieldedSearchJSONResponseWithJournalName.Results;
            if (lstResult.Count > 0)
            {
                for (int i = 0; i < lstResult.Count; i++)
                {
                    if (lstResult[i].Fields.Count > 0)
                    {
                        if (lstResult[i].Fields[0].FieldName.Equals(expectedFieldName) || lstResult[i].Fields[0].FieldName.Equals("SubTitle"))
                        {
                            flag = true;
                            continue;
                        }
                        else
                        {
                            Assert.Fail("The first field name of the record number {0} doest not match {1} or SubTitle ", i + 1, expectedFieldName);
                            return false;
                        }
                    }
                    else
                    {
                        Assert.Fail("There record number {0} does not have any field member", i + 1);
                    }
                }
            }
            else
            {
                Assert.Fail("No Record found");
            }


            return flag;
        }

        internal static bool EitherOfFieldValueContainsSubstringOfSearchString(string searchstring)
        {
            string searchStringToLower = searchstring.ToLower();
            List<string> lstSearchTermSubStrings = searchStringToLower.Split(' ').ToList();
            List<ResultsClass> lstResult = validFieldedSearchJSONResponseWithJournalName.Results;
            int resultCount = lstResult.Count;
            for (int i = 0; i < resultCount; i++)
            {
                if (!DoesNthFieldOfResultListContainsSubStringOfSearchString(lstResult[i].Fields, lstSearchTermSubStrings, 1))
                {
                    if (lstResult[i].Fields.Count > 0)
                    {
                        if (lstResult[i].Fields.Count > 1)
                        {
                            if (!DoesNthFieldOfResultListContainsSubStringOfSearchString(lstResult[i].Fields, lstSearchTermSubStrings, 2))
                            {
                                Assert.Fail("There is no substring of {0} in Both Title and SubTitle in record number {1}", searchstring, i + 1);
                                return false;
                            }
                        }
                        else
                        {
                            Assert.Fail("There is no substring of {0} in Both Title and SubTitle in record number {1}", searchstring, i + 1);
                            return false;
                        }
                    }
                    else
                    {
                        Assert.Fail("There record number {0} does not have any field member", i + 1);
                    }
                }

            }
            return true;
        }



        private static bool DoesNthFieldOfResultListContainsSubStringOfSearchString(List<FieldsClass> resultField, List<string> searchstring, int index)
        {
            bool x = searchstring.Any(resultField[index - 1].FieldValue.ToString().ToLower().Contains);
            return x;
        }

        internal static void SetSynonymsToTrue()
        {
            IsSynonymsRequired = true;
        }
    }
}
