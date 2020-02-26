Feature: Home
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@smoke @regression @recent-regression
Scenario: Best seller title should be displayed
	Given the user is on application home page
	When the user clicks best seller tab
	Then the "Amazon Bestseller" title displays in best seller tab

@smoke @regression @recent-regression
Scenario: Perfome search using excel input search term
	Given the user is on application home page
	When the user performs search
	Then the results page displayed