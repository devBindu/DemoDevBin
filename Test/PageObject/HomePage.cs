using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using NUnit.Framework;

namespace Weather.PageObject
{
   public class HomePage : StepDefinition.Hooks
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='undefined-sticky-wrapper']/div/div/div/div[1]/a/img")] private IWebElement openWeatherLogo { get; set; }
        [FindsBy(How = How.XPath, Using = "//b[2]/i[contains(text(),'[?]')]")] private IWebElement descTxt { get; set; }
       
        [FindsBy(How = How.XPath, Using = "//*[@id='forecast_list_ul']/table/tbody/tr/td[2]/p[1]/span")] private IWebElement tempTxt { get; set; }
        [FindsBy(How = How.XPath, Using = "//p[2]/a[contains(.,'[?]')]")] private IWebElement coordTxt { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='searchform']/button")] private IWebElement searchBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='forecast_list_ul']/table/tbody/tr/td[2]/b[1]/a[contains(text(),'[?]')]")] private IWebElement cityLnk { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[text()[contains(.,'Not found')]])[1]")] private IWebElement errorMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[1]/div/div/div[1]/a[contains(text(),'[?]')]")] private IWebElement homeMenu { get; set; }




        public void verifyLogo()
        {
            try
            {
                Boolean flag = openWeatherLogo.Displayed;
                Assert.IsTrue(flag);
                Console.WriteLine("Logo found for OpenWeather");
            }
            catch (Exception e)
            {
                Console.WriteLine("Logo not found for OpenWeather " +e.Message);
            }
            
        }
             
        public void verifyDescription(string desc)
        {

        if(desc.Equals(descTxt))

            {
                Console.WriteLine("Description found for the city searched");
            }
        else
            {
                Console.WriteLine("Description not found for the city searched");
            }


        }


        public void verifyCityInfo(string city)

        {
            try
            {
                if (searchBtn.Displayed)
                {
                    searchBtn.Click();
                    if (city.Equals(cityLnk))
                    {
                        Console.WriteLine("City info displayed " +city);
                    }

                    else
                    {
                        Console.WriteLine("City not found");
                    }

                }
                
                else
                {
                    Console.WriteLine("Search button not found");
                }
            }

            catch(Exception e)

            {
                Console.WriteLine("City info not found " + e.Message);
            }
                                                  
        }




        public void verifyTemperatureAndCoordinates(string coordinates)

        {
            try
            {
                Thread.Sleep(2000);
                Boolean flag = tempTxt.Displayed;
                Assert.IsTrue(flag);
                Console.WriteLine("Temperature info found for the searched city");
                Thread.Sleep(3000);
                if(coordTxt.Equals(coordinates))
                {
                    Console.WriteLine("Coordinates found for the searched city");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Temperature and coordinates not found for the searched city" + e.Message);
            }


        }



        public void verifyErrorMessage()
        {
            if (searchBtn.Displayed)
            {
                searchBtn.Click();
                Thread.Sleep(3000);
                if (errorMessage.Displayed)
                {
                    
                    Assert.IsTrue(true, "Error Message displayed as Not found" + errorMessage.Text);
                }

            }
            else
            {
                Console.WriteLine("Error message not found");
            }

        }



    }
}
