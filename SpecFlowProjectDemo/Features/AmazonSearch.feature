Feature: AmazonSearch

Search the given keyword
@tag1
Scenario: visibility of the Gift Cards elements
	Given I have navigated to amazon website
	When I press Gift Cards button 
	Then I should navigate to Gift Cards result page


@tag2
Scenario: Amazon should search for given keywords and should navigate to search result page
	Given I have navigated to amazon website
	And  I have entered phone as search keyword
	When I press the search button
	Then I should navigate to search result page

@tag3
Scenario: visibility of the elements
	Given I have navigated to amazon website
	When I press sell button
	Then I should navigate to sell result page