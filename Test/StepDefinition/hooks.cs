using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Weather.StepDefinition
{
    public class Hooks
    {
        public IWebDriver driver;
        public PageObject.HomePage homepage;
        [BeforeScenario]

        public void setUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();


            homepage = new PageObject.HomePage();
            PageFactory.InitElements(driver, homepage);
        }

        [AfterScenario]
        public void AfterScenario()
        {
           driver.Quit();
        }



    }
}
