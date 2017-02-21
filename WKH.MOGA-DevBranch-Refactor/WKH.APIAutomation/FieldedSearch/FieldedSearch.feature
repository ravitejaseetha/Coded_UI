@FieldedSearch
Feature: FieldedSearch
	In order to get proper search results with field(s) value(es)
	As a tester
	I want to test the API for fielded search

 @Filters
Scenario Outline: SearchFieldWithFilters
	Given I set fieldname to '<fieldName>'
		And I set fieldName value to '<query>'
		And I set products to '<products>'
		And I set filterField to '<FilterField>'
		And I set filterQuery to '<FilterQuery>'
		And I set filterQuery list 
		And I set expected resultsetRow to '<Rows>'
		And I set expected resultsetReturnFields to returnfields '<fieldName>' and '<FilterField>'
		And I Generate the Search Request Body
	When I post the request to searchAPI
	Then I should get a response in JSON format
		And The response should have '<Rows>' number of result field
		And The First field name of the result fields should match '<fieldName>'
		And Any of the two fields value should contain substring of '<expectedFilterString>'
	Examples: 
	| Description                    | fieldName   | query                                     | products | FilterField         | FilterQuery            | expectedFilterString   | Rows |
	| TitleJournalName               | Title       | Reconstruction of Partial Vaginal Defects | precos   | JournalName         | Reconstructive Surgery | Reconstructive Surgery | 100  |
	| JournalNamePublicationDateYear | JournalName | Plastic and Reconstructive Surgery        | precos   | PublicationDateYear | 2016                   | 2016                   | 100  |
	| JournalNameFirstAuthor         | JournalName | Reconstructive Surgery Global Open        | prcsgo   | FirstAuthor         | Latham kerry           | Latham kerry           | 100  |


