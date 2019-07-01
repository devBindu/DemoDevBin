Feature: Test1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background:
And I Launch the browser to access the URL 

@mytag
Scenario Outline: Add two numbers
Then I should be able to see the landing page with the logo OpenWeather
And I should few links like Support Center, Weather in your city, Sign In and Sign Up
And I should see the menu <MenuList>

Examples:
| MenuList                                                    |
| Weather;Maps;Guide;API;Price;Partners;Stations;Widgets;Blog |

