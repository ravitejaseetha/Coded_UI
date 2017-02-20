Feature: Race
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background: 
     Given I'm a new player




	@elf
	Scenario: Elf race characters get additional 20 damage resistance using data table
		And I have the following attributes
		| attribute  | value |
		| Race       | Elf   |
		| Resistance | 10    |
	When I take 40 damage
	Then My health should now be 90


	Scenario Outline: Health reduction	
	When I take <damage> damage
	Then My health should now be Audi

	@source:ss.xlsx
	Examples: 
	| damage | expectedHealth |


	Scenario: Total magical power
	Given I have the following magical items
	| name   | value | power |
	| Ring   | 200   | 100   |
	Then My total magical power should be 700
	Then My total  power should be 700