@PartialTerm
Scenario Outline: SingleFieldSearchwithPartialTerm
Given I set fieldname to '<fieldName>'
		And I set fieldName value to '<query>'
		And I set products to '<JournalNames>'		
		And I set expected resultsetRow to '<Rows>'
		And I set expected resultsetReturnFields to returnfields '<fieldName>' and '<Subtitle>'
		And I Generate the Search Request Body
	When I post the request to searchAPI
	Then I should get a response in JSON format
		And The response should have '<Rows>' number of result field
		And The First field name of the result fields should match '<fieldName>'
		And Any of the two fields value should contain substring of '<expectedFilterString>'		
	Examples: 
	| Description                                               | fieldName           | query                                                | JournalNames | expectedFilterString                                 | Rows |
	| TitlePlasticSurgery                                       | Title               | plastic surgery                                      | precos       | Reconstructive Surgery                               | 100  |
	| TitleRECONSTRUCTION                                       | Title               | RECONSTRUCTION                                       | precos       | RECONSTRUCTION                                       | 100  |
	| TitleMedicalCenter                                        | Title               | Medical Cen ter                                      | precos       | Medical Cen ter                                      | 100  |
	| AuthorsMARINO                                             | Authors             | MARINO                                               | precos       | MARINO                                               | 100  |
	| JournalNamePlastiandReconstructiveSurgery                 | JournalName         | Plastic and Reconstructive Surgery                   | precos       | Plastic and Reconstructive Surgery                   | 100  |
	| Volume106                                                 | Volume              | 106                                                  | precos       | 106                                                  | 100  |
	| PageRange1152-1153                                        | PageRange           | 1152-1153                                            | precos       | 1152 1153                                            | 100  |
	| PageRange889                                              | PageRange           | 889                                                  | precos       | 889                                                  | 100  |
	| AccessionNumber00006534-201505000-00035                   | AccessionNumber     | 00006534-201505000-00035                             | precos       | 00006534-201505000-00035                             | 100  |
	| Issue4                                                    | Issue               | 4                                                    | precos       | 4                                                    | 100  |
	| ISSN"print, 0032-1052"                                    | ISSN                | "print, 0032-1052"                                   | precos       | print, 0032-1052                                     | 100  |
	| PublicationDate                                           | PublicationDate     | "2003-01-01T00:00:00Z"                               | precos       | 2003                                                 | 100  |
	| ePublicationDate                                          | ePublicationDate    | "1997-04-1T00:00:00Z"                                | precos       | 1997                                                 | 100  |
	| PublicationDateYear2000                                   | PublicationDateYear | 2000                                                 | precos       | 2000                                                 | 100  |
	| PublicationTitle\"Plastic and Reconstructive Surgery\"    | PublicationTitle    | \"Plastic and Reconstructive Surgery\"               | precos       | Plastic and Reconstructive Surgery                   | 100  |
	| JournalNamePlastic and Reconstructive Surgery             | JournalName         | Plastic and Reconstructive Surgery                   | precos       | Plastic and Reconstructive Surgery                   | 100  |
	| JournalNameReconstructive Surgery Global Open             | JournalName         | Reconstructive Surgery Global Open                   | prcsgo       | Reconstructive Surgery Global Open                   | 100  |
	| OriginalTitleClassification                               | OriginalTitle       | Classification                                       | precos       | Classification                                       | 100  |
	| FirstPage889                                              | FirstPage           | 889                                                  | precos       | 889                                                  | 100  |
	| Copyright©2000American Society of Plastic Surgeons        | Copyright           | ©2000American Society of Plastic Surgeons            | precos       | ©2000American Society of Plastic Surgeons            | 100  |
	| CopyrightPlastic Surgeons                                 | Copyright           | Plastic Surgeons                                     | precos       | Plastic Surgeons                                     | 100  |
	| FirstAuthorDINGMAN REED                                   | FirstAuthor         | DINGMAN REED                                         | precos       | DINGMAN REED                                         | 100  |
	| FirstAuthorREED                                           | FirstAuthor         | REED                                                 | precos       | REED                                                 | 100  |
	| AuthorsSTRAATSMA                                          | Authors             | STRAATSMA                                            | precos       | STRAATSMA                                            | 100  |
	| AffiliationsYaleUniversitySchoolofMedicine                | Affiliations        | Yale University School of Medicine                   | precos       | Yale University School of Medicine                   | 100  |
	| LanguageENGLISH                                           | Language            | ENGLISH                                              | precos       | ENGLISH                                              | 100  |
	| PublicationTypeMiscellaneous                              | PublicationType     | Miscellaneous                                        | precos       | Miscellaneous                                        | 100  |
	| OtherIds00006534_2015_136_286e_hallock_bilobed_2          | OtherIds            | 00006534_2015_136_286e_hallock_bilobed_2             | precos       | 00006534_2015_136_286e_hallock_bilobed_2             | 100  |
	| Keywordssurgery                                           | Keywords            | surgery                                              | precos       | surgery                                              | 100  |
	| KeywordsplasticSurgeryEducation                           | Keywords            | plastic surgery education                            | precos       | plastic surgery education                            | 100  |
	| ByLineHumanSubjectsResearch                               | ByLine              | Human Subjects Research                              | precos       | Human Subjects Research                              | 100  |
	| ByLineSurgery(Plastic)                                    | ByLine              | Surgery (Plastic)                                    | precos       | Surgery Plastic                                      | 100  |
	| DocumentType\"COSMETIC SECTION: COSMETIC SPECIAL TOPICS\" | DocumentType        | \"COSMETIC SECTION: COSMETIC SPECIAL TOPICS\"        | precos       | COSMETIC SECTION: COSMETIC SPECIAL TOPICS            | 100  |
	| CaptionFigure                                             | Caption             | Figure                                               | precos       | Figure                                               | 100  |
	| CaptionCentralTendencyScoresof19US                        | Caption             | Central tendency scores of 19 U.S.                   | precos       | Central tendency scores of 19 U S                    | 100  |
	| CitationCutaneousInjuryInducesTheReleaseOfCathelicidin    | Citation            | Cutaneous injury induces the release of cathelicidin | prcsgo       | Cutaneous injury induces the release of cathelicidin | 100  |
	| CME                                                       | CME                 | CME                                                  | precos       | CME                                                  | 100  |
	| SubTitlereview                                            | SubTitle            | review                                               | precos       | review                                               | 100  |
	


  @Synonyms
