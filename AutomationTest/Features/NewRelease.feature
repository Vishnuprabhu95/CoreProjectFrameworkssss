Feature: NewRelease
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

 @smoke @regression @recent-regression
Scenario: New release title should be displayed
	Given the user is on application home page
	When the user clicks new release tab
	Then the "Amazon Hot New Releases" title displays in best seller tab
