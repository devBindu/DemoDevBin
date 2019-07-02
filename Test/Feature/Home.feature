Feature: Landing page verification
	

Background:
And I Launch the browser to access the URL 

@Smoke
Scenario Outline: Verify Home screen label and other details
Then I should be able to see the landing page with the logo OpenWeather
And I should few links like Support Center, Weather in your city, Sign In and Sign Up
And I should see the menu <MenuList>

Examples:
| MenuList                                                    |
| Weather;Maps;Guide;API;Price;Partners;Stations;Widgets;Blog |


@Smoke
Scenario: Verify invalid scenario
When I enter an invalid city name as Test
Then after clicking on Search, an error message should be displayed as Not found



@Smoke
Scenario: Verify valid scenario with city name
When I enter an invalid city name as Mumbai
Then after clicking on Search,  Mumbai, IN should be displayed
And I should be able to see the description as  light rain
And I should also see the temperature and coordinates as [19.0144, 72.8479]

