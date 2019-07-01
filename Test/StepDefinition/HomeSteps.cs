using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace Test
{
    [Binding]
    public class Test1Steps

    {
        IWebDriver driver = new ChromeDriver();


        [Given(@"I Launch the browser to access the URL")]
        public void GivenILaunchTheBrowserToAccessTheURL()
        {
            //IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://openweathermap.org/");
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts(10, timeun);

        }


        [Then(@"I should be able to see the landing page with the logo OpenWeather")]
        public void ThenIShouldBeAbleToSeeTheLandingPageWithTheTitleOpenWeather()
        {
            IWebElement logo = driver.FindElement(By.XPath("//*[@id='undefined-sticky-wrapper']/div/div/div/div[1]/a/img"));
            Console.WriteLine("Logo found for OpenWeather");
        }


        [Then(@"I should see the menu (.*)")]
        public void ThenIShouldSeeTheMenu(string list)
        {
            IList <IWebElement> menuList = driver.FindElements(By.XPath("//*[@id='undefined-sticky-wrapper']/div/div/div/div[2]/ul/li[contains(.,'" + list + "')]"));
            foreach (IWebElement option in menuList)
            {
                if (option.Displayed)
                {
                    menuList.Add(option);
                }
            }
        }


        [Then(@"I should few links like Support Center, Weather in your city, Sign In and Sign Up")]
        public void ThenIShouldFewLinksLikeSupportCenterWeatherInYourCitySignInAndSignUp(string supportCenter)
        {
           IWebElement supportCenterLnk = driver.FindElement(By.XPath("//div[1]/div/div/div[1]/a[contains(.,'" + supportCenter + "')]"));
        }


       
    }
}
