using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using WKH.APIAutomation.FieldedSearch.Utils;

namespace WKH.APIAutomation.FieldedSearch
{
    [Binding]
    public class FieldedSearchSteps
    {
        [Given(@"I set fieldname to '(.*)'")]
        public void GivenISetFieldnameTo(string fieldName)
        {
            FieldedSearchUtils.SetFieldNamefieldName(fieldName);
        }

        [Given(@"I set fieldName value to '(.*)'")]
        public void GivenISetFieldNameValueTo(string fieldNameValue)
        {
            FieldedSearchUtils.SetFieldNameValue(fieldNameValue);
        }

        [Given(@"I set products to '(.*)'")]
        public void GivenISetProductsTo(string products)
        {
            FieldedSearchUtils.SetProducts(products);
        }


        [Given(@"I set filterField to '(.*)'")]
        public void GivenISetFilterFieldTo(string filterField)
        {
            FieldedSearchUtils.SetFilterField(filterField);
        }

        [Given(@"I set filterQuery to '(.*)'")]
        public void GivenISetFilterQueryTo(string filterQuery)
        {
            FieldedSearchUtils.SetFilterQuery(filterQuery);
        }

        [Given(@"I set filterQuery list")]
        public void GivenISetFilterQueryList()
        {
            FieldedSearchUtils.SetFilterQueryList();

        }


        [Given(@"I set expected resultsetRow to '(.*)'")]
        public void GivenISetExpectedResultsetRowTo(int rows)
        {
            FieldedSearchUtils.SetExpectedResultSetRows(rows);
        }

        [Given(@"I set expected resultsetReturnFields to '(.*)'")]
        public void GivenISetExpectedResultsetReturnFieldsTo(string returnField)
        {
            FieldedSearchUtils.SetExpectedResultSetReturnFields(returnField);
        }


        [Given(@"I set expected resultsetReturnFields to returnfields '(.*)' and '(.*)'")]
        public void GivenISetExpectedResultsetReturnFieldsToAnd(string returnField1, string returnfield2)
        {
            if (ScenarioContext.Current.ScenarioInfo.Title.Equals("SingleFieldSearchwithPartialTerm") || ScenarioContext.Current.ScenarioInfo.Title.Equals("SingleFieldSearchwithSynonyms"))
            FieldedSearchUtils.SetExpectedResultSetReturnFields(returnField1, "SubTitle");
            else
                FieldedSearchUtils.SetExpectedResultSetReturnFields(returnField1, returnfield2);
        }

        [Given(@"I set the synonyms field to true")]
        public void GivenISetTheSynonymsFieldToTrue()
        {
            FieldedSearchUtils.SetSynonymsToTrue();
        }


        [Given(@"I Generate the Search Request Body")]
        public void GivenIGenerateTheSearchRequestBody()
        {
            FieldedSearchUtils.GenerateSearchRequestBodyForFieldedSearchWithJournalName();
        }


        [When(@"I post the request to searchAPI")]
        public void WhenIPostTheRequestToSearchAPI()
        {
            FieldedSearchUtils.PostSearchAPIWithJournalName();
        }

        [Then(@"I should get a response in JSON format")]
        public void ThenIShouldGetAResponseInJSONFormat()
        {
            FieldedSearchUtils.GetFieldedsearchWithJounrnalNameResponseInJSONFormat();
        }

        [Then(@"The response should have '(.*)' number of result field")]
        public void ThenTheResponseShouldHaveNumberOfResultRows(int expectedRowCount)
        {
            Assert.IsTrue(FieldedSearchUtils.IsRowCountOfResultSetMatchesExpectedRowCOunt(expectedRowCount), "The number of result row exceeds expected row count" );
        }

        [Then(@"Every resultSet member should have Fields of (.*) member named '(.*)'")]
        public void ThenEveryResultSetMemberShouldHaveFieldsOfMemberNamed(int searchresultFieldCount, string expectedFieldName)
        {
            Assert.IsTrue(FieldedSearchUtils.DoesEverySearchResultHaveFieldCount(searchresultFieldCount));
            Assert.IsTrue(FieldedSearchUtils.DoesEverySearchResultFieldsFieldNamesAreExpected(expectedFieldName));
        }


        [Then(@"Every resultSet member should have Fields of (.*) members named '(.*)'and '(.*)'")]
        public void ThenEveryResultSetMemberShouldHaveFieldsOfMembersNamedAnd(int searchresultFieldCount, string expectedField1, string expectedField2)
        {
            Assert.IsTrue(FieldedSearchUtils.DoesEverySearchResultHaveFieldCount(searchresultFieldCount));
            Assert.IsTrue(FieldedSearchUtils.DoesEverySearchResultFieldsFieldNamesAreExpected(expectedField1, expectedField2));
        }

        [Then(@"Every FieldName value in the resultSet should contain any substring of the fieldName value '(.*)'")]
        public void ThenEveryFieldNameValueInTheResultSetShouldContainAnySubstringOfTheFieldNameValue(string fieldvalue)
        {
            Assert.IsTrue(FieldedSearchUtils.DoAllTitleValueContainsSubStringOfSearchString(fieldvalue));
        }

        [Then(@"Every FilterField in the resultSet should contain any substring of the FilterField value '(.*)'")]
        public void ThenEveryFilterFieldInTheResultSetShouldContainAnySubstringOfTheFilterFieldValue(string fieldvalue)
        {
            Assert.IsTrue(FieldedSearchUtils.DoAllJournalNameValueContainsSubStringOfProductvalue(fieldvalue));
        }


        [Then(@"The First field name of the result fields should match '(.*)'")]
        public void ThenTheFirstFieldNameOfTheResultFieldsShouldMatch(string expectedFieldName)
        {
          Assert.IsTrue(FieldedSearchUtils.DoesFirstFieldNameMatchExpectedValue(expectedFieldName),"The first field name does not match fieldname: {0}" , expectedFieldName);
        }

        [Then(@"Any of the two fields value should contain substring of '(.*)'")]
        public void ThenAnyOfTheTwoFieldsValueShouldContainSubstringOf(string searchstring)
        {
          Assert.IsTrue(FieldedSearchUtils.EitherOfFieldValueContainsSubstringOfSearchString( searchstring));

        }

        [Then(@"The SDC field value of each result member should be equal to '(.*)'")]
        public void ThenTheSDCFieldValueOfEachResultMemberShouldBeEqualTo(string sdcFlag)
        {
            Assert.IsTrue(FieldedSearchUtils.EitherOfFieldValueContainsSubstringOfSearchString(sdcFlag));
        }


    }
}