Scenario Outline: SingleFieldSearchwithSynonyms
Given I set fieldname to '<fieldName>'
		And I set fieldName value to '<query>'
		And I set products to '<JournalNames>'
		And I set filterField to '<FilterField>'
		And I set filterQuery to '<FilterQuery>'
		And I set filterQuery list 		
		And I set expected resultsetRow to '<Rows>'
		And I set expected resultsetReturnFields to returnfields '<fieldName>' and '<Subtitle>'
		And I set the synonyms field to true
		And I Generate the Search Request Body
	When I post the request to searchAPI
	Then I should get a response in JSON format
		And The response should have '<Rows>' number of result field
		And The First field name of the result fields should match '<fieldName>'
		And Any of the two fields value should contain substring of '<expectedFilterString>'		
	Examples: 
	| Description              | fieldName | query        | JournalNames | FilterField | FilterQuery | expectedFilterString                                                         | Rows |
	| TitleLungCancerPrecos    | Title     | lung cancer  | precos       | AssetType   | Article     | lung cancer ,Cancer of Lung,Pulmonary Cancer                                 | 100  |
	| TitleHeartAttack         | Title     | heart attack | precos       | AssetType   | Article     | heart attack ,Cardiovascular Stroke,Myocardial Infarct,Myocardial Infarction | 100  |
	| AbstractHeartAtack       | Abstract  | heart attack | precos       | AssetType   | Article     | heart attack ,Cardiovascular Stroke,Myocardial Infarct,Myocardial Infarction | 100  |
	| AbstractLungCancer       | Abstract  | lung cancer  | precos       | AssetType   | Article     | lung cancer,Cancer of Lung,Cancer of the Lung,Pulmonary Cancer               | 100  |
	| TitleLungCancerPrcsgo    | Title     | lung cancer  | PRCSGO       | AssetType   | Article     | lung cancer ,Cancer of Lung,Pulmonary Cancer                                 | 100  |
	| AbstractLungCancerPrcsGo | Abstract  | lung cancer  | PRCSGO       | AssetType   | Article     | lung cancer,Cancer of Lung,Cancer of the Lung,Pulmonary Cancer               | 100  |



@SDC 
Scenario Outline: SingleFieldSearchWithSDC
Given I set fieldname to '<fieldName>'
		And I set fieldName value to '<query>'
		And I set products to '<JournalNames>'		
		And I set expected resultsetRow to '<Rows>'
		And I set expected resultsetReturnFields to '<fieldName>'
		And I Generate the Search Request Body
	When I post the request to searchAPI
	Then I should get a response in JSON format
		And The response should have '<Rows>' number of result field
		And The First field name of the result fields should match '<fieldName>'
		And The SDC field value of each result member should be equal to '<query>'
	Examples: 
	| Description | fieldName | query | JournalNames | Rows |
	| TruePrecos  | SDC       | TRUE  | precos       | 100  |
	| FalsePrecos | SDC       | FALSE | precos       | 100  |
	| TruePrcsgo  | SDC       | TRUE  | PRCSGO       | 100  |
	| FalsePrcsgo | SDC       | FALSE | PRCSGO       | 100  |

 @TeaserText
