Feature: Test1
	

Background:
And I Launch the browser to access the URL 

@mytag
Scenario Outline: Verify Home screen label and other details
Then I should be able to see the landing page with the logo OpenWeather
And I should few links like Support Center, Weather in your city, Sign In and Sign Up
And I should see the menu <MenuList>

Examples:
| MenuList                                                    |
| Weather;Maps;Guide;API;Price;Partners;Stations;Widgets;Blog |


@invalidScenario
Scenario: Verify invalid scenario
When I enter an invalid city name as Test
Then after clicking on Search, an error message should be displayed as Not found

