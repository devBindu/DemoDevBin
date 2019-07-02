using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;
//using OpenQA.Selenium.Support.UI;
using System.Timers;
using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.Support.UI.ExpectedConditions;
using Test.StepDefinition;

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
            driver.Quit();

        }


        [Then(@"I should few links like (.*), (.*), (.*) and (.*)")]
        public void ThenIShouldFewLinksLikeSupportCenterWeatherInYourCitySignInAndSignUp(string supportCenter, string weather, string signin, string signup)
        {
            IWebElement supportCenterLnk = driver.FindElement(By.XPath("//div[1]/div/div/div[1]/a[contains(.,'" + supportCenter + "')]"));
            IWebElement weatherLnk = driver.FindElement(By.XPath("//div[1]/div/div/div[1]/a[contains(.,'" + weather + "')]"));
            IWebElement signinLnk = driver.FindElement(By.XPath("//div[1]/div/div/div[1]/a[contains(.,'" + signin + "')]"));
            IWebElement signupLnk = driver.FindElement(By.XPath("//div[1]/div/div/div[1]/a[contains(.,'" + signup + "')]"));
        }


        [When(@"I enter an invalid city name as (.*)")]
        public void WhenIEnterAnInvalidCityName(string cityName)
        {
            IWebElement cityTxt = driver.FindElement(By.XPath("(//*[@id='q'])[2]"));
            cityTxt.Clear();
            cityTxt.SendKeys(cityName);
        }


        [Then(@"after clicking on Search, an error message should be displayed as Not found")]
        public void ThenAfterClickingOnSearchAnErrorMessageShouldBeDisplayedAsNotFound()
        {
            IWebElement searchBtn = driver.FindElement(By.XPath("//*[@id='searchform']/button"));
            searchBtn.Click();

            Thread.Sleep(2000);
            IWebElement messageTxt = driver.FindElement(By.XPath("//*[@id='forecast_list_ul']/div"));

            driver.Quit();

        }

        [Then(@"after clicking on Search,  (.*) should be displayed")]
        public void ThenAfterClickingOnSearchShouldBeDisplayed(string cityInfo)
        {
            IWebElement searchBtn = driver.FindElement(By.XPath("//*[@id='searchform']/button"));
            searchBtn.Click();

            Thread.Sleep(5000);
            IWebElement cityLnk = driver.FindElement(By.XPath("//*[@id='forecast_list_ul']/table/tbody/tr/td[2]/b[1]/a[contains(text(),' " +cityInfo+"')]"));
            Console.WriteLine("City Link found");
        }


        [Then(@"I should be able to see the description as  (.*)")]
        public void ThenIShouldBeAbleToSeeTheDescriptionAs(string desc)
        {
            Thread.Sleep(2000);
            IWebElement descTxt = driver.FindElement(By.XPath("//b[2]/i[contains(text(),' "+desc+"')]"));
        }



        [Then(@"I should also see the temperature and coordinates as (.*)")]
        public void ThenIShouldAlsoSeeTheTemperatureAndCoordinatesAs(string coord)
        {
            Thread.Sleep(2000);
            IWebElement tempTxt = driver.FindElement(By.XPath("//*[@id='forecast_list_ul']/table/tbody/tr/td[2]/p[1]/span"));
            Thread.Sleep(2000);
            IWebElement coordTxt = driver.FindElement(By.XPath("//p[2]/a[contains(.,'"+ coord + "')]"));
            if(coord.Equals(coordTxt))
            {
                Console.WriteLine("Co-ordinate matches");
            }
            driver.Quit();
        }


    }
}