Scenario Outline: SingleFieldSearchwithTeaserText
Given I set fieldname to '<fieldName>'
		And I set fieldName value to '<query>'
		And I set products to '<JournalNames>'
		And I set filterField to '<FilterField>'
		And I set filterQuery to '<FilterQuery>'
		And I set filterQuery list 		
		And I set expected resultsetRow to '<Rows>'
		And I set expected resultsetReturnFields to '<fieldName>'
		And I Generate the Search Request Body
	When I post the request to searchAPI
	Then I should get a response in JSON format
		And The response should have '<Rows>' number of result field
		And The First field name of the result fields should match '<fieldName>'
		And Any of the two fields value should contain substring of '<expectedFilterString>'		
	Examples: 
	| Description                                      | fieldName           | query                                                | JournalNames | FilterField | FilterQuery | expectedFilterString                                 | Rows |
	| JournalNamePlasticAndReconstructiveSurgery       | JournalName         | Plastic and Reconstructive Surgery                   | precos       | AssetType   | Article     | Plastic and Reconstructive Surgery                   | 100  |
	| ePublicationDate1997                             | ePublicationDate    | 1997-04-1T00:00:00Z                                  | precos       | AssetType   | Article     | 1997                                                 | 100  |
	| PublicationDateYear2000                          | PublicationDateYear | 2000                                                 | precos       | AssetType   | Article     | 2000                                                 | 100  |
	| PublicationTitlePlasticAndReconstructiveSurgery  | PublicationTitle    | Plastic and Reconstructive Surgery                   | precos       | AssetType   | Article     | Plastic and Reconstructive Surgery                   | 100  |
	| JournalNamePlasticAndReconstructiveSurgeryPrcsgo | JournalName         | Plastic and Reconstructive Surgery                   | prcsgo       | AssetType   | Article     | Plastic and Reconstructive Surgery                   | 100  |
	| JournalNameReconstructiveSurgeryGlobalOpen       | JournalName         | Reconstructive Surgery Global Open                   | PRCSGO       | AssetType   | Article     | Reconstructive Surgery Global Open                   | 100  |
	| OriginalTitleClassification                      | OriginalTitle       | Classification                                       | precos       | AssetType   | Article     | Classification                                       | 100  |
	| FirstPage889                                     | FirstPage           | 889                                                  | precos       | AssetType   | Article     | 889                                                  | 100  |
	| DOI                                              | DOI                 | 10.1097/01.prs.0000234672.69287.77                   | precos       | AssetType   | Article     | 10.1097/01.prs.0000234672.69287.77                   | 100  |
	| Abstract                                         | Abstract            | Society of Plastic Surgeons                          | prcsgo       | AssetType   | Article     | Society of Plastic Surgeons                          | 100  |
	| CopyrightWithSymbol                              | Copyright           | ©2000American Society of Plastic Surgeons            | precos       | AssetType   | Article     | ©2000American Society of Plastic Surgeons            | 100  |
	| CopyrightWithoutSymbol                           | Copyright           | Plastic Surgeons                                     | precos       | AssetType   | Article     | Plastic Surgeons                                     | 100  |
	| FirstAuthorWithFullName                          | FirstAuthor         | DINGMAN REED                                         | precos       | AssetType   | Article     | DINGMAN REED                                         | 100  |
	| FirstAuthorWithLastName                          | FirstAuthor         | REED                                                 | precos       | AssetType   | Article     | REED                                                 | 100  |
	| Authors                                          | Authors             | STRAATSMA                                            | precos       | AssetType   | Article     | STRAATSMA                                            | 100  |
	| Affiliations                                     | Affiliations        | Yale University School of Medicine                   | precos       | AssetType   | Article     | Yale University School of Medicine                   | 100  |
	| Language                                         | Language            | ENGLISH                                              | precos       | AssetType   | Article     | ENGLISH                                              | 100  |
	| PublicationType                                  | PublicationType     | Miscellaneous                                        | prcsgo       | AssetType   | Article     | Miscellaneous                                        | 100  |
	| OtherIds                                         | OtherIds            | 00006534_2015_136_286e_hallock_bilobed_2             | precos       | AssetType   | Article     | 00006534_2015_136_286e_hallock_bilobed_2             | 100  |
	| KeywordsWithSingleWord                           | Keywords            | surgery                                              | precos       | AssetType   | Article     | surgery                                              | 100  |
	| KeywordsWithMultipleWords                        | Keywords            | plastic surgery education                            | precos       | AssetType   | Article     | plastic surgery education                            | 100  |
	| ByLineHumanSubjectsResearch                      | ByLine              | Human Subjects Research                              | precos       | AssetType   | Article     | Human Subjects Research                              | 100  |
	| ByLineSurgeryPlastic                             | ByLine              | Surgery Plastic                                      | precos       | AssetType   | Article     | Surgery Plastic                                      | 100  |
	| DocumentType                                     | DocumentType        | COSMETIC SECTION: COSMETIC SPECIAL TOPICS            | precos       | AssetType   | Article     | COSMETIC SECTION: COSMETIC SPECIAL TOPICS            | 100  |
	| CaptionSingle                                    | Caption             | Figure                                               | precos       | AssetType   | Article     | Figure                                               | 100  |
	| CaptionMultiple                                  | Caption             | Central tendency scores of 19 U.S.                   | precos       | AssetType   | Article     | Central tendency scores of 19 U.S.                   | 100  |
	| Citation                                         | Citation            | Cutaneous injury induces the release of cathelicidin | prcsgo       | AssetType   | Article     | Cutaneous injury induces the release of cathelicidin | 100  |
	| CME                                              | CME                 | CME                                                  | precos       | AssetType   | Article     | CME                                                  | 100  |
	