Feature: AmazonSearch

Search the given keyword

@tag1
Scenario: Amazon should search for given keywords and should navigate to search result page
	Given I have navigated to amazon website
	And  I have entered  <phone holder> as search keyword
	When I press the search button
	Then I should navigate to search result page
