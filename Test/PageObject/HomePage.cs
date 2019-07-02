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

        public void verifyLogo()
        {
            try
            {
                Boolean flag =    openWeatherLogo.Displayed;
                Assert.IsTrue(flag);
                Console.WriteLine("Logo found for OpenWeather");
            }
            catch (Exception e)
            {
                Console.WriteLine("Logo found for OpenWeather"+e.Message);
            }
            
        }
             

    }
}
